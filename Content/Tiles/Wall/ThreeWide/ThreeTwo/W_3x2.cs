using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Wall.ThreeWide.ThreeTwo;

public class W_3x2 : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileID.Sets.FramesOnKillWall[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);

        TileObjectData.newTile.Height = 2;
        TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.addTile(Type);
    }
}

/*STYLES
0- Gun Rack Wall Empty
1- Modern Gun Rack Empty
*/