using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.KingBeds;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.SetExtras.KingBeds
{
    public class KingBedBalloon : ModTile
    {
        public const int NextStyleHeight = 108;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true; // Facilitates calling ModifySleepingTargetInfo
            TileID.Sets.InteractibleByNPCs[Type] = true; // Town NPCs will palm their hand at this tile
            TileID.Sets.IsValidSpawnPoint[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair); // Beds count as chairs for the purpose of suitable room creation

            AdjTiles = new int[] { TileID.Beds };

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 6;
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16, 16, 18 };
            TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, -2);

            TileObjectData.addTile(Type);

            AnimationFrameHeight = 108;
            RegisterItemDrop(ModContent.ItemType<KingBedBalloonLarge>());
            AddMapEntry(new Color(191, 142, 111), Language.GetText("ItemName.Bed"));
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter >= 16)
            {
                frameCounter = 0;
                frame++;
                frame %= 4;
            }
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return true;
        }

        public override void ModifySmartInteractCoords(ref int width, ref int height, ref int frameWidth, ref int frameHeight, ref int extraY)
        {
            // Because beds have special smart interaction, this splits up the left and right side into the necessary 2x2 sections
            width = 4; // Default to the Width defined for TileObjectData.newTile
            height = 6; // Default to the Height defined for TileObjectData.newTile
            extraY = 4;            //extraY = 0; // Depends on how you set up frameHeight and CoordinateHeights and CoordinatePaddingFix.Y
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            int spawnX = i - tile.TileFrameX / 18 + (tile.TileFrameX >= 108 ? 5 : 2);
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
        //}
    }
}