using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.Hanging;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Hanging;

public class LargeHangingFishTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[base.Type] = true;
		Main.tileLavaDeath[base.Type] = true;
		Main.tileNoAttach[base.Type] = true;
		TileID.Sets.FramesOnKillWall[base.Type] = false;
		TileID.Sets.DisableSmartCursor[base.Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
		TileObjectData.newTile.DrawYOffset = -2;
		TileObjectData.newTile.Width = 2;
		TileObjectData.newTile.Height = 3;
		TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 16 };
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.addTile(base.Type);
		base.AddMapEntry(new Color(60, 179, 11), base.CreateMapEntryName());
		base.HitSound = SoundID.NPCHit19;
		base.DustType = 33;
	}

	public override void KillMultiTile(int x, int y, int frameX, int frameY)
	{
		int item = 0;
		switch (frameX / 36)
		{
		case 0:
			item = ModContent.ItemType<LargeHangingCod>();
			break;
		case 1:
			item = ModContent.ItemType<LargeHangingBass>();
			break;
		case 2:
			item = ModContent.ItemType<LargeHangingFlounder>();
			break;
		case 3:
			item = ModContent.ItemType<LargeHangingSnapper>();
			break;
		case 4:
			item = ModContent.ItemType<LargeHangingSalmon>();
			break;
		case 5:
			item = ModContent.ItemType<LargeHangingTrout>();
			break;
		case 6:
			item = ModContent.ItemType<LargeHangingTuna>();
			break;
		}
		if (item > 0)
		{
			Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 32, 48, item);
		}
	}
}
