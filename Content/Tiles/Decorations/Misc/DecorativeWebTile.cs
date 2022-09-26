using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Misc;

public class DecorativeWebTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[base.Type] = false;
		Main.tileSolid[base.Type] = false;
		Main.tileNoFail[base.Type] = true;
		Main.tileNoAttach[base.Type] = true;
		Main.tileLavaDeath[base.Type] = true;
		Main.tileWaterDeath[base.Type] = true;
		Main.tileBlendAll[base.Type] = true;
		Main.tileMergeDirt[base.Type] = true;
		Main.tileNoSunLight[base.Type] = true;
		Main.tileBlockLight[base.Type] = false;
		TileObjectData.newTile.CopyFrom(TileObjectData.StyleSwitch);
		TileObjectData.newTile.Width = 1;
		TileObjectData.newTile.Height = 1;
		TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.addTile(base.Type);
		base.DustType = 30;
		base.AddMapEntry(new Color(50, 50, 50), base.CreateMapEntryName());
		base.ItemDrop = ModContent.ItemType<DecorativeWebItem>();
		base.HitSound = SoundID.Grass;
		base.MineResist = 0.25f;
	}
}
