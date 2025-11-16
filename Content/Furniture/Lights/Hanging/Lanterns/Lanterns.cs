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

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.Lanterns
{
    public class Lanterns : ModTile
    {
        public enum StyleID
        {
            Festive, //0
            Heartfelt, //1
        }

        private Asset<Texture2D> flameTexture;

        public override void Load()
        {
            flameTexture = ModContent.Request<Texture2D>(Texture + "_Flame");
        }

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileLavaDeath[Type] = true;

            Main.tileLighted[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

            TileID.Sets.MultiTileSway[Type] = true;
            TileID.Sets.IsAMechanism[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };

            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.StyleWrapLimit = 2;

            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom | AnchorType.PlanterBox, TileObjectData.newTile.Width, 0);

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.PlatformNonHammered, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.DrawYOffset = -8;
            TileObjectData.addAlternate(0);

            TileObjectData.addTile(Type);

            AddMapEntry(new Color(230, 200, 50), Language.GetText("MapObject.Lantern"));
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
            int topY = j - tile.TileFrameY % 36 / 18;

            short frameAdjustment = (short)(tile.TileFrameX >= 18 ? -18 : 18);

            for (int x = topX; x < topX + 1; x++)
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

            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendTileSquare(-1, topX, topY, 1, 2);
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (Main.tile[i, j].TileFrameX / 18 != 0)
            {
                return;
            }

            StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);
            switch (style)
            {
                case StyleID.Festive: //Warm
                    r = 1f;
                    g = .95f;
                    b = .65f;
                    break;

                case StyleID.Heartfelt: //Reddish
                    r = 1f;
                    g = .75f;
                    b = .65f;
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
        //    if (Main.rand.NextBool(40) && tileFrameX < 54)
        //    {
        //        StyleID style = (StyleID)(tileFrameY / 54);
        // The following math makes dust only spawn at the tile coordinates of the flames:
        // ---
        // O-O
        // ---

        //int tileColumn = tileFrameX / 18 % 3;
        //if (tileFrameY / 18 % 3 == 1 && tileColumn != 1)
        //{
        //    int dustChoice;
        //    switch (style)
        //    {
        //        case StyleID.Copper:
        //        case StyleID.Silver:
        //            dustChoice = DustID.Torch;
        //            break;
        //        case StyleID.BorealWood:
        //            dustChoice = DustID.BlueTorch;
        //            break;
        //        default:
        //            dustChoice = -1;
        //            break;
        //    }

        //    if (dustChoice != -1)
        //    {
        //        Dust dust = Dust.NewDustDirect(new Vector2(i * 16, j * 16 + 2), 14, 6, dustChoice, 0f, 0f, 100);
        //        if (Main.rand.NextBool(3))
        //        {
        //            dust.noGravity = true;
        //        }

        //        dust.velocity *= 0.3f;
        //        dust.velocity.Y -= 1.5f;
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

            return false;
        }

        //public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        //{
        //    Tile tile = Main.tile[i, j];
        //    Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

        //    int height = tile.TileFrameY == 18 ? 18 : 16;

        //    spriteBatch.Draw(
        //        TextureAssets.Tile[Type].Value,
        //        new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
        //        new Rectangle(tile.TileFrameX + 6, tile.TileFrameY, 16, height),
        //        Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
        //}

        public override void AdjustMultiTileVineParameters(int i, int j, ref float? overrideWindCycle, ref float windPushPowerX, ref float windPushPowerY, ref bool dontRotateTopTiles, ref float totalWindMultiplier, ref Texture2D glowTexture, ref Color glowColor)
        {
            StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);

            overrideWindCycle = 1f;
            windPushPowerY = 0;

            switch (style)
            {
                case StyleID.Festive: //Default
                case StyleID.Heartfelt:
                    break;

                    //case StyleID.Teak:
                    //    overrideWindCycle = null;
                    //    dontRotateTopTiles = true;
                    //    windPushPowerY = -1f;
                    //    totalWindMultiplier *= 0.5f;
                    //    break;

                    //case StyleID.Heartfelt: //Mildy Stiff/Heavy
                    //    totalWindMultiplier *= 0.8f;
                    //    break;
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
                case StyleID.Festive: //Low flicker
                    tileFlameData.flameCount = 7;
                    tileFlameData.flameColor = new Color(100, 100, 100, 0);
                    tileFlameData.flameRangeXMin = -10;
                    tileFlameData.flameRangeXMax = 11;
                    tileFlameData.flameRangeYMin = -10;
                    tileFlameData.flameRangeYMax = 1;
                    tileFlameData.flameRangeMultX = 0.08f;
                    tileFlameData.flameRangeMultY = 0.08f;
                    break;

                case StyleID.Heartfelt: //Less glow, no flicker
                    tileFlameData.flameCount = 4;
                    tileFlameData.flameColor = new Color(100, 100, 100, 0);
                    tileFlameData.flameRangeXMin = -10;
                    tileFlameData.flameRangeXMax = 11;
                    tileFlameData.flameRangeYMin = -10;
                    tileFlameData.flameRangeYMax = 1;
                    tileFlameData.flameRangeMultX = 0.01f;
                    tileFlameData.flameRangeMultY = 0.01f;
                    break;

                default:
                    tileFlameData.flameCount = 7;
                    tileFlameData.flameColor = new Color(100, 100, 100, 0);
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