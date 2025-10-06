using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.ThreeWide.ThreeThree;

public class S_3x3_6 : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);

        TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };

        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleMultiplier = 6;
        TileObjectData.newTile.StyleWrapLimit = 6;
        TileObjectData.newTile.RandomStyleRange = 6;

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
        int topY = j - tile.TileFrameY % 54 / 18;

        short frameAdjustment = (short)(tile.TileFrameX >= 270 ? -270 : 54); //change first two by total size - one style, last by style size

        for (int x = topX; x < topX + 3; x++) // change depending on width
        {
            for (int y = topY; y < topY + 3; y++) // change height
            {
                Main.tile[x, y].TileFrameX += frameAdjustment;

                if (Wiring.running)
                {
                    Wiring.SkipWire(x, y);
                }
            }
        }

        if (Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendTileSquare(-1, topX, topY, 3, 3); //change for width, height
        }
    }
}

/*STYLES
0- Future Gun Rack
*/