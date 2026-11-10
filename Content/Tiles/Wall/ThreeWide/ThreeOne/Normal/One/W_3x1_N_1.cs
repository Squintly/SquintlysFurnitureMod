using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Wall.ThreeWide.ThreeOne.Normal.One;

public class W_3x1_N_1 : ModTile
{
    public enum StyleID
    {
        ToolBoard
    }
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileID.Sets.FramesOnKillWall[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);

        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
        TileObjectData.newTile.Origin = new Point16(0, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.addTile(Type);
    }
}
