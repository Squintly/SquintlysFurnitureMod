﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered
{
	// This class shows off many things common to Lamp tiles in Terraria. The process for creating this example is detailed in: https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#examplelamp-tile
	// If you can't figure out how to recreate a vanilla tile, see that guide for instructions on how to figure it out yourself.
	internal class TatteredCandelabraTile : ModTile
	{
		private Asset<Texture2D> flameTexture;

		public override void SetStaticDefaults() {
			// Properties
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileWaterDeath[Type] = true;
			Main.tileLavaDeath[Type] = true;
			// Main.tileFlame[Type] = true; // This breaks it.

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.WaterDeath = true;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.addTile(Type);

			// Etc
			AddMapEntry(new Color(200, 200, 200), Language.GetText("Tattered Candelabra"));

			// Assets
			if (!Main.dedServ) {
				flameTexture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Tiles/Furniture/NewSets/Tattered/TatteredCandelabraTile_Flame"); // We could also reuse Main.FlameTexture[] textures, but using our own texture is nice.
			}
		}

        public override void KillMultiTile(int x, int y, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, ModContent.ItemType<Items.Furniture.NewSets.Tattered.TatteredCandelabraItem>());
        }
		
  //      public override void HitWire(int i, int j) {
  //          Tile tile = Main.tile[i, j];
  //          int Y = j - Main.tile[i, j].TileFrameY / 18;
		//	int X = i - Main.tile[i, j].TileFrameX / 18;
  //          short frameAdjustment = (short)(tile.TileFrameX > 0 ? -36 : 36);

  //          Main.tile[X, Y].TileFrameX += frameAdjustment;
  //          Main.tile[X, Y + 1].TileFrameX += frameAdjustment;
  //          Main.tile[X + 1, Y].TileFrameX += frameAdjustment;
  //          Main.tile[X + 1, Y + 1].TileFrameX += frameAdjustment;
  //          Wiring.SkipWire(X, Y);
		//	Wiring.SkipWire(X, Y + 1);
  //          Wiring.SkipWire(X + 1, Y);
  //          Wiring.SkipWire(X + 1, Y + 1);

  //          // Avoid trying to send packets in singleplayer.
  //          if (Main.netMode != NetmodeID.SinglePlayer)
  //          {
  //              NetMessage.SendTileSquare(-1, i, j + 1, 2, TileChangeType.None);
  //          }
		//}

		//public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects) {
		//	if (i % 2 == 1) {
		//		spriteEffects = SpriteEffects.FlipHorizontally;
		//	}
		//}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			Tile tile = Main.tile[i, j];
			if (tile.TileFrameX == 0) {
                // We can support different light colors for different styles here: switch (tile.frameY / 54)
                r = 0.8f;
                g = 0.75f;
                b = 0.7f;
            }
		}

		//public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData) {
		//	if (Main.gamePaused || !Main.instance.IsActive || Lighting.UpdateEveryFrame && !Main.rand.NextBool(4)) {
		//		return;
		//	}

		//	Tile tile = Main.tile[i, j];

		//	short frameX = tile.TileFrameX;
		//	short frameY = tile.TileFrameY;

		//	// Return if the lamp is off (when frameX is 0), or if a random check failed.
		//	if (frameX != 0 || !Main.rand.NextBool(40)) {
		//		return;
		//	}

		//	int style = frameY / 54;

		//	if (frameY / 36 % 3 == 0) {
		//		int dustChoice = -1;

		//		if (style == 0) {
		//			dustChoice = (DustID.Torch); 
		//		}

		//		// We can support different dust for different styles here
		//		if (dustChoice != -1) {
		//			var dust = Dust.NewDustDirect(new Vector2(i * 16 + 4, j * 16 + 2), 4, 4, dustChoice, 0f, 0f, 100, default, 1f);

		//			if (!Main.rand.NextBool(3)) {
		//				dust.noGravity = true;
		//			}

		//			dust.velocity *= 0.3f;
		//			dust.velocity.Y = dust.velocity.Y - 1.5f;
		//		}
		//	}
		//}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch) {
			SpriteEffects effects = SpriteEffects.None;

			//if (i % 2 == 1) {
			//	effects = SpriteEffects.FlipHorizontally;
			//}

			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

			if (Main.drawToScreen) {
				zero = Vector2.Zero;
			}

			Tile tile = Main.tile[i, j];
			int width = 34;
			int offsetY = 0;
			int height = 34;
			short frameX = tile.TileFrameX;
			short frameY = tile.TileFrameY;

			TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref frameX, ref frameY);

			ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i); // Don't remove any casts.

			// We can support different flames for different styles here: int style = Main.tile[j, i].frameY / 54;
			for (int c = 0; c < 2; c++) {
				float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.0f;
				float shakeY = Utils.RandomInt(ref randSeed, -10, 10) * 0.07f;

				spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
			}
		}
	}
}