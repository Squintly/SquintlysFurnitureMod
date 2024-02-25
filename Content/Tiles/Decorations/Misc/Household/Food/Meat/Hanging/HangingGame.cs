using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Misc.Household.Food.Meat.Hanging;

public class HangingGame : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
        TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 20 };
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
        TileObjectData.newTile.CoordinateWidth = 18;

        TileObjectData.newTile.Origin = new Point16(0, 0);

        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 111;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);
    }
}