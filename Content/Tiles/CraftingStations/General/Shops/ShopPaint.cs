using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;

public class ShopPaint : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.Height = 4;
        TileObjectData.newTile.CoordinateHeights = new int[4] { 16, 16, 16, 18 };
        TileObjectData.newTile.Width = 5;
        TileObjectData.newTile.CoordinatePadding = 2;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(200, 200, 200), Language.GetText("Shop"));
        AnimationFrameHeight = 74;
    }
    public override bool RightClick(int i, int j)
    {
        SoundEngine.PlaySound(SoundID.Mech, new Vector2(i * 16, j * 16));

        Tile tile = Main.tile[i, j];
        (int topX, int topY) = TileObjectData.TopLeft(i, j);
        bool shiftPressed = Main.keyState.PressingShift();

        if (!shiftPressed)
        {
            for (int x = topX; x < topX + 5; x++)
            {
                for (int y = topY; y < topY + 4; y++)
                {
                    Main.tile[x, y].TileType = (ushort)ModContent.TileType<ShopSmith>();
                }
            }
        }

        if (shiftPressed)
        {
            for (int x = topX; x < topX + 5; x++)
            {
                for (int y = topY; y < topY + 4; y++)
                {
                    Main.tile[x, y].TileType = (ushort)ModContent.TileType<ShopMisc>();
                }
            }
        }

        if (Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendTileSquare(-1, topX, topY, 5, 4);
        }

        return true;
    }
    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        frameCounter++;
        if (frameCounter >= 20)
        {
            frameCounter = 0;
            frame++;
            frame %= 19;
        }
    }

    public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
    {
        var tile = Main.tile[i, j];
        if (tile.TileFrameY < 74)
        {
            frameYOffset = Main.tileFrame[type] * 74;
        }
    }

    public override void RandomUpdate(int i, int j)
    {
        if (Main.dayTime && Main.time == 0)
        {
            RightClick(i, j);
        }
    }

}