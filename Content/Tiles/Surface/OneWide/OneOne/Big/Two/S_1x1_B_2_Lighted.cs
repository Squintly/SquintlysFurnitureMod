using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Two;

public class S_1x1_B_2_Lighted : ModTile
{
    public enum StyleID
    {
        BlueBirthdaySlice,
        PinkBirthdaySlice,
        GreenBirthdaySlice,
        BirthdayCupcake,
    }
    private Asset<Texture2D> flameTexture;
    public override void Load()
    {
        flameTexture = ModContent.Request<Texture2D>(Texture + "_Flame");
    }

    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        Main.tileLighted[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);

        TileObjectData.newTile.CoordinateHeights = new int[1] { 30 };
        TileObjectData.newTile.CoordinateWidth = 30;
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
        TileObjectData.newTile.DrawYOffset = -12;

        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.newTile.StyleMultiplier = 2;
        TileObjectData.newTile.StyleWrapLimit = 2;
        TileObjectData.newTile.RandomStyleRange = 2;

        TileObjectData.addTile(Type);

        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
    }

    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
    {
        return true;
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
        int topY = j - tile.TileFrameY % 32 / 32;

        short frameAdjustment = (short)(tile.TileFrameX >= 32 ? -32 : 32); //change first two by total size, last by style size

        for (int x = topX; x < topX + 1; x++) // change depending on width
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

        if (Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendTileSquare(-1, topX, topY, 1, 1); //change for width, height
        }
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        Tile tile = Main.tile[i, j];
        if (tile.TileFrameX == 0)
        {
            r = 1f;
            g = 0.95f;
            b = 0.65f;
        }
    }
    public override void GetTileFlameData(int i, int j, ref TileDrawing.TileFlameData tileFlameData)
    {
        ulong flameSeed = Main.TileFrameSeed ^ (ulong)(((long)i << 32) | (uint)j);

        tileFlameData.flameTexture = flameTexture.Value;
        tileFlameData.flameSeed = flameSeed;

        tileFlameData.flameCount = 7;
        tileFlameData.flameColor = new Color(100, 100, 100, 0);
        tileFlameData.flameRangeXMin = -10;
        tileFlameData.flameRangeXMax = 11;
        tileFlameData.flameRangeYMin = -10;
        tileFlameData.flameRangeYMax = 1;
        tileFlameData.flameRangeMultX = 0.15f;
        tileFlameData.flameRangeMultY = 0.35f;
    }
}
