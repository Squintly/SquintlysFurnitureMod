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

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.Chandeliers.Chandeliers_1
{
    [LegacyName("Chandeliers")]
    public class Chandeliers_1 : ModTile
    {
        public enum StyleID
        {
            ImperialChandelier, //0
            FestiveChandelier, //1
            HeartfeltChandelier, //2
            TeakChandelier, //3
            CinderblockChandelier, //4
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

            TileID.Sets.MultiTileSway[Type] = true;
            TileID.Sets.IsAMechanism[Type] = true;

            Main.tileLighted[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            AdjTiles = new int[] { TileID.Torches };

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Origin = new Point16(1, 0);

            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };

            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.StyleWrapLimit = 2;

            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom | AnchorType.PlanterBox, 1, 1);

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.PlatformNonHammered, 3, 0);
            TileObjectData.newAlternate.DrawYOffset = -8;
            TileObjectData.addAlternate(0);

            TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile); //3-wide attachment
            TileObjectData.newSubTile.LinkedAlternates = true;
            TileObjectData.newSubTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom | AnchorType.PlanterBox, TileObjectData.newTile.Width, 0);
            TileObjectData.addSubTile(3);

            TileObjectData.addTile(Type);

            AddMapEntry(new Color(230, 200, 50), Language.GetText("MapObject.Chandelier"));
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
            int topX = i - tile.TileFrameX % 54 / 18;
            int topY = j - tile.TileFrameY % 54 / 18;

            short frameAdjustment = (short)(tile.TileFrameX >= 54 ? -54 : 54);

            for (int x = topX; x < topX + 3; x++)
            {
                for (int y = topY; y < topY + 3; y++)
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
                NetMessage.SendTileSquare(-1, topX, topY, 3, 3);
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (Main.tile[i, j].TileFrameX / 54 != 0)
            {
                return;
            }

            StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);
            switch (style)
            {
                case StyleID.ImperialChandelier: //Cool
                    r = 1f;
                    g = .95f;
                    b = .90f;
                    break;

                case StyleID.FestiveChandelier: //Warm
                    r = 1f;
                    g = .95f;
                    b = .65f;
                    break;

                case StyleID.HeartfeltChandelier: //Reddish
                    r = 1f;
                    g = .75f;
                    b = .65f;
                    break;

                case StyleID.TeakChandelier: //Bright
                    r = 1f;
                    g = .95f;
                    b = .95f;
                    break;

                case StyleID.CinderblockChandelier: //Yellowy
                    r = 1f;
                    g = .85f;
                    b = .70f;
                    break;

                default:
                    r = 1f;
                    g = 0.95f;
                    b = 0.8f;
                    break;
            }
        }

        //public override void EmitParticles(int i, int j, Tile tileCache, short tileFrameX, short tileFrameY, Color tileLight, bool visible)
        //{
        //    if (!visible)
        //    {
        //        return;
        //    }

        //    Tile tile = Main.tile[i, j];

        //    short frameX = tile.TileFrameX;
        //    short frameY = tile.TileFrameY;

        //    if (Main.rand.NextBool(40) && tileFrameX / 54 != 0)
        //    {
        //        StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);

        //        int dustChoice = -1;

        //        switch (style)
        //        {
        //            //case StyleID.Tattered:
        //            //    if (frameY / 18 % 3 == 0)
        //            //    {
        //            //        dustChoice = DustID.Torch;
        //            //    }
        //            //    break;

        //            default:
        //                dustChoice = -1;
        //                break;
        //        }

        //        if (dustChoice != -1)
        //        {
        //            switch (style)
        //            {
        //                //case StyleID.Tattered:
        //                //    Dust dust = Dust.NewDustDirect(new Vector2(i * 16, j * 16 + 2), 14, 6, dustChoice, 0f, 0f, 100);
        //                //    if (Main.rand.NextBool(3))
        //                //    {
        //                //        dust.noGravity = true;
        //                //    }

        //                //    dust.velocity *= 0.3f;
        //                //    dust.velocity.Y -= 1.5f;
        //                //    break;
        //            }
        //        }
        //    }
        //}

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

            overrideWindCycle = 1f;
            windPushPowerY = 0;

            switch (style)
            {
                case StyleID.ImperialChandelier: //Default
                case StyleID.FestiveChandelier:
                    break;

                case StyleID.TeakChandelier:
                    overrideWindCycle = null;
                    dontRotateTopTiles = true;
                    windPushPowerY = -1f;
                    totalWindMultiplier *= 0.5f;
                    break;

                case StyleID.HeartfeltChandelier: //Mildy Stiff/Heavy
                case StyleID.CinderblockChandelier:
                    totalWindMultiplier *= 0.8f;
                    break;
            }
        }

        public override void GetTileFlameData(int i, int j, ref TileDrawing.TileFlameData tileFlameData)
        {
            ulong flameSeed = Main.TileFrameSeed ^ (ulong)(((long)i << 32) | (uint)j);

            tileFlameData.flameTexture = flameTexture.Value;
            tileFlameData.flameSeed = flameSeed;

            StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);
            switch (style)
            {
                case StyleID.HeartfeltChandelier: //Low glow, low flicker
                    tileFlameData.flameCount = 2;
                    tileFlameData.flameColor = new Color(100, 100, 100, 0);
                    tileFlameData.flameRangeXMin = -5;
                    tileFlameData.flameRangeXMax = 5;
                    tileFlameData.flameRangeYMin = -5;
                    tileFlameData.flameRangeYMax = 1;
                    tileFlameData.flameRangeMultX = 0.05f;
                    tileFlameData.flameRangeMultY = 0.05f;
                    break;

                case StyleID.TeakChandelier: //Low glow, no flicker
                case StyleID.CinderblockChandelier:
                    tileFlameData.flameCount = 1;
                    tileFlameData.flameColor = new Color(100, 100, 100, 0);
                    tileFlameData.flameRangeXMin = -5;
                    tileFlameData.flameRangeXMax = 5;
                    tileFlameData.flameRangeYMin = -5;
                    tileFlameData.flameRangeYMax = 1;
                    tileFlameData.flameRangeMultX = 0.01f;
                    tileFlameData.flameRangeMultY = 0.01f;
                    break;

                default:
                    tileFlameData.flameCount = 7;
                    tileFlameData.flameColor = new Color(100, 50, 50, 0);
                    tileFlameData.flameRangeXMin = -10;
                    tileFlameData.flameRangeXMax = 11;
                    tileFlameData.flameRangeYMin = -10;
                    tileFlameData.flameRangeYMax = 1;
                    tileFlameData.flameRangeMultX = 0.15f;
                    tileFlameData.flameRangeMultY = 0.35f;
                    break;
            }
        }
    }
}