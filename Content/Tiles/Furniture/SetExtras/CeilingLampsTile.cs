using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.SetExtras
{
    internal class CeilingLampsTile : ModTile
    {
        private Asset<Texture2D> flameTexture;

        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.WaterDeath = true;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };

            TileObjectData.newTile.StyleLineSkip = 2;
            
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.addTile(Type);

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            AdjTiles = new int[] { TileID.Torches };

            // Assets
            if (!Main.dedServ)
            {
                flameTexture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Tiles/Furniture/SetExtras/CeilingLampsTile_Flame"); // We could also reuse Main.FlameTexture[] textures, but using our own texture is nice.
            }
        }

        public override void HitWire(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            short frameAdjustment = (short)(tile.TileFrameX > 0 ? -18 : 18);

            Main.tile[i, j].TileFrameX += frameAdjustment;
            Wiring.SkipWire(i, j);

            // Avoid trying to send packets in singleplayer.
            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendTileSquare(-1, i, j + 1, 3, TileChangeType.None);
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX == 0)
            {
                switch (tile.TileFrameY / 16)
                {
                    case 1: // blue dungeon
                        r = 0.55f;
                        g = 0.85f;
                        b = 0.35f;
                        break;

                    case 2: // green dungeon
                        r = 0.65f;
                        g = 0.95f;
                        b = 0.5f;
                        break;

                    case 3: // pink dungeon
                        r = 0.2f;
                        g = 0.75f;
                        b = 1f;
                        break;

                    case 5: // ebonwood
                        r = 0.85f;
                        g = 0.6f;
                        b = 1f;
                        break;

                    case 6: // flesh 1
                        r = 1f;
                        g = 0.6f;
                        b = 0.6f;
                        break;

                    case 7: // flesh 2
                        r = 1f;
                        g = 0.6f;
                        b = 0.6f;
                        break;

                    case 8: // glass
                        r = 0.75f;
                        g = 0.85f;
                        b = 1f;
                        break;

                    case 9: // frozen
                        r = 0.75f;
                        g = 0.85f;
                        b = 1f;
                        break;

                    case 10: // mahogany
                        r = 1f;
                        g = 0.95f;
                        b = 0.65f;
                        break;

                    case 11: // pearlwood
                        r = 1f;
                        g = 0.97f;
                        b = 0.85f;
                        break;

                    case 15: // livingwood
                        r = 1f;
                        g = 1f;
                        b = 0.6f;
                        break;

                    case 16: // shadewood
                        r = 1f;
                        g = 0.95f;
                        b = 0.65f;
                        break;

                    case 20: // palmwood
                        r = 1f;
                        g = 0.95f;
                        b = 0.65f;
                        break;

                    case 21: // mushroom
                        r = 0.37f;
                        g = 0.8f;
                        b = 1f;
                        break;

                    case 22: // boreal
                        r = 0f;
                        g = 0.9f;
                        b = 1f;
                        break;

                    case 23: // slime
                        r = 0.25f;
                        g = 0.7f;
                        b = 1f;
                        break;

                    case 25: // steampunk
                        r = 1f;
                        g = 0.95f;
                        b = 0.65f;
                        break;

                    case 26: // spooky
                        r = 1f;
                        g = 0.95f;
                        b = 0.65f;
                        break;

                    case 27: // obsidian
                        r = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
                        g = 0.3f;
                        b = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
                        break;

                    case 30: // granite
                        r = 0.7f;
                        g = 0.6f;
                        b = 0.9f;
                        break;

                    case 31: // marble
                        r = 1f;
                        g = 0.95f;
                        b = 0.65f;
                        break;

                    case 32: // crystal
                        Vector3 vector = Main.hslToRgb(Main.demonTorch * 0.12f + 0.69f, 1f, 0.75f).ToVector3() * 1.2f;
                        r = vector.X;
                        g = vector.Y;
                        b = vector.Z;
                        break;

                    case 33: //spider
                        r = 1f;
                        g = 0.97f;
                        b = 0.85f;
                        break;

                    case 34: // lesion
                        r = 0.55f;
                        g = 0.45f;
                        b = 0.95f;
                        break;

                    case 35: // solar
                        r = 1f;
                        g = 0.6f;
                        b = 0.1f;
                        break;

                    case 36: // vortex
                        r = 0.3f;
                        g = 0.75f;
                        b = 0.55f;
                        break;

                    case 37: // nebula
                        r = 0.9f;
                        g = 0.55f;
                        b = 0.7f;
                        break;

                    case 38: // stardust
                        r = 0.55f;
                        g = 0.85f;
                        b = 1f;
                        break;

                    case 39: // sandstone
                        r = 1f;
                        g = 0.95f;
                        b = 0.65f;
                        break;

                    case 40: // bamboo
                        r = 1f;
                        g = 0.95f;
                        b = 0.65f;
                        break;

                    case 41: // paper
                        r = 1f;
                        g = 0.95f;
                        b = 0.8f;
                        break;

                    case 42: // oil rag
                        r = 0.7f;
                        g = 0.75f;
                        b = 0.3f;
                        break;

                    case 43: // diabolist
                        r = 0.9f;
                        g = 0.4f;
                        b = 0.2f;
                        break;

                    case 44: // alchemy
                        r = 0.5f;
                        g = 0.7f;
                        b = 0.4f;
                        break;

                    case 45: // carriage
                        r = 0.65f;
                        g = 0.5f;
                        b = 0.2f;
                        break;

                    case 46: // caged
                        r = 0.8f;
                        g = 0.6f;
                        b = 0.6f;
                        break;

                    case 47: // brass
                        r = 0.9f;
                        g = 0.75f;
                        b = 0.6f;
                        break;

                    case 48: // chained
                        r = 0.7f;
                        g = 0.65f;
                        b = 0.55f;
                        break;

                    case 49: // ashwood
                        r = 0.95f;
                        g = 0.5f;
                        b = 0.4f;
                        break;

                    case 50: // reef
                        r = 0.4f;
                        g = 0.8f;
                        b = 0.9f;
                        break;

                    default:
                        r = 1f;
                        g = 1f;
                        b = 1f;
                        break;
                }
            }
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
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

            int style = frameY / 18;
            int dustChoice;

            if (style == 0 || style == 10 || style == 12 || style == 20 || style == 31 || style == 42)
            {
                dustChoice = (DustID.Torch);

                var dust = Dust.NewDustDirect(new Vector2(i * 16 + 4, j * 16 + 2), 4, 4, dustChoice, 0f, 0f, 100, default, 1f);
                dust.noGravity = true;
                dust.velocity *= 0.3f;
                dust.velocity.Y += - 1.5f;
            }

            if (style == 27)
            {
                dustChoice = (DustID.DemonTorch);

                var dust = Dust.NewDustDirect(new Vector2(i * 16 + 4, j * 16 + 2), 4, 4, dustChoice, 0f, 0f, 100, default, 1f);
                dust.noGravity = true;
                dust.velocity *= 0.3f;
                dust.velocity.Y += - 1.5f;
            }

            if (style == 34)
            {
                dustChoice = (DustID.CursedTorch);

                var dust = Dust.NewDustDirect(new Vector2(i * 16 + 4, j * 16 + 2), 4, 4, dustChoice, 0f, 0f, 100, default, 1f);
                dust.noGravity = true;
                dust.velocity *= 0.3f;
                dust.velocity.Y += - 1.5f;
            }

            if (style == 22)
            {
                dustChoice = (DustID.IceTorch);

                var dust = Dust.NewDustDirect(new Vector2(i * 16 + 4, j * 16 + 2), 4, 4, dustChoice, 0f, 0f, 100, default, 1f);
                dust.noGravity = true;
                dust.velocity *= 0.3f;
                dust.velocity.Y += - 1.5f;
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            SpriteEffects effects = SpriteEffects.None;

            if (i % 2 == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }

            Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);

            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }

            Tile tile = Main.tile[i, j];
            int width = 16;
            int offsetY = -1;
            int height = 16;
            short frameX = tile.TileFrameX;
            short frameY = tile.TileFrameY;

            TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref frameX, ref frameY);

            ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i); // Don't remove any casts.

            // We can support different flames for different styles here: int style = Main.tile[j, i].frameY / 5
            int frame = frameY / 18;

            if (frame == 0) // normal - not yet set!
            {
                for (int c = 0; c < 7; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 4) // cactus
            {
                for (int c = 0; c < 3; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(50, 50, 50, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 5) // ebonwood
            {
                for (int c = 0; c < 7; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.075f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 11) * 0.075f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(50, 50, 50, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 6) // flesh
            {
                for (int c = 0; c < 3; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.05f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(50, 50, 50, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 8) // glass
            {
                for (int c = 0; c < 7; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.075f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 11) * 0.075f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(50, 50, 50, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 9) // frozen
            {
                for (int c = 0; c < 7; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.05f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 11) * 0.05f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(50, 50, 50, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 13) // shyware
            {
                for (int c = 0; c < 7; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.1f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.15f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(50, 50, 50, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 15) // livingwood
            {
                for (int c = 0; c < 8; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.1f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 11) * 0.1f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(75, 75, 75, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 17) // golden
            {
                for (int c = 0; c < 7; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.075f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 11) * 0.075f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(50, 50, 50, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 29 || frame == 30 ) // granite, meteorite, balloon
            {
                for (int c = 0; c < 1; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(75, 75, 75, 0), 0f, default, 1f, effects, 0f);
                }
            }

            // lihzard, pumpkin, palmwood, boreal, slime, obsidian, marble, lesion, rag sconce, carriage, brass,
            else if (frame == 12 || frame == 14 || frame == 20 || frame == 22 || frame == 23 || frame == 27 || frame == 31 || frame == 34 || frame == 42 || frame == 45 || frame == 47)
            {
                for (int c = 0; c < 7; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 10 || frame == 46) //mahogany, caged
            {
                for (int c = 0; c < 7; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.1f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(50, 50, 50, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 39) //sandstone
            {
                for (int c = 0; c < 7; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 50 || frame == 51) //ashwood, reef
            {
                for (int c = 0; c < 7; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.05f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.05f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
                }
            }


            else
            {
                for (int c = 0; c < 0; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
                }
            }
        }
    }
}