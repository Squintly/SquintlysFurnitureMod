using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.CeilingLamps.CeilingLamps_2.Items;
using SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.TrackLights.TrackLights_3.Items;
using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Halloween.Alchemy.Other;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.CeilingLamps.CeilingLamps_4
{
    internal class CeilingLamps_4 : ModTile
    {
        public enum StyleID
        {
            TatteredCeilingLamp, //0
            RepairedCeilingLamp, //1
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

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.DrawYOffset = 0;
            TileObjectData.newTile.CoordinateHeights = new int[1] { 32 };
            TileObjectData.newTile.CoordinateWidth = 32;
            TileObjectData.newTile.Origin = new Point16(0, 0);

            //TileObjectData.newTile.DrawXOffset = 60;

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 8;
            TileObjectData.newTile.StyleMultiplier = 8;
            TileObjectData.newTile.RandomStyleRange = 4;

            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom | AnchorType.PlanterBox, TileObjectData.newTile.Width, 0);

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.PlatformNonHammered, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.DrawYOffset = -8;
            TileObjectData.addAlternate(0);

            TileObjectData.addTile(Type);

            AddMapEntry(new Color(230, 200, 50), Language.GetText("MapObject.CeilingLamp"));
        }
        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            Tile t = Main.tile[i, j];
            int style = t.TileFrameY / 34;
            yield return new Item(Mod.Find<ModItem>(CeilingLamps_2_Items.GetInternalNameFromStyle(style)).Type);
            yield return new Item(Mod.Find<ModItem>(CeilingLamps_2_Items.GetInternalNameFromStyle(style)).Type);
            yield return new Item(Mod.Find<ModItem>(TrackLights_3_Items.GetInternalNameFromStyle(style)).Type);
            yield return new Item(Mod.Find<ModItem>(TrackLights_3_Items.GetInternalNameFromStyle(style)).Type);
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
            int topX = i - tile.TileFrameX % 34 / 34;
            int topY = j - tile.TileFrameY % 34 / 34;

            short frameAdjustment = (short)(tile.TileFrameX >= 136 ? -136 : 136);

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
            if (Main.tile[i, j].TileFrameX / 136 != 0)
            {
                return;
            }

            StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);
            switch (style)
            {
                case StyleID.TatteredCeilingLamp:
                    r = 1f;
                    g = .75f;
                    b = .65f;
                    break;

                case StyleID.RepairedCeilingLamp: //Yellowy
                    r = 1f;
                    g = .85f;
                    b = .85f;
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

        //    if (Main.rand.NextBool(40) && tileFrameX / 136 != 0)
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

            return false;
        }
        public override void AdjustMultiTileVineParameters(int i, int j, ref float? overrideWindCycle, ref float windPushPowerX, ref float windPushPowerY, ref bool dontRotateTopTiles, ref float totalWindMultiplier, ref Texture2D glowTexture, ref Color glowColor)
        {
            var tile = Main.tile[i, j];

            short frameX = tile.TileFrameX;
            short frameY = tile.TileFrameY;

            StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);

            overrideWindCycle = 1f;
            windPushPowerY = 0;

            switch (style)
            {
                case StyleID.TatteredCeilingLamp: //Default
                case StyleID.RepairedCeilingLamp:
                    if (frameX < 68 | frameX > 136 & frameX < 204)
                    {
                        totalWindMultiplier *= 0.8f;
                    }
                    else
                    {
                        overrideWindCycle = 0f;
                    }
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
                case StyleID.TatteredCeilingLamp: //Dim, small medium flicker
                    tileFlameData.flameCount = 1;
                    tileFlameData.flameColor = new Color(100, 100, 100, 0);
                    tileFlameData.flameRangeXMin = -5;
                    tileFlameData.flameRangeXMax = 6;
                    tileFlameData.flameRangeYMin = -5;
                    tileFlameData.flameRangeYMax = 1;
                    tileFlameData.flameRangeMultX = 0.1f;
                    tileFlameData.flameRangeMultY = 0.1f;
                    break;

                case StyleID.RepairedCeilingLamp: //Medium glow, no flicker
                    tileFlameData.flameCount = 1;
                    tileFlameData.flameColor = new Color(100, 100, 100, 0);
                    tileFlameData.flameRangeXMin = -5;
                    tileFlameData.flameRangeXMax = 6;
                    tileFlameData.flameRangeYMin = -5;
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