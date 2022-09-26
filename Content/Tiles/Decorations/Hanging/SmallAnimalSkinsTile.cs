using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.Hanging;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Hanging;

public class SmallAnimalSkinsTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[base.Type] = false;
		Main.tileNoFail[base.Type] = true;
		Main.tileNoAttach[base.Type] = true;
		Main.tileLavaDeath[base.Type] = true;
		Main.tileWaterDeath[base.Type] = true;
		Main.tileFrameImportant[base.Type] = true;
		TileID.Sets.FramesOnKillWall[base.Type] = true;
		TileID.Sets.DisableSmartCursor[base.Type] = true;
		Main.tileNoSunLight[base.Type] = false;
		Main.tileBlockLight[base.Type] = false;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
		TileObjectData.newTile.DrawYOffset = -1;
		TileObjectData.newTile.Width = 2;
		TileObjectData.newTile.Height = 2;
		TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.addTile(base.Type);
		base.AddMapEntry(new Color(205, 133, 63), base.CreateMapEntryName());
		base.HitSound = SoundID.Dig;
		base.MineResist = 0.25f;
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		int item = 0;
		switch (frameX / 36)
		{
		case 0:
			item = ModContent.ItemType<SmallTigerSkin>();
			break;
		case 1:
			item = ModContent.ItemType<SmallLeopardSkin>();
			break;
		case 2:
			item = ModContent.ItemType<SmallZebraSkin>();
			break;
		}
		if (item > 0)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, item);
		}
	}
}
