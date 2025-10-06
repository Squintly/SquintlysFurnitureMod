using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Furniture.Bedroom.Beds.ThreeTall.Six
{
    public abstract class Beds_3Tall_6 : ModTile
    {
        public const int NextStyleHeight = 56;

        public override sealed void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            Main.tileLavaDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            AdjTiles = new int[] { TileID.Beds };

            TileID.Sets.CanBeSleptIn[Type] = true;
            TileID.Sets.InteractibleByNPCs[Type] = true;
            TileID.Sets.IsValidSpawnPoint[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
            TileObjectData.newTile.Height = 3;

            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };
            TileObjectData.newTile.Origin = new Point16(1, 1);

            TileObjectData.newTile.StyleHorizontal = false;
            TileObjectData.newTile.StyleWrapLimit = 6;
            TileObjectData.newTile.StyleMultiplier = 12;
            TileObjectData.newTile.RandomStyleRange = 6;

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(6);

            TileObjectData.addTile(Type);
        }

        public virtual void SafeSetStaticDefaults()
        {
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return true;
        }

        public override void ModifySmartInteractCoords(ref int width, ref int height, ref int frameWidth, ref int frameHeight, ref int extraY)
        {
            width = 4;
            height = 3;
            extraY = 1;
        }

        public override void ModifySleepingTargetInfo(int i, int j, ref TileRestingInfo info)
        {
            info.VisualOffset.Y += 0f;
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            int spawnX = i - tile.TileFrameX / 18 + (tile.TileFrameX >= 58 ? 5 : 2);
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
            else
            {
                player.noThrow = 2;
                player.cursorItemIconEnabled = true;
                int style = TileObjectData.GetTileStyle(Main.tile[i, j]);
                player.cursorItemIconID = TileLoader.GetItemDropFromTypeAndStyle(Type, style);
            }
        }
    }

    public class TatteredCanopyBeds : Beds_3Tall_6
    {
        public override void SafeSetStaticDefaults()
        {
        }
    }

    public class RepairedCanopyBeds : Beds_3Tall_6
    {
        public override void SafeSetStaticDefaults()
        {
        }
    }
}