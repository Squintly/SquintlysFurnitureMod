using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Multi.StandingWall.OneWide.OneFour.Big;

public class MP_SW_1x4_B_LR_2 : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);

        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.Height = 4;
        TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 18 };
        TileObjectData.newTile.CoordinateWidth = 30;
        TileObjectData.newTile.Origin = new Point16(0, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.newTile.StyleMultiplier = 4;
        TileObjectData.newTile.StyleWrapLimit = 4;
        TileObjectData.newTile.RandomStyleRange = 2;

        TileObjectData.newTile.AnchorBottom = AnchorData.Empty;

        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
        TileObjectData.newAlternate.AnchorWall = true;
        TileObjectData.addAlternate(0);

        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
        TileObjectData.addAlternate(2);

        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
        TileObjectData.newAlternate.AnchorWall = true;
        TileObjectData.addAlternate(2);

        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);
        TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;

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
        int topX = i - tile.TileFrameX % 32 / 32; //change first number depending on size
        int topY = j - tile.TileFrameY % 72 / 18;

        if (tile.TileFrameX >= 64)
        {
            short frameAdjustment = (short)(tile.TileFrameX >= 96 ? -32 : 32); //change first two by total size - one style, last by style size

            for (int x = topX; x < topX + 1; x++) // change depending on width
            {
                for (int y = topY; y < topY + 4; y++) // change height
                {
                    Main.tile[x, y].TileFrameX += frameAdjustment;

                    if (Wiring.running)
                    {
                        Wiring.SkipWire(x, y);
                    }
                }
            }
        }
        else
        {
            short frameAdjustment = (short)(tile.TileFrameX >= 32 ? -32 : 32); //change first two by total size - one style, last by style size

            for (int x = topX; x < topX + 1; x++) // change depending on width
            {
                for (int y = topY; y < topY + 4; y++) // change height
                {
                    Main.tile[x, y].TileFrameX += frameAdjustment;

                    if (Wiring.running)
                    {
                        Wiring.SkipWire(x, y);
                    }
                }
            }
        }

        if (Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendTileSquare(-1, topX, topY, 1, 4); //change for width, height
        }
    }
}

/*STYLES
0- Short Poles
1- Short Guandaos
*/