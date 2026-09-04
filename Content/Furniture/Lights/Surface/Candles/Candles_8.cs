using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using SquintlysFurnitureMod.Content.Furniture.Lights.Surface.Candles.Candles_3.Items;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Surface.Candles
{
    internal class Candles_8 : ModTile
    {
        public enum StyleID
        {
            TatteredCandle, //0
            TatteredSilverCandle, //1
            RepairedCandle, //2
            RepairedSilverCandle, //3
        }

        private Asset<Texture2D> flameTexture;

        public override void Load()
        {
            flameTexture = ModContent.Request<Texture2D>(Texture + "_Flame");
        }

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            Main.tileLavaDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            TileID.Sets.IsAMechanism[Type] = true;

            Main.tileLighted[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            AdjTiles = new int[] { TileID.Torches };

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.CoordinateHeights = new int[1] { 32 };
            TileObjectData.newTile.CoordinateWidth = 32;
            TileObjectData.newTile.DrawYOffset = -14;
            TileObjectData.newTile.Origin = new Point16(0, 0);

            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 16;
            TileObjectData.newTile.StyleMultiplier = 16;
            TileObjectData.newTile.RandomStyleRange = 8;

            TileObjectData.addTile(Type);

            AddMapEntry(new Color(230, 200, 50), Language.GetText("MapObject.Candle"));
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            Tile t = Main.tile[i, j];
            int style = t.TileFrameY / 34;
            yield return new Item(Mod.Find<ModItem>(Candles_3_Items.GetInternalNameFromStyle(1)).Type);
            yield return new Item(Mod.Find<ModItem>(Candles_3_Items.GetInternalNameFromStyle(2)).Type);
            yield return new Item(Mod.Find<ModItem>(Candles_3_Items.GetInternalNameFromStyle(3)).Type);
            yield return new Item(Mod.Find<ModItem>(Candles_3_Items.GetInternalNameFromStyle(4)).Type);
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
            int topX = i - tile.TileFrameX % 34 / 34; //change first number depending on size
            int topY = j - tile.TileFrameY % 34 / 34;

            short frameAdjustment = (short)(tile.TileFrameX >= 272 ? -272 : 272);

            for (int x = topX; x < topX + 1; x++) // change depending on width
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

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (Main.tile[i, j].TileFrameX / 272 != 0)
            {
                return;
            }

            StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);
            switch (style)
            {
                case StyleID.TatteredCandle: //Cool
                case StyleID.TatteredSilverCandle:
                    r = 1f;
                    g = .75f;
                    b = .75f; ;
                    break;

                case StyleID.RepairedCandle: //Cool
                case StyleID.RepairedSilverCandle:
                    r = 1f;
                    g = .95f;
                    b = .95f;
                    break;

                default:
                    r = 1f;
                    g = 0.95f;
                    b = 0.8f;
                    break;
            }
        }

        public override void EmitParticles(int i, int j, Tile tileCache, short tileFrameX, short tileFrameY, Color tileLight, bool visible)
        {
            if (!visible)
            {
                return;
            }

            Tile tile = Main.tile[i, j];

            short frameX = tile.TileFrameX;
            short frameY = tile.TileFrameY;

            if (Main.rand.NextBool(40) && tileFrameX / 102 != 0)
            {
                StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);

                int dustChoice = -1;

                switch (style)
                {
                    case StyleID.TatteredCandle:
                    case StyleID.TatteredSilverCandle:
                        dustChoice = DustID.Torch;
                        break;

                    default:
                        dustChoice = -1;
                        break;
                }

                if (dustChoice != -1)
                {
                    switch (style)
                    {
                        case StyleID.TatteredCandle:
                        case StyleID.TatteredSilverCandle:
                            Dust dust = Dust.NewDustDirect(new Vector2(i * 16, j * 16 + 2), 14, 6, dustChoice, 0f, 0f, 100);
                            if (Main.rand.NextBool(3))
                            {
                                dust.noGravity = true;
                            }

                            dust.velocity *= 0.3f;
                            dust.velocity.Y -= 1.5f;
                            break;
                    }
                }
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            var tile = Main.tile[i, j];

            if (!TileDrawing.IsVisible(tile))
            {
                return;
            }

            SpriteEffects effects = SpriteEffects.None;

            if (i % 2 == 1) {
				effects = SpriteEffects.FlipHorizontally;
			}

            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            int width = 34;
            int offsetY = 0;
            int height = 34;
            short frameX = tile.TileFrameX;
            short frameY = tile.TileFrameY;

            TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref frameX, ref frameY);

            ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (uint)i); // Don't remove any casts.

            StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);
            switch (style)
            {
                //High Flicker
                case StyleID.TatteredCandle:
                    for (int c = 0; c < 7; c++)
                    {
                        float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.2f;
                        float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.4f;

                        spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);  
                    }
                    break;

                default:
                    for (int c = 0; c < 7; c++)
                    {
                        float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                        float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

                        spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);                       
                    }
                    break;
            }
        }
        //public override void GetTileFlameData(int i, int j, ref TileDrawing.TileFlameData tileFlameData)
        //{
        //    ulong flameSeed = Main.TileFrameSeed ^ (ulong)(((long)i << 32) | (uint)j);

        //    tileFlameData.flameTexture = flameTexture.Value;
        //    tileFlameData.flameSeed = flameSeed;

        //    StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);
        //    switch (style)
        //    {
        //        case StyleID.Imperial: //Low glow, low flicker
        //            tileFlameData.flameCount = 7;
        //            tileFlameData.flameColor = new Color(100, 100, 100, 0);
        //            tileFlameData.flameRangeXMin = -10;
        //            tileFlameData.flameRangeXMax = 11;
        //            tileFlameData.flameRangeYMin = -10;
        //            tileFlameData.flameRangeYMax = 1;
        //            tileFlameData.flameRangeMultX = 0.15f;
        //            tileFlameData.flameRangeMultY = 0.35f;
        //            break;

        //        case StyleID.StoneBrick:
        //        case StyleID.RedBrick:
        //            tileFlameData.flameCount = 1;
        //            tileFlameData.flameColor = new Color(100, 100, 100, 0);
        //            tileFlameData.flameRangeXMin = -5;
        //            tileFlameData.flameRangeXMax = 5;
        //            tileFlameData.flameRangeYMin = -5;
        //            tileFlameData.flameRangeYMax = 1;
        //            tileFlameData.flameRangeMultX = 0.01f;
        //            tileFlameData.flameRangeMultY = 0.01f;
        //            break; //No flicker

        //        default:
        //            tileFlameData.flameCount = 7;
        //            tileFlameData.flameColor = new Color(100, 100, 100, 0);
        //            tileFlameData.flameRangeXMin = -10;
        //            tileFlameData.flameRangeXMax = 11;
        //            tileFlameData.flameRangeYMin = -10;
        //            tileFlameData.flameRangeYMax = 1;
        //            tileFlameData.flameRangeMultX = 0.15f;
        //            tileFlameData.flameRangeMultY = 0.35f;
        //            break;
        //    }
        //}
    }
}