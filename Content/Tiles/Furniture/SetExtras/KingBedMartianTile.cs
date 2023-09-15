using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.KingBeds;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.SetExtras
{
    public class KingBedMartianTile : ModTile
    {
        public const int NextStyleHeight = 38;
        private Asset<Texture2D> flameTexture;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            Main.tileLavaDeath[Type] = true;

            Main.tileLighted[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            AdjTiles = new int[] { TileID.Torches };
            AdjTiles = new int[] { TileID.Beds };

            TileID.Sets.CanBeSleptIn[Type] = true;
            TileID.Sets.InteractibleByNPCs[Type] = true;
            TileID.Sets.IsValidSpawnPoint[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;

            TileID.Sets.InteractibleByNPCs[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
            TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.addTile(Type);

            AddMapEntry(new Color(191, 142, 111), Language.GetText("ItemName.Bed"));

            if (!Main.dedServ)
            {
                flameTexture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Tiles/Furniture/SetExtras/KingBedMartianTile_Flame"); // We could also reuse Main.FlameTexture[] textures, but using our own texture is nice.
            }
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return true;
        }

        public override void ModifySmartInteractCoords(ref int width, ref int height, ref int frameWidth, ref int frameHeight, ref int extraY)
        {
            width = 4;
            height = 2;
        }

        //public override void ModifySleepingTargetInfo(int i, int j, ref TileRestingInfo info)
        //{
        //    info.VisualOffset.Y += 0f;
        //}

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            int spawnX = (i - (tile.TileFrameX / 18)) + (tile.TileFrameX >= 72 ? 5 : 2);
            int spawnY = j + 2;

            if (tile.TileFrameY % NextStyleHeight != 0)
            {
                spawnY--;
            }

            {
                player.FindSpawn();

                if (player.SpawnX == spawnX && player.SpawnY == spawnY)
                {
                    player.RemoveSpawn();
                    Main.NewText(Language.GetTextValue("Game.SpawnPointRemoved"), byte.MaxValue, 240, 20);
                }
                else if (Player.CheckSpawn(spawnX, spawnY))
                {
                    player.ChangeSpawn(spawnX, spawnY);
                    Main.NewText(Language.GetTextValue("Game.SpawnPointSet"), byte.MaxValue, 240, 20);
                }
            }

            return true;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX == 0)
            {
                // We can support different light colors for different styles here: switch (tile.frameY / 54)
                r = 0.5f;
                g = 0.7f;
                b = 0.5f;
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

            //Return if the lamp is off (when frameX is 0), or if a random check failed.
            if (frameX != 0 || !Main.rand.NextBool(40))
            {
                return;
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            SpriteEffects effects = SpriteEffects.None;

            //if (i % 2 == 1)
            //{
            //    effects = SpriteEffects.FlipHorizontally;
            //}

            Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);

            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }

            Tile tile = Main.tile[i, j];
            int width = 18;
            int offsetY = 0;
            int height = 18;
            short frameX = tile.TileFrameX;
            short frameY = tile.TileFrameY;

            TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref frameX, ref frameY);

            ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i); // Don't remove any casts.

            // We can support different flames for different styles here: int style = Main.tile[j, i].frameY / 54;
            for (int c = 0; c < 4; c++)
            {
                float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.01f;
                float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.01f;

                spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
            }
        }
    }



    //public override void HitWire(int i, int j)
    //{
    //    Tile tile = Main.tile[i, j];
    //    int topY = j - tile.TileFrameY / 18 % 2;
    //    short frameAdjustment = (short)(tile.TileFrameX > 0 ? -72 : 72);

    //    Main.tile[i, topY].TileFrameX += frameAdjustment;
    //    Main.tile[i, topY + 1].TileFrameX += frameAdjustment;

    //    Wiring.SkipWire(i, topY);
    //    Wiring.SkipWire(i + 1, topY);
    //    Wiring.SkipWire(i + 2, topY);
    //    Wiring.SkipWire(i + 3, topY);
    //    Wiring.SkipWire(i, topY + 1);
    //    Wiring.SkipWire(i + 1, topY + 1);
    //    Wiring.SkipWire(i + 2, topY);
    //    Wiring.SkipWire(i + 3, topY + 1);


    //    if (Main.netMode != NetmodeID.SinglePlayer)
    //    {
    //        NetMessage.SendTileSquare(-1, i, topY + 1, 2, TileChangeType.None);
    //    }
    //}

    //public override void MouseOver(int i, int j)
    //{
    //    Player player = Main.LocalPlayer;

    //    if (!Player.IsHoveringOverABottomSideOfABed(i, j))
    //    {
    //        if (player.IsWithinSnappngRangeToTile(i, j, PlayerSleepingHelper.BedSleepingMaxDistance))
    //        { // Match condition in RightClick. Interaction should only show if clicking it does something
    //            player.noThrow = 2;
    //            player.cursorItemIconEnabled = true;
    //            player.cursorItemIconID = ItemID.SleepingIcon;
    //        }
    //    }
    //    else
    //    {
    //        player.noThrow = 2;
    //        player.cursorItemIconEnabled = true;
    //        //player.cursorItemIconID = ModContent.ItemType<KingBedMartian>();
    //    }
    //}
}