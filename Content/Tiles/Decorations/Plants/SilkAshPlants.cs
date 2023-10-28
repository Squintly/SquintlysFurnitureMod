using SquintlysFurnitureMod.Content.Items.Decorations.Plants;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Plants;

public class SilkAshPlants : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;
        Main.tileWaterDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.DrawXOffset = 0;
        TileObjectData.newTile.DrawYOffset = -14;
        TileObjectData.newTile.CoordinateHeights = new int[1] { 32 };
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;

        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);

        TileObjectData.newTile.RandomStyleRange = 11;
        TileObjectData.newTile.StyleWrapLimit = 111;
        TileObjectData.newTile.StyleHorizontal = true;

        TileID.Sets.SwaysInWindBasic[Type] = true;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        RegisterItemDrop(ModContent.ItemType<SilkAshPlantsItem>());
        HitSound = SoundID.Grass;
    }
}