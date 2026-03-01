using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Wall.ThreeWide.ThreeOne.Normal;

public class W_3x1_N_LR_3 : ModTile
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

        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
        TileObjectData.newTile.Origin = new Point16(0, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.newTile.StyleMultiplier = 6;
        TileObjectData.newTile.StyleWrapLimit = 6;
        TileObjectData.newTile.RandomStyleRange = 3;

        TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;

        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
        TileObjectData.addAlternate(3);

        TileObjectData.addTile(Type);
    }

    public override bool RightClick(int i, int j)
    {
        SoundEngine.PlaySound(SoundID.Mech);
        ToggleTile(i, j);
        return true;
    }

    public override void HitWire(int i, int j)
    {
        ToggleTile(i, j);
    }

    public void ToggleTile(int i, int j)
    {
        Tile tile = Main.tile[i, j];
        int topX = i - tile.TileFrameX % 54 / 18; //change first number depending on size
        int topY = j - tile.TileFrameY % 18 / 18;

        if (tile.TileFrameX >= 162)
        {
            short frameAdjustment = (short)(tile.TileFrameX >= 270 ? -108 : 54);
            for (int x = topX; x < topX + 3; x++) // change depending on width
            {
                for (int y = topY; y < topY + 1; y++) // change height
                {
                    Main.tile[x, y].TileFrameX += frameAdjustment;

                    if (Wiring.running)
                    {
                        Wiring.SkipWire(x, y);
                    }
                }
            }
        }//change first two by total size - one style, last by style size
        else
        {
            short frameAdjustment = (short)(tile.TileFrameX >= 108 ? -108 : 54);
            for (int x = topX; x < topX + 3; x++) // change depending on width
            {
                for (int y = topY; y < topY + 1; y++) // change height
                {
                    Main.tile[x, y].TileFrameX += frameAdjustment;

                    if (Wiring.running)
                    {
                        Wiring.SkipWire(x, y);
                    }
                }
            }
        }//change first two by total size - one style, last by style size

        if (Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendTileSquare(-1, topX, topY, 3, 1); //change for width, height
        }
    }
}

/*STYLES
0- Mounted RPGs
*/