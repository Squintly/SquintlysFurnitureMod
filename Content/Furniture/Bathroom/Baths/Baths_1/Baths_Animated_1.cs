using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Furniture.Bathroom.Baths.Baths_1;

[LegacyName("Baths_Animated")]
public class Baths_Animated_1 : ModTile
{
    public enum StyleID
    {
        CinderblockBathtub, //0
    }

    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoAttach[Type] = true;
        Main.tileNoFail[Type] = false;

        Main.tileLavaDeath[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        AdjTiles = new int[] { TileID.Bathtubs };
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);

        TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
        TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };

        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
        TileObjectData.addAlternate(1);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Bathtub"));

        AnimationFrameHeight = 38;
    }

    //public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
    //{
    //    int uniqueAnimationFrame = Main.tileFrame[Type] + i;
    //    if (i % 2 == 0)
    //        uniqueAnimationFrame += 3;
    //    if (i % 3 == 0)
    //        uniqueAnimationFrame += 3;
    //    if (i % 4 == 0)
    //        uniqueAnimationFrame += 3;
    //    uniqueAnimationFrame %= 14;

    //    frameYOffset = uniqueAnimationFrame * AnimationFrameHeight;
    //}

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        // Spend 9 ticks on each of 6 frames, looping
        frameCounter++;
        if (frameCounter >= 5)
        {
            frameCounter = 0;
            if (++frame >= 8)
            {
                frame = 0;
            }
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

        int height = tile.TileFrameY % AnimationFrameHeight == 34 ? 18 : 16;
        int frameYOffset = (Main.tileFrame[Type]) * AnimationFrameHeight;

        spriteBatch.Draw(
                ModContent.Request<Texture2D>(Texture + "_Overlay").Value,
                new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
                new Rectangle(tile.TileFrameX, tile.TileFrameY + frameYOffset, 16, height),
                Lighting.GetColor(i, j));
    }
}