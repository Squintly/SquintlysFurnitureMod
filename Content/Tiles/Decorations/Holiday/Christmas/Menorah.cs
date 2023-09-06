using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas
{
    internal class Menorah : ModTile
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
            TileObjectData.newTile.StyleLineSkip = 2;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.addTile(Type);

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

            if (!Main.dedServ)
            {
                flameTexture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Tiles/Decorations/Holiday/Christmas/Menorah_Flame");
            }
        }

        public override void HitWire(int i, int j) 
        {
            Tile tile = Main.tile[i, j];
            int Y = j - Main.tile[i, j].TileFrameY / 18;
         	int X = i - Main.tile[i, j].TileFrameX / 18;
            short frameAdjustment = (short)(tile.TileFrameX > 0 ? -36 : 36);

            Main.tile[X, Y].TileFrameX += frameAdjustment;
            Main.tile[X, Y + 1].TileFrameX += frameAdjustment;
            Main.tile[X + 1, Y].TileFrameX += frameAdjustment;
            Main.tile[X + 1, Y + 1].TileFrameX += frameAdjustment;
            Wiring.SkipWire(X, Y);
         	Wiring.SkipWire(X, Y + 1);
            Wiring.SkipWire(X + 1, Y);
            Wiring.SkipWire(X + 1, Y + 1);

            // Avoid trying to send packets in singleplayer.
            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendTileSquare(-1, i, j + 1, 2, TileChangeType.None);
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX == 0)
            {
                r = 1f;
                g = 1f;
                b = 1f;
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
         			dust.velocity.Y += - 1.5f;
         		}
         	}
         }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            SpriteEffects effects = SpriteEffects.None;

            Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);

            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }

            Tile tile = Main.tile[i, j];
            int width = 34;
            int offsetY = 0;
            int height = 34;
            short frameX = tile.TileFrameX;
            short frameY = tile.TileFrameY;

            TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref frameX, ref frameY);

            ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i);

            for (int c = 0; c < 7; c++)
            {
                float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

                spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
            }
        }
    }
}