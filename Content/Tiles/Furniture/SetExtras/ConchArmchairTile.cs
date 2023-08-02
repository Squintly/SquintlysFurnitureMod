using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.SetExtras
{
    public class ConchArmchairTile : ModTile
    {
        public const int NextStyleHeight = 40; // Calculated by adding all CoordinateHeights + CoordinatePaddingFix.Y applied to all of them + 2

        public override void SetStaticDefaults()
        {
            // Properties
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            //TileID.Sets.CanBeSatOnForNPCs[Type] = true; // Facilitates calling ModifySittingTargetInfo for NPCs
            //TileID.Sets.CanBeSatOnForPlayers[Type] = true; // Facilitates calling ModifySittingTargetInfo for Players
            TileID.Sets.DisableSmartCursor[Type] = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);

            AdjTiles = new int[] { TileID.Chairs };

            // Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };
            TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            // The following 3 lines are needed if you decide to add more styles and stack them vertically
            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.StyleHorizontal = true;

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1); // Facing right will use the second texture style
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Armchair"));
        }


        //public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) {
        //	return settings.player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance); // Avoid being able to trigger it from long range
        //}

        //public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info) {
        //	// It is very important to know that this is called on both players and NPCs, so do not use Main.LocalPlayer for example, use info.restingEntity
        //	Tile tile = Framing.GetTileSafely(i, j);

        //          info.DirectionOffset = info.RestingEntity is Player ? 6 : 2; // Default to 6 for players, 2 for NPCs

        //          info.TargetDirection = -1;
        //          if (tile.TileFrameX != 0)
        //          {
        //              info.TargetDirection = 1;
        //          }

        //          info.AnchorTilePosition.X++;

        //          info.AnchorTilePosition.Y = j;

        //	if (tile.TileFrameY % NextStyleHeight == 0)
        //          {
        //		info.AnchorTilePosition.Y++;
        //              info.VisualOffset.X = 0.5f;
        //          }
        //}

        //public override bool RightClick(int i, int j) {
        //	Player player = Main.LocalPlayer;

        //	if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance)) { // Avoid being able to trigger it from long range
        //		player.GamepadEnableGrappleCooldown();
        //		player.sitting.SitDown(player, i, j);
        //	}

        //	return true;
        //}

        //public override void MouseOver(int i, int j) {
        //	Player player = Main.LocalPlayer;

        //	if (!player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance)) { // Match condition in RightClick. Interaction should only show if clicking it does something
        //		return;
        //	}

        //	player.noThrow = 2;
        //	player.cursorItemIconEnabled = true;

        //int frameY = j/20;
        //switch (frameY)
        //{
        //    case 0:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.WoodenLawnchair>();
        //        break;
        //    case 1:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.WoodenArmchair>();
        //        break;
        //    case 2:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.EbonwoodArmchair>();
        //        break;
        //    case 3:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.MahoganyArmchair>();
        //        break;
        //    case 4:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.PearlwoodArmchair>();
        //        break;
        //    case 5:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.ShadewoodArmchair>();
        //        break;
        //    case 6:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.BlueDungeonArmchair>();
        //        break;
        //    case 7:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.GreenDungeonArmchair>();
        //        break;
        //    case 8:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.PinkDungeonArmchair>();
        //        break;
        //    case 9:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.GoldenArmchair>();
        //        break;
        //    case 10:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.ObsidianArmchair>();
        //        break;
        //    case 11:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.BoneArmchair>();
        //        break;
        //    case 12:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.CactusArmchair>();
        //        break;
        //    case 13:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.SpookyArmchair>();
        //        break;
        //    case 14:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.SkywareArmchair>();
        //        break;
        //    case 15:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.HoneyArmchair>();
        //        break;
        //    case 16:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.SteampunkArmchair>();
        //        break;
        //    case 17:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.MushroomArmchair>();
        //        break;
        //    case 18:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.BeanbagArmchair>();
        //        break;
        //    case 19:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.GlassArmchair>();
        //        break;
        //    case 20:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.PumpkinArmchair>();
        //        break;
        //    case 21:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.LihzahrdArmchair>();
        //        break;
        //    case 22:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.PalmwoodLawnchair>();
        //        break;
        //    case 23:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.PalmwoodArmchair>();
        //        break;
        //    case 24:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.MushroomLawnchair>();
        //        break;
        //    case 25:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.BorealArmchair>();
        //        break;
        //    case 26:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.SlimeArmchair>();
        //        break;
        //    case 27:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.FleshArmchair>();
        //        break;
        //    case 28:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.FrozenArmchair>();
        //        break;
        //    case 29:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.LivingwoodArmchair>();
        //        break;
        //    case 30:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.MartianArmchair>();
        //        break;
        //    case 31:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.MeteorArmchair>();
        //        break;
        //    case 32:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.GraniteArmchair>();
        //        break;
        //    case 33:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.MarbleArmchair>();
        //        break;
        //    case 34:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.CrystalArmchair>();
        //        break;
        //    case 35:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.DynastyArmchair>();
        //        break;
        //    case 36:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.SpiderArmchair>();
        //        break;
        //    case 37:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.LesionArmchair>();
        //        break;
        //    case 38:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.SolarArmchair>();
        //        break;
        //    case 39:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.VortexArmchair>();
        //        break;
        //    case 40:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.NebulaArmchair>();
        //        break;
        //    case 41:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.StardustArmchair>();
        //        break;
        //    case 42:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.SandstoneArmchair>();
        //        break;
        //    case 43:
        //        player.cursorItemIconID = ModContent.ItemType<Items.Furniture.SetExtras.Armchairs.BambooArmchair>();
        //        break;
        //}
        //if (Main.tile[i, j].TileFrameX / 40 > 1) {
        //	player.cursorItemIconReversed = true;
        //}
    }
}