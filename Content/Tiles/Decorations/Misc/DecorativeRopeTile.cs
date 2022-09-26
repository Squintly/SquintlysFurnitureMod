using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Misc;

public class DecorativeRopeTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[base.Type] = true;
		Main.tileSolid[base.Type] = false;
		Main.tileNoFail[base.Type] = true;
		Main.tileNoAttach[base.Type] = true;
		Main.tileLavaDeath[base.Type] = true;
		Main.tileWaterDeath[base.Type] = false;
		Main.tileNoSunLight[base.Type] = false;
		Main.tileBlockLight[base.Type] = false;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
		TileObjectData.newTile.Width = 2;
		TileObjectData.newTile.Height = 1;
		TileObjectData.newTile.CoordinateHeights = new int[1] { 18 };
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.addTile(base.Type);
		base.DustType = 129;
		base.AddMapEntry(new Color(50, 50, 50), base.CreateMapEntryName());
		base.HitSound = SoundID.Grass;
		base.MineResist = 0.25f;
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, 16, j * 16, 16, 18, ModContent.ItemType<DecorativeRope>());
	}
}
