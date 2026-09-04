using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Content;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using System.Collections.Generic;
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
using static Terraria.ModLoader.PlayerDrawLayer;

namespace SquintlysFurnitureMod.Content.Abstracts.Furniture.Counters;

public abstract class Merge_Table_1x2_6 : ModTile
{
    public override sealed void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        AdjTiles = new int[] { TileID.Tables };
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

        Main.tileSolidTop[Type] = true;
        Main.tileTable[Type] = true;
        TileID.Sets.IgnoredByNpcStepUp[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.Height = 2;
        TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
        TileObjectData.newTile.Width = 1;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.SpecificRandomStyles = [0, 4, 8, 12, 16, 20];
        TileObjectData.newTile.StyleMultiplier = 24;

        TileObjectData.addTile(Type);

        SafeSetStaticDefaults();
    }
    public virtual void SafeSetStaticDefaults()
    {
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
        int topX = i - tile.TileFrameX % 16 / 16; //change first number depending on size
        int topY = j - tile.TileFrameY % 36 / 16;

        bool shiftPressed = Main.keyState.PressingShift();
        bool altPressed = Main.keyState.IsKeyDown(Keys.LeftAlt);

        if (shiftPressed)
        {
            short frameAdjustment = (short)(tile.TileFrameX >= 360 ? -360 : 72); //change first two by total size, last by style size

            for (int x = topX; x < topX + 1; x++) // change depending on width
            {
                for (int y = topY; y < topY + 2; y++) // change height
                {
                    Main.tile[x, y].TileFrameX += frameAdjustment;

                    if (Wiring.running)
                    {
                        Wiring.SkipWire(x, y);
                    }
                }
            }
        }
        //Merge
        if (altPressed)
        {
            if (tile.TileFrameX < 70)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 54 ? -54 : 18); //change first two by total size, last by style size

                for (int x = topX; x < topX + 2; x++) // change depending on width
                {
                    for (int y = topY; y < topY + 2; y++) // change height
                    {
                        Main.tile[x, y].TileFrameX += frameAdjustment;

                        if (Wiring.running)
                        {
                            Wiring.SkipWire(x, y);
                        }
                    }
                }
            }
            if (tile.TileFrameX > 70 && tile.TileFrameX <= 142)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 126 ? -54 : 18); //change first two by total size, last by style size

                for (int x = topX; x < topX + 2; x++) // change depending on width
                {
                    for (int y = topY; y < topY + 2; y++) // change height
                    {
                        Main.tile[x, y].TileFrameX += frameAdjustment;

                        if (Wiring.running)
                        {
                            Wiring.SkipWire(x, y);
                        }
                    }
                }
            }
            if (tile.TileFrameX > 142 && tile.TileFrameX <= 214)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 198 ? -54 : 18); //change first two by total size, last by style size

                for (int x = topX; x < topX + 2; x++) // change depending on width
                {
                    for (int y = topY; y < topY + 2; y++) // change height
                    {
                        Main.tile[x, y].TileFrameX += frameAdjustment;

                        if (Wiring.running)
                        {
                            Wiring.SkipWire(x, y);
                        }
                    }
                }
            }
            if (tile.TileFrameX > 214 && tile.TileFrameX <= 286)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 270 ? -54 : 18); //change first two by total size, last by style size

                for (int x = topX; x < topX + 2; x++) // change depending on width
                {
                    for (int y = topY; y < topY + 2; y++) // change height
                    {
                        Main.tile[x, y].TileFrameX += frameAdjustment;

                        if (Wiring.running)
                        {
                            Wiring.SkipWire(x, y);
                        }
                    }
                }
            }
            if (tile.TileFrameX > 286 && tile.TileFrameX <= 358)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 342 ? -54 : 18); //change first two by total size, last by style size

                for (int x = topX; x < topX + 2; x++) // change depending on width
                {
                    for (int y = topY; y < topY + 2; y++) // change height
                    {
                        Main.tile[x, y].TileFrameX += frameAdjustment;

                        if (Wiring.running)
                        {
                            Wiring.SkipWire(x, y);
                        }
                    }
                }
            }
            if (tile.TileFrameX > 358)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 414 ? -54 : 18); //change first two by total size, last by style size

                for (int x = topX; x < topX + 2; x++) // change depending on width
                {
                    for (int y = topY; y < topY + 2; y++) // change height
                    {
                        Main.tile[x, y].TileFrameX += frameAdjustment;

                        if (Wiring.running)
                        {
                            Wiring.SkipWire(x, y);
                        }
                    }
                }
            }
        }
        if (Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendTileSquare(-1, topX, topY, 2, 2); //change for width, height
        }
    }
}
