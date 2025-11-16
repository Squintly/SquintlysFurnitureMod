using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.Enums;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Wall.TwoWide.TwoThree;

public class W_2x3_8 : ModTile
{
    public enum StyleID
    {
        RibbonRosettes //0
    }

    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        TileID.Sets.MultiTileSway[Type] = true;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);

        TileObjectData.newTile.Width = 2;
        TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 16 };

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.newTile.StyleMultiplier = 8;
        TileObjectData.newTile.StyleWrapLimit = 8;
        TileObjectData.newTile.RandomStyleRange = 8;

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
        int topX = i - tile.TileFrameX % 36 / 18; //change first number depending on size
        int topY = j - tile.TileFrameY % 54 / 18;

        short frameAdjustment = (short)(tile.TileFrameX >= 252 ? -252 : 36); //change first two by total size, last by style size

        for (int x = topX; x < topX + 2; x++) // change depending on width
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
            NetMessage.SendTileSquare(-1, topX, topY, 2, 3); //change for width, height
        }
    }

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    {
        Tile tile = Main.tile[i, j];

        if (TileObjectData.IsTopLeft(tile))
        {
            // Makes this tile sway in the wind and with player interaction when used with TileID.Sets.MultiTileSway
            Main.instance.TilesRenderer.AddSpecialPoint(i, j, TileDrawing.TileCounterType.MultiTileVine);
        }

        // We must return false here to prevent the normal tile drawing code from drawing the default static tile. Without this a duplicate tile will be drawn.
        return false;
    }

    public override void AdjustMultiTileVineParameters(int i, int j, ref float? overrideWindCycle, ref float windPushPowerX, ref float windPushPowerY, ref bool dontRotateTopTiles, ref float totalWindMultiplier, ref Texture2D glowTexture, ref Color glowColor)
    {
        StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);

        switch (style)
        {
            case StyleID.RibbonRosettes: //Stiff, no top
                dontRotateTopTiles = true;
                totalWindMultiplier *= 0.5f;
                windPushPowerY = -1f;
                break;
        }
    }
}