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
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Wall.Sconces
{
    internal class Sconces : ModTile
    {
        public enum StyleID
        {
            ImperialSconceCandle, //0
            ImperialSconce, //1
            ImperialSconceGlass, //2
            TatteredSconceCandle, //3
            TatteredSconceGlass, //4
            TatteredSconceThick, //5
            TatteredSconceCandleSilver, //6
            TatteredSconceGlassSilver, //7
            TatteredSconceThickSilver, //8
            RepairedSconceCandle, //9
            RepairedSconceGlass, //10
            RepairedSconceThick, //11
            RepairedSconceCandleSilver, //12
            RepairedSconceGlassSilver, //13
            RepairedSconceThickSilver, //14
            StoneBrickSconce, //15
            StoneBrickSconceSmall, //16
            RedBrickSconce, //17
            RedBrickSconceSmall, //18
            CinderblockSconce //19
        }

        private Asset<Texture2D> flameTexture;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            Main.tileLavaDeath[Type] = true;
            Main.tileWaterDeath[Type] = true;

            TileID.Sets.FramesOnKillWall[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.IsAMechanism[Type] = true;

            Main.tileLighted[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            AdjTiles = new int[] { TileID.Torches };

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);

            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
            TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
            TileObjectData.newAlternate.AnchorAlternateTiles = new[] { 124, 561, 574, 575, 576, 577, 578 };
            TileObjectData.newAlternate.DrawXOffset = -2;
            TileObjectData.addAlternate(1);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
            TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
            TileObjectData.newAlternate.AnchorAlternateTiles = new[] { 124, 561, 574, 575, 576, 577, 578 };
            TileObjectData.newAlternate.DrawXOffset = 2;
            TileObjectData.addAlternate(2);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
            TileObjectData.newAlternate.AnchorWall = true;
            TileObjectData.addAlternate(0);

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 6;
            TileObjectData.newTile.StyleWrapLimit = 6;

            TileObjectData.addTile(Type);

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

            if (!Main.dedServ)
            {
                flameTexture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Furniture/Lights/Wall/Sconces/Sconces_Flame"); // We could also reuse Main.FlameTexture[] textures, but using our own texture is nice.
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
            int topX = i - tile.TileFrameX % 22 / 22;
            int topY = j - tile.TileFrameY % 22 / 22;

            short frameAdjustment = (short)(tile.TileFrameX > 44 ? -66 : 66);

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

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (Main.tile[i, j].TileFrameX / 66 != 0)
            {
                return;
            }

            StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);
            switch (style)
            {
                case StyleID.ImperialSconceCandle:
                case StyleID.ImperialSconce:
                case StyleID.ImperialSconceGlass:
                case StyleID.RepairedSconceCandle:
                case StyleID.RepairedSconceGlass:
                case StyleID.RepairedSconceThick:
                case StyleID.RepairedSconceCandleSilver:
                case StyleID.RepairedSconceGlassSilver:
                case StyleID.RepairedSconceThickSilver:
                    r = 1f;
                    g = .95f;
                    b = .9f;
                    break; //warm bright

                case StyleID.StoneBrickSconce:
                case StyleID.StoneBrickSconceSmall:
                case StyleID.RedBrickSconce:
                case StyleID.RedBrickSconceSmall:
                case StyleID.CinderblockSconce:
                    r = 1f;
                    g = .85f;
                    b = .70f;
                    break; //yellow bright

                case StyleID.TatteredSconceCandle:
                case StyleID.TatteredSconceGlass:
                case StyleID.TatteredSconceThick:
                case StyleID.TatteredSconceCandleSilver:
                case StyleID.TatteredSconceGlassSilver:
                case StyleID.TatteredSconceThickSilver:
                    r = 1f;
                    g = .75f;
                    b = .75f;
                    break; //warm dim

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

            if (Main.rand.NextBool(40) && tileFrameX < 66)
            {
                StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);

                int dustChoice = -1;

                switch (style)
                {
                    case StyleID.TatteredSconceCandle:
                    case StyleID.TatteredSconceGlass:
                    case StyleID.TatteredSconceThick:
                    case StyleID.TatteredSconceCandleSilver:
                    case StyleID.TatteredSconceGlassSilver:
                    case StyleID.TatteredSconceThickSilver:
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
                        case StyleID.TatteredSconceCandle:
                        case StyleID.TatteredSconceGlass:
                        case StyleID.TatteredSconceThick:
                        case StyleID.TatteredSconceCandleSilver:
                        case StyleID.TatteredSconceGlassSilver:
                        case StyleID.TatteredSconceThickSilver:
                            Dust dust = Dust.NewDustDirect(new Vector2(i * 16, j * 16 + 2), 4, 4, dustChoice, 0f, 0f, 100);
                            if (Main.rand.NextBool(40))
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

            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }

            int width = 18;
            int offsetY = 0;
            int height = 18;
            short frameX = tile.TileFrameX;
            short frameY = tile.TileFrameY;

            TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref frameX, ref frameY);

            ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (uint)i); // Don't remove any casts.

            StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);
            switch (style)
            {
                //Flame
                case StyleID.TatteredSconceCandle:
                case StyleID.TatteredSconceThick:
                case StyleID.TatteredSconceCandleSilver:
                case StyleID.TatteredSconceThickSilver:
                    for (int c = 0; c < 7; c++)
                    {
                        float shakeX = Utils.RandomInt(ref randSeed, -12, 11) * 0.2f;
                        float shakeY = Utils.RandomInt(ref randSeed, -12, 1) * 0.4f;

                        spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 20, 20, 0), 0f, default, 1f, effects, 0f);
                    }
                    break;
                    
                case StyleID.TatteredSconceGlass:
                case StyleID.TatteredSconceGlassSilver:
                    for (int c = 0; c < 7; c++)
                    {
                        float shakeX = Utils.RandomInt(ref randSeed, -12, 11) * 0.2f;
                        float shakeY = Utils.RandomInt(ref randSeed, -12, 1) * 0.4f;

                        spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 60, 60, 0), 0f, default, 1f, effects, 0f);
                    }
                    break;

                //Low Flicker
                case StyleID.ImperialSconce:
                case StyleID.CinderblockSconce:
                    for (int c = 0; c < 1; c++)
                    {
                        float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.05f;
                        float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.05f;

                        spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
                    }
                    break;

                //No Flicker
                case StyleID.StoneBrickSconce:
                case StyleID.StoneBrickSconceSmall:
                case StyleID.RedBrickSconce:
                case StyleID.RedBrickSconceSmall:
                    for (int c = 0; c < 1; c++)
                    {
                        float shakeX = Utils.RandomInt(ref randSeed, -5, 5) * 0.01f;
                        float shakeY = Utils.RandomInt(ref randSeed, -5, 1) * 0.01f;

                        spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
                    }
                    break;

                default:
                    for (int c = 0; c < 7; c++)
                    {
                        float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                        float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

                        spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 50, 50, 0), 0f, default, 1f, effects, 0f);
                    }
                    break;
            }

            //public override void GetTileFlameData(int i, int j, ref TileDrawing.TileFlameData tileFlameData)
            //{
            //    ulong flameSeed = Main.TileFrameSeed ^ (ulong)(((long)i << 32) | (uint)j);

            //    tileFlameData.flameTexture = flameTexture.Value;
            //    tileFlameData.flameSeed = flameSeed;

            //    StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);
            //    switch (style)
            //    {
            //        case StyleID.ImperialSconce:
            //        case StyleID.CinderblockSconce:
            //            tileFlameData.flameCount = 1;
            //            tileFlameData.flameColor = new Color(100, 100, 100, 0);
            //            tileFlameData.flameRangeXMin = -5;
            //            tileFlameData.flameRangeXMax = 5;
            //            tileFlameData.flameRangeYMin = -5;
            //            tileFlameData.flameRangeYMax = 1;
            //            tileFlameData.flameRangeMultX = 0.05f;
            //            tileFlameData.flameRangeMultY = 0.05f;
            //            break; //tiny flicker

            //        case StyleID.StoneBrickSconce:
            //        case StyleID.StoneBrickSconceSmall:
            //        case StyleID.RedBrickSconce:
            //        case StyleID.RedBrickSconceSmall:
            //            tileFlameData.flameCount = 1;
            //            tileFlameData.flameColor = new Color(100, 100, 100, 0);
            //            tileFlameData.flameRangeXMin = -5;
            //            tileFlameData.flameRangeXMax = 5;
            //            tileFlameData.flameRangeYMin = -5;
            //            tileFlameData.flameRangeYMax = 1;
            //            tileFlameData.flameRangeMultX = 0.01f;
            //            tileFlameData.flameRangeMultY = 0.01f;
            //            break; //No flicker

            //        case StyleID.TatteredSconceCandle:
            //        case StyleID.TatteredSconceGlass:
            //        case StyleID.TatteredSconceThick:
            //        case StyleID.TatteredSconceCandleSilver:
            //        case StyleID.TatteredSconceGlassSilver:
            //        case StyleID.TatteredSconceThickSilver:
            //            tileFlameData.flameCount = 7;
            //            tileFlameData.flameColor = new Color(100, 100, 100, 0);
            //            tileFlameData.flameRangeXMin = -15;
            //            tileFlameData.flameRangeXMax = 15;
            //            tileFlameData.flameRangeYMin = -15;
            //            tileFlameData.flameRangeYMax = 1;
            //            tileFlameData.flameRangeMultX = 0.20f;
            //            tileFlameData.flameRangeMultY = 0.40f;
            //            break; //flickery flame

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
        }
    }
}