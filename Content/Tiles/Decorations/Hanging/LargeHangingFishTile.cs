using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SquintlysFurnitureMod.Content.Items.Decorations.Hanging;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Hanging;

public class LargeHangingFishTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[base.Type] = true;
        TileID.Sets.DisableSmartCursor[base.Type] = true;

        Main.tileLavaDeath[base.Type] = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        Main.tileNoAttach[base.Type] = true;
        Main.tileNoFail[base.Type] = true;
        TileID.Sets.FramesOnKillWall[base.Type] = false;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
        TileObjectData.newTile.DrawYOffset = -2;
		TileObjectData.newTile.Width = 2;
		TileObjectData.newTile.Height = 3;
		TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 16 };

		TileObjectData.newTile.StyleHorizontal = true;

		TileObjectData.addTile(base.Type);

		base.AddMapEntry(new Color(90, 110, 199), base.CreateMapEntryName("Large Hanging Fish"));
		base.HitSound = SoundID.NPCHit25;
		base.DustType = DustID.Water;
	}

	public override void KillMultiTile(int x, int y, int frameX, int frameY)
	{
		int item = 0;
		switch (frameX / 36)
		{
		case 0:
			item = ModContent.ItemType<Items.Decorations.Hanging.Fish.LargeHangingCod>();
			break;
		case 1:
			item = ModContent.ItemType<Items.Decorations.Hanging.Fish.LargeHangingBass>();
			break;
		case 2:
			item = ModContent.ItemType<Items.Decorations.Hanging.Fish.LargeHangingFlounder>();
			break;
		case 3:
			item = ModContent.ItemType<Items.Decorations.Hanging.Fish.LargeHangingSnapper>();
			break;
		case 4:
			item = ModContent.ItemType<Items.Decorations.Hanging.Fish.LargeHangingSalmon>();
			break;
		case 5:
			item = ModContent.ItemType<Items.Decorations.Hanging.Fish.LargeHangingTrout>();
			break;
		case 6:
			item = ModContent.ItemType<Items.Decorations.Hanging.Fish.LargeHangingTuna>();
			break;
		}
		if (item > 0)
		{
			Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 16, 16, item);
		}
	}
}
