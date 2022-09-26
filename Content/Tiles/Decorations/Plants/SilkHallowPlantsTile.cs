using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.Plants;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Plants;

public class SilkHallowPlantsTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[base.Type] = false;
		Main.tileNoFail[base.Type] = true;
		Main.tileNoAttach[base.Type] = true;
		Main.tileLavaDeath[base.Type] = true;
		Main.tileWaterDeath[base.Type] = true;
		Main.tileTable[base.Type] = true;
		Main.tileFrameImportant[base.Type] = true;
		TileID.Sets.DisableSmartCursor[base.Type] = true;
		Main.tileNoSunLight[base.Type] = false;
		Main.tileBlockLight[base.Type] = false;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
		TileObjectData.newTile.Width = 1;
		TileObjectData.newTile.Height = 1;
		TileObjectData.newTile.Origin = new Point16(0, 0);
		TileObjectData.newTile.DrawXOffset = 0;
		TileObjectData.newTile.DrawYOffset = 0;
		TileObjectData.newTile.CoordinateHeights = new int[1] { 32 };
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.RandomStyleRange = 22;
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.newTile.StyleHorizontal = true;
		TileID.Sets.SwaysInWindBasic[base.Type] = true;
		TileObjectData.addTile(base.Type);
		base.ItemDrop = ModContent.ItemType<SilkHallowPlants>();
		base.AddMapEntry(new Color(205, 133, 63), base.CreateMapEntryName());
		base.HitSound = SoundID.Grass;
		base.MineResist = 0.25f;
	}
}
