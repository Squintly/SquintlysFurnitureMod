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

namespace SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Chaises.Chaises_1
{
    [LegacyName("Chaises")]
    public class Chaises_1 : ModTile
    {
        public enum StyleID
        {
            CinderblockChaise, //0
            StoneBrickChaise, //1
            RedBrickChaise, //2
        }

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

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);

            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[1] { 32 };
            TileObjectData.newTile.DrawYOffset = -14;
            TileObjectData.newTile.Origin = new Point16(0, 0);

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.newTile.StyleHorizontal = true;

            TileObjectData.addTile(Type);
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            int frameX = tile.TileFrameX;
            int frameY = tile.TileFrameY;

            int direction = info.TargetDirection = info.RestingEntity.direction;

            info.AnchorTilePosition.X = i;
            info.AnchorTilePosition.Y = j;

            //switch (frameY / 38)
            //{
            //    case 0:
            //    case 1:
            //        info.VisualOffset.Y += 1;
            //        if (frameX == 18)
            //        {
            //            info.VisualOffset.X -= 4;
            //        }
            //        else if ((frameX == 0 && direction == -1) ||
            //                 (frameX == 36 && direction == 1))
            //        {
            //            info.VisualOffset.X -= 8;
            //        }
            //        break;
            //    case 2:
            //        if (frameX == 18)
            //        {
            //            info.VisualOffset.X -= 4;
            //        }
            //        else if ((frameX == 0 && direction == -1) ||
            //                 (frameX == 36 && direction == 1))
            //        {
            //            info.VisualOffset.Y -= 4;
            //            info.VisualOffset.X -= 4;
            //        }
            //        else
            //        {
            //            info.VisualOffset.Y -= 4;
            //            info.VisualOffset.X -= 6;
            //        }
            //        break;
            //    case 3:
            //        info.VisualOffset.Y += 1;
            //        if (direction == 1) info.VisualOffset.X -= 2;
            //        if (frameX == 18)
            //        {
            //            info.VisualOffset.X -= 4;
            //        }
            //        else if ((frameX == 0 && direction == -1) ||
            //                 (frameX == 36 && direction == 1))
            //        {
            //            info.VisualOffset.X -= 8;
            //        }
            //        break;
            //    case 4:
            //        info.VisualOffset.Y += 2;
            //        if (direction == 1) info.VisualOffset.X -= 2;
            //        if (frameX == 18)
            //        {
            //            info.VisualOffset.X -= 4;
            //            info.VisualOffset.Y -= 1;
            //        }
            //        else if ((frameX == 0 && direction == -1) ||
            //                 (frameX == 36 && direction == 1))
            //        {
            //            info.VisualOffset.X -= 8;
            //        }
            //        break;
            //}
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;

            if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            {
                player.GamepadEnableGrappleCooldown();
                player.sitting.SitDown(player, i, j);
            }

            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
            {
                player.noThrow = 2;
                player.cursorItemIconEnabled = true;
                int style = TileObjectData.GetTileStyle(Main.tile[i, j]);
                player.cursorItemIconID = TileLoader.GetItemDropFromTypeAndStyle(Type, style);
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

            int width = 16;
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