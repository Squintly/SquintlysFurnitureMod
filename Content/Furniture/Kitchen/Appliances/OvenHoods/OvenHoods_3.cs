using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json.Linq;
using ReLogic.Content;
using SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Cupboards.Cupboards_6;
using SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Cupboards.CupboardsNarrow;
using SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Cupboards.CupboardsThin;
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

namespace SquintlysFurnitureMod.Content.Furniture.Kitchen.Appliances.OvenHoods;

public class OvenHoods_3 : ModTile
{
    public enum StyleID
    {
        OvenHoodModern, //0
        OvenHoodVintage, //1
        OvenHoodAntique, //2
        OvenHoodRetro //3
    }
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
        TileObjectData.newTile.Width = 2;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
        TileObjectData.newTile.AnchorWall = true;

        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.RandomStyleRange = 3;
        TileObjectData.newTile.StyleMultiplier = 3;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(200, 200, 200), Language.GetText("OvenHood"));
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
        if (shiftPressed)
        {
            //Modern
            if (tile.TileFrameX <= 106)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 72 ? -72 : 36); //change first two by total size, last by style size

                for (int x = topX; x < topX + 2; x++) // change depending on width
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
            }
            //Vintage
            if (tile.TileFrameX >= 108 && tile.TileFrameX <= 214)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 178 ? -72 : 36); //change first two by total size, last by style size

                for (int x = topX; x < topX + 2; x++) // change depending on width
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
            }
            //Antique
            if (tile.TileFrameX >= 214 && tile.TileFrameX <= 322)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 286 ? -72 : 36); //change first two by total size, last by style size

                for (int x = topX; x < topX + 2; x++) // change depending on width
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
            }
            //Retro
            if (tile.TileFrameX >= 322)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 394 ? -72 : 36); //change first two by total size, last by style size

                for (int x = topX; x < topX + 2; x++) // change depending on width
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
            }
        }
        if (Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendTileSquare(-1, topX, topY, 2, 1); //change for width, height
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
        if (tile.TileFrameX % 36 == 0 && tile.TileFrameY == 0)
        {
            var texture = ModContent.Request<Texture2D>(Texture + "_Tops").Value;

            int offsetX, offsetY, x, y;
            offsetX = offsetY = x = y = 0;

            int frameX = (Main.tile[i, j].TileFrameX % 36);
            int frameY = (Main.tile[i, j].TileFrameY % 18);

            x = (32 * tile.TileFrameX / 36);
            offsetX = 0;
            y = 0;
            offsetY = 16;

            spriteBatch.Draw(
                texture,
                new Vector2((i * 16 + offsetX - (int)Main.screenPosition.X), (j * 16 - offsetY - (int)Main.screenPosition.Y)) + zero,
                (Rectangle?)new Rectangle(x, y, 32, 18),
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