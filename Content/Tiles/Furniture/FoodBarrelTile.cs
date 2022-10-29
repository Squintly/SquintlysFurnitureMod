using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Furniture;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture;

public class FoodBarrelTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSpelunker[base.Type] = true;
		Main.tileContainer[base.Type] = true;
		Main.tileFrameImportant[base.Type] = true;
		Main.tileNoAttach[base.Type] = true;
		Main.tileOreFinderPriority[base.Type] = 500;
		TileID.Sets.HasOutlines[base.Type] = true;
		TileID.Sets.BasicChest[base.Type] = true;
		TileID.Sets.DisableSmartCursor[base.Type] = true;
		base.DustType = 16;
		base.AdjTiles = new int[1] { 21 };
		base.ChestDrop = ModContent.ItemType<FoodBarrel>();
		base.ContainerName.SetDefault("Food Barrel");
		ModTranslation name = base.CreateMapEntryName();
		name.SetDefault("Barrel");
		base.AddMapEntry(new Color(174, 129, 92), name, MapChestName);
		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
		TileObjectData.newTile.Origin = new Point16(0, 1);
		TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
		TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, processedCoordinates: true);
		TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, processedCoordinates: false);
		TileObjectData.newTile.AnchorInvalidTiles = new int[1] { 127 };
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.LavaDeath = false;
		TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
		TileObjectData.addTile(base.Type);
	}

	public override ushort GetMapOption(int i, int j)
	{
		return (ushort)(Main.tile[i, j].TileFrameX / 36);
	}

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
	{
		return true;
	}

	public string MapChestName(string name, int i, int j)
	{
		int left = i;
		int top = j;
		Tile tile = Main.tile[i, j];
		if (tile.TileFrameX % 36 != 0)
		{
			left--;
		}
		if (tile.TileFrameY != 0)
		{
			top--;
		}
		int chest = Chest.FindChest(left, top);
		if (Main.chest[chest].name == "")
		{
			return name;
		}
		return name + ": " + Main.chest[chest].name;
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, base.ChestDrop);
		Chest.DestroyChest(i, j);
	}

	public override bool RightClick(int i, int j)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		Player player = Main.LocalPlayer;
		Tile tile = Main.tile[i, j];
		Main.mouseRightRelease = false;
		int left = i;
		int top = j;
		if (tile.TileFrameX % 36 != 0)
		{
			left--;
		}
		if (tile.TileFrameY != 0)
		{
			top--;
		}
		if (player.sign >= 0)
		{
			SoundEngine.PlaySound(in SoundID.MenuClose);
			player.sign = -1;
			Main.editSign = false;
			Main.npcChatText = "";
		}
		if (Main.editChest)
		{
			SoundEngine.PlaySound(in SoundID.MenuTick);
			Main.editChest = false;
			Main.npcChatText = "";
		}
		if (player.editedChestName)
		{
			NetMessage.SendData(33, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
			player.editedChestName = false;
		}
		bool isLocked = this.IsLockedChest(left, top);
		if (Main.netMode == 1 && !isLocked)
		{
			if (left == player.chestX && top == player.chestY && player.chest >= 0)
			{
				player.chest = -1;
				Recipe.FindRecipes();
				SoundEngine.PlaySound(in SoundID.MenuClose);
			}
			else
			{
				NetMessage.SendData(31, -1, -1, null, left, top);
				Main.stackSplit = 600;
			}
		}
		else
		{
			int chest = Chest.FindChest(left, top);
			if (chest == player.chest)
			{
				player.chest = -1;
				SoundEngine.PlaySound(in SoundID.MenuClose);
			}
			else if (chest != player.chest && player.chest == -1)
			{
				player.chest = chest;
				Main.playerInventory = true;
				Main.recBigList = false;
				SoundEngine.PlaySound(in SoundID.MenuOpen);
				player.chestX = left;
				player.chestY = top;
			}
			else
			{
				player.chest = chest;
				Main.playerInventory = true;
				Main.recBigList = false;
				SoundEngine.PlaySound(in SoundID.MenuTick);
				player.chestX = left;
				player.chestY = top;
			}
			Recipe.FindRecipes();
		}
		return true;
	}

	public override void MouseOver(int i, int j)
	{
		Player player = Main.LocalPlayer;
		Tile tile = Main.tile[i, j];
		int left = i;
		int top = j;
		if (tile.TileFrameX % 36 != 0)
		{
			left--;
		}
		if (tile.TileFrameY != 0)
		{
			top--;
		}
		int chest = Chest.FindChest(left, top);
		if (chest < 0)
		{
			player.cursorItemIconText = Language.GetTextValue("LegacyChestType.0");
		}
		else
		{
			player.cursorItemIconText = ((Main.chest[chest].name.Length > 0) ? Main.chest[chest].name : "Food Barrel");
			if (player.cursorItemIconText == "Food Barrel")
			{
				player.cursorItemIconID = ModContent.ItemType<Items.Furniture.FishBarrel>();
				player.cursorItemIconText = "";
			}
		}
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
	}

	public override void MouseOverFar(int i, int j)
	{
		this.MouseOver(i, j);
		Player player = Main.LocalPlayer;
		if (player.cursorItemIconText == "")
		{
			player.cursorItemIconEnabled = false;
			player.cursorItemIconID = 0;
		}
	}
}
