using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.LibraryShelves
{
    public class LibraryShelves_3 : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoFail[Type] = false;
            Main.tileNoAttach[Type] = true;

            Main.tileLavaDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            Main.tileSolidTop[Type] = true;
            Main.tileTable[Type] = true;
            AdjTiles = new int[] { TileID.Bookcases };
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.CoordinateHeights = new int[5] { 16, 16, 16, 16, 18 };

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 4;
            TileObjectData.newTile.RandomStyleRange = 3;

            TileObjectData.addTile(Type);
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            bool draw = false;
            int offsetX, offsetY, x, y;
            offsetX = offsetY = x = y = 0;
            int frameX = (Main.tile[i, j].TileFrameX % 54);
            int frameY = Main.tile[i, j].TileFrameY;

            //Left
            if (frameX == 0)
            {
                Tile tile = Main.tile[i - ((frameX == 0) ? 1 : 3), j];
                int type = tile.TileType;
                //Repaired
                if ((Main.tile[i, j].TileFrameX >= 216) &&
                    (type == Type && tile.TileFrameX >= 216))
                {
                    draw = true;
                    x = 378;
                    offsetX = -4;
                    y = frameY;
                }   
                //Tattered
                else if (Main.tile[i, j].TileFrameX <= 216 &&
                    (type == Type && tile.TileFrameX <= 216))
                {
                    draw = true;
                    offsetX = -4;
                    x = 162;
                    y = frameY;
                }
            }

            //Right
            //else
            //{
            //    Tile tile = Main.tile[i - ((frameX == 0) ? 3 : 1), j];
            //    int type = tile.TileType;
            //    //Tattered
            //    if (Main.tile[i, j].TileFrameX <= 214 &&
            //        (type == Type && tile.TileFrameX <= 214))
            //    {
            //        draw = true;
            //        offsetX = 4;
            //        x = 108;
            //        y = frameY;
            //    }
            //    //Repaired
            //    else if (Main.tile[i, j].TileFrameX >= 216 &&
            //        (type == Type && tile.TileFrameX >= 216))
            //    {
            //        draw = true;
            //        x = 378;
            //        offsetX = 4;
            //        y = frameY;
            //    }
            //}
            //Right
            //else
            //{
            //    Tile tile = Main.tile[i + ((frameX == 0) ? 3 : 1), j];
            //    int type = tile.TileType;
            //    //Tattered
            //    if (Main.tile[i, j].TileFrameY <= 90 &&
            //        (type == Type && tile.TileFrameY <= 90))
            //    {
            //        draw = true;
            //        offsetX = 16;
            //        x = 162;
            //        y = ((frameY == 0) ? 0 : 18);
            //    }
            //    //Repaired
            //    else if (Main.tile[i, j].TileFrameY > 90 &&
            //        (type == Type && tile.TileFrameY > 90))
            //    {
            //        draw = true;
            //        offsetX = 32;
            //        x = 162;
            //        y = ((frameY == 0) ? 0 : 18) + 90;
            //    }
            //}
            if (draw)
            {
                Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
                var texture = Main.instance.TilesRenderer.GetTileDrawTexture(Main.tile[i, j], i, j);
                
                spriteBatch.Draw(
                    texture,
                    new Vector2(i * 16 + offsetX - (int)Main.screenPosition.X, j * 16f + offsetY - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(x, y, 8, 16),
                    Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}