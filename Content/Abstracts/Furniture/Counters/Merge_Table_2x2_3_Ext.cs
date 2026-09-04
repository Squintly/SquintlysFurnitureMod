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
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace SquintlysFurnitureMod.Content.Abstracts.Furniture.Counters;

public abstract class Merge_Table_2x2_3_Ext : ModTile
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
        TileObjectData.newTile.Width = 2;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.SpecificRandomStyles = [0, 4, 8];
        TileObjectData.newTile.StyleMultiplier = 12;

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
        int topX = i - tile.TileFrameX % 36 / 16; //change first number depending on size
        int topY = j - tile.TileFrameY % 36 / 16;

        bool shiftPressed = Main.keyState.PressingShift();
        bool altPressed = Main.keyState.IsKeyDown(Keys.LeftAlt);

        if (shiftPressed)
        {
            short frameAdjustment = (short)(tile.TileFrameX >= 288 ? -288 : 144); //change first two by total size, last by style size

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
        //Merge
        if (altPressed)
        {
            if (tile.TileFrameX < 142)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 108 ? -108 : 36); //change first two by total size, last by style size

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
            if (tile.TileFrameX > 142 && tile.TileFrameX <= 286)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 252 ? -108 : 36); //change first two by total size, last by style size

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
            if (tile.TileFrameX > 286 && tile.TileFrameX <= 430)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 396 ? -108 : 36); //change first two by total size, last by style size

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
    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    {
        Tile tile = Main.tile[i, j];
        Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

        if (Main.drawToScreen)
        {
            zero = Vector2.Zero;
        }

        //Tops 
        if ( tile.TileFrameY == 0)
        {
            var texture = ModContent.Request<Texture2D>(Texture + "_Tops").Value;

            int offsetX, offsetY, x, y;
            offsetX = offsetY = x = y = 0;
            int height = tile.TileFrameY == 36 ? 18 : 16;

            int frameX = (Main.tile[i, j].TileFrameX % 36);
            int frameY = (Main.tile[i, j].TileFrameY % 36);

            x = Main.tile[i, j].TileFrameX;
            offsetX = 0;
            y = 0;
            offsetY = 16;

            spriteBatch.Draw(
                texture,
                new Vector2((i * 16 + offsetX - (int)Main.screenPosition.X), (j * 16 - offsetY - (int)Main.screenPosition.Y)) + zero,
                (Rectangle?)new Rectangle(x, y, 16, 16),
                Lighting.GetColor(i, j), 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);

            //Re-draw
            //Left 1-up
            Tile tileRedraw = (Main.tile[i, j - 1]);
            if (tileRedraw.TileType != 0)
            {
                spriteBatch.Draw(
                    TextureAssets.Tile[tileRedraw.TileType].Value,
                    new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - 16 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(tileRedraw.TileFrameX, tileRedraw.TileFrameY, 16, 16),
                    Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
            }
            //Right 1-up
            tileRedraw = (Main.tile[i + 1, j - 1]);
            if (tileRedraw.TileType != 0)
            {
                spriteBatch.Draw(
                    TextureAssets.Tile[tileRedraw.TileType].Value,
                    new Vector2(i * 16 + 16 - (int)Main.screenPosition.X, j * 16 - 16 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(tileRedraw.TileFrameX, tileRedraw.TileFrameY, 16, 16),
                    Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
            }
            //Left 2-up
            tileRedraw = (Main.tile[i, j - 2]);
            if (tileRedraw.TileType != 0)
            {
                spriteBatch.Draw(
                    TextureAssets.Tile[tileRedraw.TileType].Value,
                    new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - 32 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(tileRedraw.TileFrameX, tileRedraw.TileFrameY, 16, 16),
                    Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
            }
            //Right 2-up
            tileRedraw = (Main.tile[i + 1, j - 2]);
            if (tileRedraw.TileType != 0)
            {
                spriteBatch.Draw(
                    TextureAssets.Tile[tileRedraw.TileType].Value,
                    new Vector2(i * 16 + 16 - (int)Main.screenPosition.X, j * 16 - 32 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(tileRedraw.TileFrameX, tileRedraw.TileFrameY, 16, 16),
                    Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
            }
        }
        return true;
    }
}