﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using ReLogic.Content;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.SetExtras
{
    public class KingBed4x4Lighted : ModTile
    {
        public const int NextStyleHeight = 74; //Calculated by adding all CoordinateHeights + CoordinatePaddingFix.Y applied to all of them + 2
        private Asset<Texture2D> flameTexture;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.CanBeSleptIn[Type] = true; // Facilitates calling ModifySleepingTargetInfo
            TileID.Sets.InteractibleByNPCs[Type] = true; // Town NPCs will palm their hand at this tile
            TileID.Sets.IsValidSpawnPoint[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;

            Main.tileLighted[Type] = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair); // Beds count as chairs for the purpose of suitable room creation

            AdjTiles = new int[] { TileID.Beds };
            AdjTiles = new int[] { TileID.Torches };

            TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2); // this style already takes care of direction for us
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 18 };
            TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, -2);

            TileObjectData.newTile.StyleLineSkip = 2;

            TileObjectData.addTile(Type);

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

            AddMapEntry(new Color(191, 142, 111), Language.GetText("ItemName.Bed"));

            if (!Main.dedServ)
            {
                flameTexture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Tiles/Furniture/SetExtras/KingBeds4x4Lighted_Flame"); // We could also reuse Main.FlameTexture[] textures, but using our own texture is nice.
            }
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return true;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX == 0)
            {
                switch (tile.TileFrameY / 72)
                {
                    case 1: // Livingwood
                        r = 1f;
                        g = 1f;
                        b = 0.6f;
                        break;

                    case 2: // Pumpkin
                        r = 1f;
                        g = 1f;
                        b = 1f;
                        break;

                    case 3: // Sandstone
                        r = 1f;
                        g = 0.95f;
                        b = 0.65f;
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

            int style = frameY / 36;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            SpriteEffects effects = SpriteEffects.None;

            if (i % 2 == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }

            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

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

            if (frame == 0) // Livingwood
            {
                for (int c = 0; c < 8; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.1f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 11) * 0.1f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(75, 75, 75, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 4) // Pumpkin
            {
                for (int c = 0; c < 7; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
                }
            }
            else if (frame == 4) // Sandstone
            {
                for (int c = 0; c < 7; c++)
                {
                    float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                    float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

                    spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
                }
            }
        }

    public override void ModifySmartInteractCoords(ref int width, ref int height, ref int frameWidth, ref int frameHeight, ref int extraY)
        {
            // Because beds have special smart interaction, this splits up the left and right side into the necessary 2x2 sections
            width = 2; // Default to the Width defined for TileObjectData.newTile
            height = 4; // Default to the Height defined for TileObjectData.newTile
            extraY = 2;            //extraY = 0; // Depends on how you set up frameHeight and CoordinateHeights and CoordinatePaddingFix.Y
        }

        public override void ModifySleepingTargetInfo(int i, int j, ref TileRestingInfo info)
        {
            // Default values match the regular vanilla bed
            // You might need to mess with the info here if your bed is not a typical 4x2 tile
            info.VisualOffset.Y += 4f; // Move player down a notch because the bed is not as high as a regular bed
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            int spawnX = (i - (tile.TileFrameX / 36)) + (tile.TileFrameX >= 72 ? 5 : 2);
            int spawnY = j + 2;

            if (tile.TileFrameY % NextStyleHeight != 0)
            {
                spawnY--;
            }

            if (!Player.IsHoveringOverABottomSideOfABed(i, j))
            { // This assumes your bed is 4x2 with 2x2 sections. You have to write your own code here otherwise
                if (player.IsWithinSnappngRangeToTile(i, j, PlayerSleepingHelper.BedSleepingMaxDistance))
                {
                    player.GamepadEnableGrappleCooldown();
                    player.sleeping.StartSleeping(player, i, j);
                }
            }
            else
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

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            if (!Player.IsHoveringOverABottomSideOfABed(i, j))
            {
                if (player.IsWithinSnappngRangeToTile(i, j, PlayerSleepingHelper.BedSleepingMaxDistance))
                { // Match condition in RightClick. Interaction should only show if clicking it does something
                    player.noThrow = 2;
                    player.cursorItemIconEnabled = true;
                    player.cursorItemIconID = ItemID.SleepingIcon;
                }
            }
        }
    }
}