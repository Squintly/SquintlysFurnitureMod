using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Pianos.Pianos_1
{
    [LegacyName("Pianos")]
    public class Pianos_1 : ModTile
    {
        public enum StyleID
        {
            TatteredPiano, //0
            RepairedPiano, //1
            CinderblockPiano //2
        }

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            Main.tileLavaDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            AdjTiles = new int[] { TileID.Pianos };
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            Main.tileSolidTop[Type] = true;
            Main.tileTable[Type] = true;
            TileID.Sets.IgnoredByNpcStepUp[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
            TileObjectData.newTile.StyleHorizontal = true;

            TileObjectData.newTile.StyleWrapLimit = 111;

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.addTile(Type);
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

            int height = tile.TileFrameY == 38 ? 18 : 16;

            spriteBatch.Draw(
                 ModContent.Request<Texture2D>(Texture + "_Overlay").Value,
                 new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                 new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height),
                 Lighting.GetColor(i, j));
        }
    }
}

/*STYLES
0- Tattered
1- Repaired
*/