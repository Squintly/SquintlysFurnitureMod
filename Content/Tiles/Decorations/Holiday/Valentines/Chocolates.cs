using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines;

public class Chocolates : ModTile
{
    public bool isClosed;
    public int frameCount = 2;
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;
        AnimationFrameHeight = 16;

        Main.tileLavaDeath[Type] = false;
        isClosed = false;
        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
        TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };

        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 111;
        
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);
    }
    public override bool RightClick(int i, int j)
    {
        if (isClosed)
        {
            isClosed = false;
        } else
        {
            isClosed = true;
        }
            
        return true;
    }
    public int Timer;
    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        if (isClosed)
        {
            frame = 0;
            Timer = 0;
        }
        else if (++frameCounter >= frameCount && Timer <= 2)
        {
            Timer++;
            frameCounter = 0;
            frame = ++frame % 2;
        }
    }
    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Texture2D texture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Tiles/Decorations/Holiday/Valentines/Chocolates").Value;

            // If you are using ModTile.SpecialDraw or PostDraw or PreDraw, use this snippet and add zero to all calls to spriteBatch.Draw
            // The reason for this is to accommodate the shift in drawing coordinates that occurs when using the different Lighting mode
            // Press Shift+F9 to change lighting modes quickly to verify your code works for all lighting modes
            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

            // Because height of third tile is different we change it
            int height = tile.TileFrameY % AnimationFrameHeight == 36 ? 16 : 16;

            // Offset along the Y axis depending on the current frame
            int frameYOffset = Main.tileFrame[Type] * AnimationFrameHeight;

            // Firstly we draw the original texture and then glow mask texture
            spriteBatch.Draw(
                texture,
                new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                new Rectangle(tile.TileFrameX, tile.TileFrameY + frameYOffset, 16, height),
                Lighting.GetColor(i, j), 0f, default, 1f, SpriteEffects.None, 0f);
            // Make sure to draw with Color.White or at least a color that is fully opaque
            // Achieve opaqueness by increasing the alpha channel closer to 255. (lowering closer to 0 will achieve transparency)

            // Return false to stop vanilla draw
            return false;
        }
}