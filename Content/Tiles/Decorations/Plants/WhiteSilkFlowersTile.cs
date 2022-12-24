using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.Plants;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Plants;

public class WhiteSilkFlowersTile : ModTile
{
	public override void SetStaticDefaults()
	{
        Main.tileFrameImportant[base.Type] = true;
        TileID.Sets.DisableSmartCursor[base.Type] = true;

        Main.tileLavaDeath[base.Type] = false;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        Main.tileWaterDeath[base.Type] = false;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

        Main.tileNoFail[base.Type] = false;
        Main.tileNoAttach[base.Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.DrawXOffset = 0;
        TileObjectData.newTile.DrawYOffset = -16;
        TileObjectData.newTile.CoordinateHeights = new int[1] { 32 };
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;

        TileObjectData.newTile.RandomStyleRange = 16;
        TileObjectData.newTile.StyleHorizontal = true;

        TileID.Sets.SwaysInWindBasic[base.Type] = true;

        TileObjectData.addTile(base.Type);

        base.ItemDrop = ModContent.ItemType<WhiteSilkFlowers>();

        base.AddMapEntry(new Color(74, 122, 51), base.CreateMapEntryName("Flowers"));
        base.HitSound = SoundID.Grass;
    }
}
