using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Multi.Corners;

public class Webs : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);

        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.CoordinateHeights = new int[1] { 44 };
        TileObjectData.newTile.CoordinateWidth = 44;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.newTile.StyleMultiplier = 80;
        TileObjectData.newTile.StyleWrapLimit = 16;
        TileObjectData.newTile.RandomStyleRange = 16;

        TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
        TileObjectData.newTile.DrawYOffset = -14;

        AnchorData SolidAnchor1 = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, 1, 0);

        //Top Rights

        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.AnchorTop = SolidAnchor1;
        TileObjectData.newAlternate.AnchorRight = SolidAnchor1;
        TileObjectData.addAlternate(32);

        //Bottom Left

        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.AnchorLeft = SolidAnchor1;
        TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
        TileObjectData.addAlternate(48);

        //Bottom Right

        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.AnchorRight = SolidAnchor1;
        TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
        TileObjectData.addAlternate(64);

        //Top

        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        //TileObjectData.newAlternate.Origin = Point16.Zero;
        TileObjectData.newAlternate.AnchorTop = SolidAnchor1;
        TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.EmptyTile | AnchorType.AlternateTile, 1, 0);
        TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.EmptyTile | AnchorType.AlternateTile, 1, 0);
        TileObjectData.newAlternate.AnchorAlternateTiles = [ModContent.TileType<Webs>()];
        //TileObjectData.newAlternate.DrawYOffset = -14;
        TileObjectData.addAlternate(16);

        //Top Left

        TileObjectData.newTile.AnchorTop = SolidAnchor1;
        TileObjectData.newTile.AnchorLeft = SolidAnchor1;

        TileObjectData.addTile(Type);
    }

    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
    {
        offsetY = -14;
    }
}

/* STYLES
0- Webs
1- Dark Webs
*/