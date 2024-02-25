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

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Festive
{
    internal class FestiveChandelier : ModTile
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

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 18 };

            TileObjectData.newTile.StyleLineSkip = 2;

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.addTile(Type);

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

            if (!Main.dedServ)
            {
                flameTexture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Tiles/Furniture/NewSets/Holiday/Festive/FestiveChandelier_Flame"); // We could also reuse Main.FlameTexture[] textures, but using our own texture is nice.
            }

            AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Chandelier"));
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
            int topX = i - tile.TileFrameX % 54 / 18; //change first number depending on size
            int topY = j - tile.TileFrameY % 54 / 18;

            short frameAdjustment = (short)(tile.TileFrameX >= 54 ? -54 : 54); //change last two depending on size

            for (int x = topX; x < topX + 3; x++) // change depending on width
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
            Tile tile = Main.tile[i, j];
            r = 1f;
            g = 0.95f;
            b = 0.65f;
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
            //if (frameX != 0 || !Main.rand.NextBool(40))
            //{
            //    return;
            //}

            //int style = frameY / 18;
            //int dustChoice;
            //dustChoice = (DustID.Torch);

            //var dust = Dust.NewDustDirect(new Vector2(i * 16 + 4, j * 16 + 2), 4, 4, dustChoice, 0f, 0f, 100, default, 1f);
            //dust.noGravity = true;
            //dust.velocity *= 0.3f;
            //dust.velocity.Y += - 1.5f;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            var tile = Main.tile[i, j];

            if (!TileDrawing.IsVisible(tile))
            {
                return;
            }

            SpriteEffects effects = SpriteEffects.None;

            Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);

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

            ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (uint)i);

            for (int c = 0; c < 7; c++)
            {
                float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

                spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
            }
        }
    }
}