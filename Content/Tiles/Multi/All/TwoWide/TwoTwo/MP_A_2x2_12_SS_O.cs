using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Multi.All.TwoWide.TwoTwo
{
    public class MP_A_2x2_12_SS_O : ModTile
    {
        public enum StyleID
        {
            BannerWhitePointWideShort, //0
            BannerWhiteFlatWideShort, //1
            BannerWhiteRoundWideShort, //2
            BannerGrayPointWideShort, //3
            BannerGrayFlatWideShort, //4
            BannerGrayRoundWideShort, //5
            BannerBlackPointWideShort, //6
            BannerBlackFlatWideShort, //7
            BannerBlackRoundWideShort, //8
            BannerPastelPointWideShort, //9
            BannerPastelFlatWideShort, //10
            BannerPastelRoundWideShort, //11
            BannerBrightPointWideShort, //12
            BannerBrightFlatWideShort, //13
            BannerBrightRoundWideShort, //14
            BannerNavyPointWideShort, //15
            BannerNavyFlatWideShort, //16
            BannerNavyRoundWideShort, //17
            BannerPalePointWideShort, //18
            BannerPaleFlatWideShort, //19
            BannerPaleRoundWideShort, //20
            BannerDullPointWideShort, //21
            BannerDullFlatWideShort, //22
            BannerDullRoundWideShort, //23
            BannerDimPointWideShort, //24
            BannerDimFlatWideShort, //25
            BannerDimRoundWideShort //26
        }

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileLavaDeath[Type] = true;
            Main.tileNoAttach[Type] = true;

            //TileID.Sets.MultiTileSway[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Origin = Point16.Zero;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };

            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 48;
            TileObjectData.newTile.StyleWrapLimit = 48;
            TileObjectData.newTile.RandomStyleRange = 12;

            TileObjectData.newTile.AnchorTop = AnchorData.Empty;

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Origin = Point16.Zero;
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.PlatformNonHammered, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.DrawYOffset = -8;
            TileObjectData.addAlternate(0);

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Origin = Point16.Zero;
            TileObjectData.newAlternate.AnchorWall = true;
            TileObjectData.addAlternate(0);

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Origin = new Point16(0, 1);
            TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, 2, 0);
            TileObjectData.newAlternate.AnchorAlternateTiles = [124, 561, 574, 575, 576, 577, 578];
            TileObjectData.addAlternate(12);

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Origin = new Point16(0, 0);
            TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, 2, 0);
            TileObjectData.newAlternate.AnchorAlternateTiles = [124, 561, 574, 575, 576, 577, 578];
            TileObjectData.addAlternate(24);

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Origin = Point16.Zero;
            TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidWithTop | AnchorType.PlanterBox, TileObjectData.newTile.Width, 0);
            TileObjectData.addAlternate(36);

            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom | AnchorType.PlanterBox, TileObjectData.newTile.Width, 0);

            TileObjectData.addTile(Type);
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
            int topX = i - tile.TileFrameX % 36 / 18;
            int topY = j - tile.TileFrameY % 38 / 18;

            if (tile.TileFrameX < 432)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 396 ? -396 : 36);

                for (int x = topX; x < topX + 2; x++)
                {
                    for (int y = topY; y < topY + 2; y++)
                    {
                        Main.tile[x, y].TileFrameX += frameAdjustment;

                        if (Wiring.running)
                        {
                            Wiring.SkipWire(x, y);
                        }
                    }
                }
            }

            if (tile.TileFrameX >= 432 && tile.TileFrameX < 864)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 828 ? -396 : 36);

                for (int x = topX; x < topX + 2; x++)
                {
                    for (int y = topY; y < topY + 2; y++)
                    {
                        Main.tile[x, y].TileFrameX += frameAdjustment;

                        if (Wiring.running)
                        {
                            Wiring.SkipWire(x, y);
                        }
                    }
                }
            }

            if (tile.TileFrameX >= 864 && tile.TileFrameX < 1296)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 1260 ? -396 : 36);

                for (int x = topX; x < topX + 2; x++)
                {
                    for (int y = topY; y < topY + 2; y++)
                    {
                        Main.tile[x, y].TileFrameX += frameAdjustment;

                        if (Wiring.running)
                        {
                            Wiring.SkipWire(x, y);
                        }
                    }
                }
            }

            if (tile.TileFrameX >= 1296)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 1692 ? -396 : 36);

                for (int x = topX; x < topX + 2; x++)
                {
                    for (int y = topY; y < topY + 2; y++)
                    {
                        Main.tile[x, y].TileFrameX += frameAdjustment;

                        if (Wiring.running)
                        {
                            Wiring.SkipWire(x, y);
                        }
                    }
                }
            }

            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendTileSquare(-1, topX, topY, 2, 2);
            }
        }

        //public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        //{
        //    Tile tile = Main.tile[i, j];

        //    if (TileObjectData.IsTopLeft(tile))
        //    {
        //        // Makes this tile sway in the wind and with player interaction when used with TileID.Sets.MultiTileSway
        //        Main.instance.TilesRenderer.AddSpecialPoint(i, j, TileDrawing.TileCounterType.MultiTileVine);
        //    }

        //    // We must return false here to prevent the normal tile drawing code from drawing the default static tile. Without this a duplicate tile will be drawn.
        //    return false;
        //}
        public static Vector2 TileOffset => Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

        public static Vector2 TileCustomPosition(int i, int j, Vector2 off = default) => new Vector2(i, j) * 16 - Main.screenPosition - off + TileOffset;

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];

            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

            int height = tile.TileFrameY == 38 ? 18 : 16;

            //spriteBatch.Draw(
            //    TextureAssets.Tile[Type].Value,
            //    new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
            //    new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height),
            //    Lighting.GetColor(i, j));

            spriteBatch.Draw(
                 ModContent.Request<Texture2D>(Texture + "_Overlay").Value,
                 new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                 new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height),
                 Lighting.GetColor(i, j));
        }

        //public override void AdjustMultiTileVineParameters(int i, int j, ref float? overrideWindCycle, ref float windPushPowerX, ref float windPushPowerY, ref bool dontRotateTopTiles, ref float totalWindMultiplier, ref Texture2D glowTexture, ref Color glowColor)
        //{
        //    StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);

        //    switch (style)
        //    {
        //        case StyleID.BannerWhiteFlat: //0
        //        case StyleID.BannerWhitePoint: //1
        //        case StyleID.BannerGrayFlat: //2
        //        case StyleID.BannerGrayPoint: //3
        //        case StyleID.BannerBlackFlat: //4
        //        case StyleID.BannerBlackPoint: //5
        //        case StyleID.BannerPastelFlat: //6
        //        case StyleID.BannerPastelPoint: //7
        //        case StyleID.BannerBrightFlat: //8
        //        case StyleID.BannerBrightPoint: //9
        //        case StyleID.BannerNavyFlat: //10
        //        case StyleID.BannerNavyPoint: //11
        //        case StyleID.BannerPaleFlat: //12
        //        case StyleID.BannerPalePoint: //13
        //        case StyleID.BannerDullFlat: //14
        //        case StyleID.BannerDullPoint: //15
        //        case StyleID.BannerDimFlat: //16
        //        case StyleID.BannerDimPoint:
        //            break;
        //    }
        //}
    }
}