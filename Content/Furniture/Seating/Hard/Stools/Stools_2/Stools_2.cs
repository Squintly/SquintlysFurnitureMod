using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Furniture.Seating.Hard.Stools.Stools_2
{
    public class Stools_2 : ModTile
    {
        public enum StyleID
        {
            WoodenStool, //0
            EbonwoodStool, //1
            ShadewoodStool, //2
            MahoganyStool, //3
            PearlwoodStool, //4
            LivingwoodStool, //5
            CactusStool, //6
            BlueDungeonStool, //7,
            GreenDungeonStool, //8
            PinkDungeonStool, //9
            SkywareStool, //10
            LihzahrdStool, //11
            SpookyStool, //12
            GlassStool, //13
            HoneyStool, //14
            FleshStool, //15
            GoldenStool, //16
            ObsidianStool, //17
            MushroomStool, //18
            BoneStool, //19
            SteampunkStool, //20
            PumpkinStool, //21
            PalmStool, //22
            BorealStool, //23
            SlimeStool, //24
            FrozenStool, //25
            DynastyStool, //26
            MartianStool, //27
            MeteoriteStool, //28
            GraniteStool, //29
            MarbleStool, //30
            CrystalStool, //31
            SpiderStool, //32
            LesionStool, //33
            SandstoneStool, //34
            BambooStool, //35
            ReefStool, //36
            BalloonStool, //37
            AshwoodStool, //38
            VortexStool, //39
            StardustStool, //40
            NebulaStool, //41
            SolarStool, //42
            StoneBrickStool, //43
            RedBrickStool, //44
        }

        public const int NextStyleHeight = 34;

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            Main.tileLavaDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;

            TileID.Sets.CanBeSatOnForNPCs[Type] = true;
            TileID.Sets.CanBeSatOnForPlayers[Type] = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            AdjTiles = new int[] { TileID.Chairs };

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new[] { 32 };
            TileObjectData.newTile.CoordinateWidth = 32;
            TileObjectData.newTile.DrawYOffset = -14;

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 4;
            TileObjectData.newTile.StyleMultiplier = 4;
            TileObjectData.newTile.RandomStyleRange = 2;

            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(2);

            TileObjectData.addTile(Type);
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return settings.player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance); // Avoid being able to trigger it from long range
        }

        public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info)
        {
            Tile tile = Framing.GetTileSafely(i, j);

            info.TargetDirection = -1;
            if (tile.TileFrameX >= 68)
            {
                info.TargetDirection = 1; // Facing right if sat down on the right alternate (added through addAlternate in SetStaticDefaults earlier)
            }

            info.AnchorTilePosition.X = i;
            info.AnchorTilePosition.Y = j;
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;

            if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            { // Avoid being able to trigger it from long range
                player.GamepadEnableGrappleCooldown();
                player.sitting.SitDown(player, i, j);
            }

            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            if (!player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            { // Match condition in RightClick. Interaction should only show if clicking it does something
                return;
            }

            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            int style = TileObjectData.GetTileStyle(Main.tile[i, j]);
            player.cursorItemIconID = TileLoader.GetItemDropFromTypeAndStyle(Type, style);

            if (Main.tile[i, j].TileFrameX / 68 < 1)
            {
                player.cursorItemIconReversed = true;
            }
        }
        public static Vector2 TileOffset => Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

        public static Vector2 TileCustomPosition(int i, int j, Vector2 off = default) => new Vector2(i, j) * 16 - Main.screenPosition - off + TileOffset;

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            
            if (!TileDrawing.IsVisible(tile))
            {
                return;
            }

            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

            int width = 32;
            int height = 32;
            int frameX = tile.TileFrameX;
			int frameY = tile.TileFrameY;
            int offsetY = 14;

            spriteBatch.Draw(
                 ModContent.Request<Texture2D>(Texture + "_Overlay").Value,
                 new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f, j * 16 - (int)Main.screenPosition.Y - offsetY) + zero,
                 new Rectangle(frameX, frameY, width, height),
                 Lighting.GetColor(i, j));
        }
    }
}