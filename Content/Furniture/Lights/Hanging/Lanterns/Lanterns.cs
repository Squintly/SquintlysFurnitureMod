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
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.Lanterns
{
    internal class Lanterns : ModTile
    {
        private Asset<Texture2D> flameTexture;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            Main.tileLavaDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;
            //TileID.Sets.MultiTileSway[Type] = true;

            Main.tileLighted[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            AdjTiles = new int[] { TileID.Torches };

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.CoordinateWidth = 30;

            TileObjectData.newTile.Origin = Point16.Zero;

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleLineSkip = 2;

            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom | AnchorType.PlanterBox, TileObjectData.newTile.Width, 0);

            //TileObjectData.newTile.DrawYOffset = -2;

            //TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            //TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.Platform, TileObjectData.newTile.Width, 0);
            //TileObjectData.newAlternate.DrawYOffset = -10;
            //TileObjectData.addAlternate(0);

            TileObjectData.addTile(Type);

            if (!Main.dedServ)
            {
                flameTexture = ModContent.Request<Texture2D>(Texture + "_Flame");
            }
        }

        //public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        //{
        //    Tile tile = Main.tile[i, j];

        //    //if (TileObjectData.IsTopLeft(tile))
        //    //{
        //    //    // Makes this tile sway in the wind and with player interaction when used with TileID.Sets.MultiTileSway
        //    //    Main.instance.TilesRenderer.AddSpecialPoint(i, j, TileDrawing.TileCounterType.MultiTileVine);
        //    //}

        //    // We must return false here to prevent the normal tile drawing code from drawing the default static tile. Without this a duplicate tile will be drawn.
        //    return true;
        //}

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
            int topX = i - tile.TileFrameX % 32 / 32;
            int topY = j - tile.TileFrameY % 36 / 18;

            short frameAdjustment = (short)(tile.TileFrameX >= 32 ? -32 : 32);

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
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX == 0)
            {
                switch (tile.TileFrameY / 36)
                {
                    case 0:
                        r = 1f;
                        g = 1f;
                        b = 1f;
                        break;
                }
            }
        }

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
        {
            var tile = Main.tile[i, j];

            if (!TileDrawing.IsVisible(tile))
            {
                return;
            }

            if (Main.gamePaused || !Main.instance.IsActive || Lighting.UpdateEveryFrame && !Main.rand.NextBool(4))
            {
                return;
            }

            short frameX = tile.TileFrameX;
            short frameY = tile.TileFrameY;

            if (frameX != 0 || !Main.rand.NextBool(40))
            {
                return;
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

            Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);

            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }

            int width = 32;
            int offsetY = 0;
            int height = 36;
            short frameX = tile.TileFrameX;
            short frameY = tile.TileFrameY;

            TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref frameX, ref frameY);

            ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (uint)i); // Don't remove any casts.

            // We can support different flames for different styles here: int style = Main.tile[j, i].frameY / 54;
            switch (tile.TileFrameY / 36)
            {
                case 0:
                    for (int c = 0; c < 7; c++)
                    {
                        float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                        float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

                        spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
                    }
                    break;
            }
        }
    }
}

/*STYLES
 0- Imperial
*/