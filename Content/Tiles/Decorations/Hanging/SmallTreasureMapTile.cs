using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.Hanging;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Hanging;

public class SmallTreasureMapTile : ModTile
{
	public override void SetStaticDefaults()
	{
        Main.tileFrameImportant[base.Type] = true;
        TileID.Sets.DisableSmartCursor[base.Type] = true;

        Main.tileLavaDeath[base.Type] = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        Main.tileWaterDeath[base.Type] = true;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

        Main.tileNoFail[base.Type] = true;
        TileID.Sets.FramesOnKillWall[base.Type] = false;
        Main.tileNoAttach[base.Type] = true;

		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
		TileObjectData.newTile.DrawYOffset = -1;
		TileObjectData.newTile.Width = 2;
		TileObjectData.newTile.Height = 2;
		TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };

		TileObjectData.addTile(base.Type);

		base.AddMapEntry(new Color(120, 111, 98), base.CreateMapEntryName("Small Treasure Map"));
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<SmallTreasureMap>());
	}
}
