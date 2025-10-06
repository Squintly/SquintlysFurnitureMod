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

            Main.tileLighted[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);

            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
            TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
            TileObjectData.newAlternate.AnchorAlternateTiles = new[] { 124, 561, 574, 575, 576, 577, 578 };
            TileObjectData.addAlternate(1);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
            TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
            TileObjectData.newAlternate.AnchorAlternateTiles = new[] { 124, 561, 574, 575, 576, 577, 578 };
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
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX < 66)
            {
                switch (tile.TileFrameY / 22)
                {
                    //warm/flame
                    case 0: //Imperial Candle
                    case 1: //Imperial
                    case 2: //Imperial Glass
                    case 9: //Repaired Candle
                    case 10: //Repaired Glass
                    case 11: //Repaired Thick
                    case 12: //Repaired Candle Silver
                    case 13: //Repaired Glass Silver
                    case 14: //Repaired Thick Silver
                        r = 1f;
                        g = .95f;
                        b = .95f;
                        break;

                    case 3: //Tattered Candle
                    case 4: //Tattered Glass
                    case 5: //Tattered Thick
                    case 6: //Tattered Candle Silver
                    case 7: //Tattered Glass Silver
                    case 8: //Tattered Thick Silver
                        r = 1f;
                        g = .75f;
                        b = .75f;
                        break;

                    default:
                        r = 1f;
                        g = 1f;
                        b = 1f;
                        break;
                }
            }
        }

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
        {
            if (Main.gamePaused || !Main.instance.IsActive || Lighting.UpdateEveryFrame && !Main.rand.NextBool(4))
            {
                return;
            }

            Tile tile = Main.tile[i, j];

            short frameX = tile.TileFrameX;
            short frameY = tile.TileFrameY;

            // Return if the lamp is off (when frameX is 0), or if a random check failed.
            if (frameX != 0 || !Main.rand.NextBool(40))
            {
                return;
            }

            int style = frameY / 1;
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

            switch (tile.TileFrameY / 22)
            {
                //Flame
                case 0: //Imperial Candle
                case 2: //Imperial Glass
                case 3: //Tattered Candle
                case 4: //Tattered Glass
                case 5: //Tattered Thick
                case 6: //Tattered Candle Silver
                case 7: //Tattered Glass Silver
                case 8: //Tattered Thick Silver
                case 9: //Repaired Candle
                case 10: //Repaired Glass
                case 11: //Repaired Thick
                case 12: //Repaired Candle Silver
                case 13: //Repaired Glass Silver
                case 14: //Repaired Thick Silver
                    for (int c = 0; c < 7; c++)
                    {
                        float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                        float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

                        spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
                    }
                    break;

                //Non-flame
                case 1: //Imperial
                    for (int c = 0; c < 4; c++)
                    {
                        float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.05f;
                        float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.05f;

                        spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
                    }
                    break;
            }
        }
    }
}

/* STYLES
0- Imperial Candle
1- Imperial
2- Imperial Glass
3- Tattered Candle
4- Tattered Glass
5- Tattered Thick
6- Tattered Candle Silver
7- Tattered Glass Silver
8- Tattered Thick Silver
9- Repaired Candle
10- Repaired Glass
11- Repaired Thick
12- Repaired Candle Silver
13- Repaired Glass Silver
14- Repaired Thick Silver
*/