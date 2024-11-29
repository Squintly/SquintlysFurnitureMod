using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Woods.Teak;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
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
            TileObjectData.newTile.StyleWrapLimit = 12;
            TileObjectData.newTile.StyleMultiplier = 12;
            TileObjectData.newTile.RandomStyleRange = 3;

            ////Left

            //TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            //TileObjectData.newAlternate.Origin = Point16.Zero;
            //TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
            //TileObjectData.newAlternate.AnchorAlternateTiles = [ModContent.TileType<LibraryShelves_3>()];
            //TileObjectData.addAlternate(3);

            ////Middle

            //TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            //TileObjectData.newAlternate.Origin = Point16.Zero;
            //TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
            //TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
            //TileObjectData.newAlternate.AnchorAlternateTiles = [ModContent.TileType<LibraryShelves_3>()];
            //TileObjectData.addAlternate(6);

            ////Right

            //TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            //TileObjectData.newAlternate.Origin = Point16.Zero;
            //TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
            //TileObjectData.newAlternate.AnchorAlternateTiles = [ModContent.TileType<LibraryShelves_3>()];
            //TileObjectData.addAlternate(9);


            TileObjectData.addTile(Type);
        }
        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

            Tile right = Main.tile[i + 3, j];
            Tile left = Main.tile[i - 1, j];

            int height = tile.TileFrameY % 92 == 92 ? 18 : 16;

            int frameXOffset = 162;

            if (right.HasTile && tile.TileType == ModContent.TileType<LibraryShelves_3>())
            {
                spriteBatch.Draw(
                TextureAssets.Tile[Type].Value,
                new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                new Rectangle(tile.TileFrameX + 162, tile.TileFrameY, 16, 16),
                Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
            }

            if (left.HasTile && tile.TileType == ModContent.TileType<LibraryShelves_3>() && right.HasTile && tile.TileType == ModContent.TileType<LibraryShelves_3>())
            {
                spriteBatch.Draw(
                TextureAssets.Tile[Type].Value,
                new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                new Rectangle(tile.TileFrameX + 324, tile.TileFrameY, 16, 16),
                Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
            }

            if (left.HasTile && tile.TileType == ModContent.TileType<LibraryShelves_3>())
            {
                spriteBatch.Draw(
                TextureAssets.Tile[Type].Value,
                new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                new Rectangle(tile.TileFrameX + 486, tile.TileFrameY, 16, height),
                Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);

            }

            else
            {
                spriteBatch.Draw(
                    TextureAssets.Tile[Type].Value,
                    new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                    new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, 16),
                    Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
            }

            return false;
        }
    }
}
