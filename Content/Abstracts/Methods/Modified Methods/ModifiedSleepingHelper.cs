using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;


namespace SquintlysFurnitureMod.Content.Abstracts.Methods
{

    public class ModifyHover
        {
        public static bool IsHoveringOverABottomSideOfABed3(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            short frameX = tile.TileFrameX;
            bool flag = frameX / 72 == 1 || frameX / 72 == 3 || frameX / 72 == 5;
            bool flag2 = frameX % 72 < 36 || frameX % 72 < 108 || frameX % 72 < 180;
            if (flag)
                flag2 = !flag2;

            return flag2;
        }
    }
    public struct ModifiedSleepingHelper
    {
        public const int BedSleepingMaxDistance = 96;
        public const int TimeToFullyFallAsleep = 120;
        public bool isSleeping;
        public int sleepingIndex;
        public int timeSleeping;
        public Vector2 visualOffsetOfBedBase;

        public bool FullyFallenAsleep
        {
            get
            {
                if (isSleeping)
                    return timeSleeping >= 120;

                return false;
            }
        }

        public void GetSleepingOffsetInfo(Player player, out Vector2 posOffset)
        {
            if (isSleeping)
                posOffset = visualOffsetOfBedBase * player.Directions + new Vector2(0f, (float)sleepingIndex * player.gravDir * -4f);
            else
                posOffset = Vector2.Zero;
        }

        private bool DoesPlayerHaveReasonToActUpInBed(Player player)
        {
            if (NPC.AnyDanger(quickBossNPCCheck: true))
                return true;

            if (Main.bloodMoon && !Main.dayTime)
                return true;

            if (Main.eclipse && Main.dayTime)
                return true;

            if (player.itemAnimation > 0)
                return true;

            return false;
        }

        public void SetIsSleepingAndAdjustPlayerRotation(Player player, bool state)
        {
            if (isSleeping != state)
            {
                isSleeping = state;
                if (state)
                {
                    player.fullRotation = (float)Math.PI / 2f * (float)(-player.direction);
                    return;
                }

                player.fullRotation = 0f;
                visualOffsetOfBedBase = default(Vector2);
            }
        }

        public void UpdateState(Player player)
        {
            if (!isSleeping)
            {
                timeSleeping = 0;
                return;
            }

            timeSleeping++;
            if (DoesPlayerHaveReasonToActUpInBed(player))
                timeSleeping = 0;

            Point coords = (player.Bottom + new Vector2(0f, -2f)).ToTileCoordinates();
            if (!GetSleepingTargetInfo(coords.X, coords.Y, out var targetDirection, out var _, out var visualoffset))
            {
                StopSleeping(player);
                return;
            }

            if (player.controlLeft || player.controlRight || player.controlUp || player.controlDown || player.controlJump || player.pulley || player.mount.Active || targetDirection != player.direction)
                StopSleeping(player);

            bool flag = false;
            if (player.itemAnimation > 0)
            {
                Item heldItem = player.HeldItem;
                if (heldItem.damage > 0 && !heldItem.noMelee)
                    flag = true;

                if (heldItem.fishingPole > 0)
                    flag = true;

                bool? flag2 = ItemID.Sets.ForcesBreaksSleeping[heldItem.type];
                if (flag2.HasValue)
                    flag = flag2.Value;
            }

            if (flag)
                StopSleeping(player);

            if (Main.sleepingManager.GetNextPlayerStackIndexInCoords(coords) >= 2)
                StopSleeping(player);

            if (isSleeping)
            {
                visualOffsetOfBedBase = visualoffset;
                Main.sleepingManager.AddPlayerAndGetItsStackedIndexInCoords(player.whoAmI, coords, out sleepingIndex);
            }
        }

        public void StopSleeping(Player player, bool multiplayerBroadcast = true)
        {
            if (isSleeping)
            {
                SetIsSleepingAndAdjustPlayerRotation(player, state: false);
                timeSleeping = 0;
                sleepingIndex = -1;
                visualOffsetOfBedBase = default(Vector2);
                if (multiplayerBroadcast && Main.myPlayer == player.whoAmI)
                    NetMessage.SendData(13, -1, -1, null, player.whoAmI);
            }
        }

        public void StartSleeping3(Player player, int x, int y)
        {
            GetSleepingTargetInfo3(x, y, out var targetDirection, out var anchorPosition, out var visualoffset);
            Vector2 offset = anchorPosition - player.Bottom;
            bool flag = player.CanSnapToPosition(offset);
            if (flag)
                flag &= Main.sleepingManager.GetNextPlayerStackIndexInCoords((anchorPosition + new Vector2(0f, -2f)).ToTileCoordinates()) < 2;

            if (!flag)
                return;

            if (isSleeping && player.Bottom == anchorPosition)
            {
                StopSleeping(player);
                return;
            }

            player.StopVanityActions();
            player.RemoveAllGrapplingHooks();
            player.RemoveAllFishingBobbers();
            if (player.mount.Active)
                player.mount.Dismount(player);

            player.Bottom = anchorPosition;
            player.ChangeDir(targetDirection);
            Main.sleepingManager.AddPlayerAndGetItsStackedIndexInCoords(player.whoAmI, new Point(x, y), out sleepingIndex);
            player.velocity = Vector2.Zero;
            player.gravDir = 1f;
            SetIsSleepingAndAdjustPlayerRotation(player, state: true);
            visualOffsetOfBedBase = visualoffset;
            if (Main.myPlayer == player.whoAmI)
                NetMessage.SendData(13, -1, -1, null, player.whoAmI);
        }

        public static bool GetSleepingTargetInfo3(int x, int y, out int targetDirection, out Vector2 anchorPosition, out Vector2 visualoffset)
        {
            Tile tileSafely = Framing.GetTileSafely(x, y);
            if (!TileID.Sets.CanBeSleptIn[tileSafely.type] || !tileSafely.active())
            {
                targetDirection = 1;
                anchorPosition = default(Vector2);
                visualoffset = default(Vector2);
                return false;
            }

            int num = y;
            int num2 = x - tileSafely.TileFrameX % 72 / 18;
            if (tileSafely.TileFrameX % 36 != 0)
                num--;

            targetDirection = 1;
            int num3 = tileSafely.TileFrameX / 72;
            int num4 = num2;
            switch (num3)
            {
                case 0:
                    targetDirection = -1;
                    num4++;
                    break;
                case 1:
                    num4 += 2;
                    break;
            }

            visualoffset = SetOffsetbyBed(tileSafely.frameY / 36);

            TileRestingInfo info = new TileRestingInfo(null, new Point(num4, num), visualoffset, targetDirection);
            TileLoader.ModifySleepingTargetInfo(x, y, tileSafely.type, ref info);
            num4 = info.AnchorTilePosition.X;
            num = info.AnchorTilePosition.Y;
            int directionOffset = info.DirectionOffset;
            targetDirection = info.TargetDirection;
            visualoffset = info.VisualOffset;
            Vector2 finalOffset = info.FinalOffset;

            anchorPosition = new Point(num4, num + 1).ToWorldCoordinates(8f, 16f); // Reordered so that anchorPosition is modifiable
            anchorPosition.X += targetDirection * directionOffset; // Added to match PlayerSittingHelper
            anchorPosition += finalOffset; // Added to match PlayerSittingHelper
            return true;
        }
    }
}
