﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered
{
    internal class TatteredCandleTile : ModTile
    {
        private Asset<Texture2D> flameTexture;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            Main.tileLavaDeath[Type] = true;
            Main.tileWaterDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            Main.tileLighted[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[1] { 20 };
            TileObjectData.newTile.DrawYOffset = -4;

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.newTile.StyleLineSkip = 2;

            TileObjectData.addTile(Type);

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

            if (!Main.dedServ)
            {
                flameTexture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Tiles/Furniture/NewSets/Tattered/TatteredCandleTile_Flame"); // We could also reuse Main.FlameTexture[] textures, but using our own texture is nice.
            }

            AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Candle"));
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return true;
        }

        public override bool RightClick(int i, int j)
        {
            SoundEngine.PlaySound(SoundID.Mech, new Vector2(i * 16, j * 16));
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
            int topX = i - tile.TileFrameX % 18 / 18;
            int topY = j - tile.TileFrameY % 18 / 18;

            short frameAdjustment = (short)(tile.TileFrameX > 0 ? -18 : 18);

            for (int x = topX; x < topX + 1; x++)
            {
                for (int y = topY; y < topY + 1; y++)
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
                NetMessage.SendTileSquare(-1, topX, topY, 1, 1);
            }
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects) {
         	if (i % 2 == 1) {
         		spriteEffects = SpriteEffects.FlipHorizontally;
         	}
         }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX == 0)
            {
                  //We can support different light colors for different styles here: switch (tile.frameY / 54)
                r = 0.8f;
                g = 0.75f;
                b = 0.7f;
            }
        }

         public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData) {
         	if (Main.gamePaused || !Main.instance.IsActive || Lighting.UpdateEveryFrame && !Main.rand.NextBool(4)) {
         		return;
         	}

         	Tile tile = Main.tile[i, j];

         	short frameX = tile.TileFrameX;
         	short frameY = tile.TileFrameY;

         	// Return if the lamp is off (when frameX is 0), or if a random check failed.
         	if (frameX != 0 || !Main.rand.NextBool(40)) {
         		return;
         	}

         	int style = frameY / 54;

         	if (frameY / 36 % 3 == 0) {
         		int dustChoice = -1;

         		if (style == 0) {
         			dustChoice = (DustID.Torch);
         		}

         		// We can support different dust for different styles here
         		if (dustChoice != -1) {
         			var dust = Dust.NewDustDirect(new Vector2(i * 16 + 4, j * 16 + 2), 4, 4, dustChoice, 0f, 0f, 100, default, 1f);

         			if (!Main.rand.NextBool(3)) {
         				dust.noGravity = true;
         			}

         			dust.velocity *= 0.3f;
         			dust.velocity.Y = dust.velocity.Y - 1.5f;
         		}
         	}
         }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            SpriteEffects effects = SpriteEffects.None;

             if (i % 2 == 1) {
             	effects = SpriteEffects.FlipHorizontally;
             }

            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }

            Tile tile = Main.tile[i, j];
            int width = 18;
            int offsetY = 0;
            int height = 18;
            short frameX = tile.TileFrameX;
            short frameY = tile.TileFrameY;

            TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref frameX, ref frameY);

            ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i); // Don't remove any casts.

            // We can support different flames for different styles here: int style = Main.tile[j, i].frameY / 54;
            for (int c = 0; c < 2; c++)
            {
                float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.0f;
                float shakeY = Utils.RandomInt(ref randSeed, -10, 10) * 0.07f;

                spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
            }
        }
    }
}