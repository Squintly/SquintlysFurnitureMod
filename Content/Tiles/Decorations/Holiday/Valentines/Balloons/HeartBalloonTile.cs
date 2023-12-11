using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines.Balloons;

public class HeartBalloonTile : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoAttach[Type] = true;
        Main.tileNoFail[Type] = false;

        Main.tileLavaDeath[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.Height = 2;
        TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
        TileObjectData.newTile.StyleWrapLimit = 2;
        TileObjectData.newTile.StyleMultiplier = 2;
        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);
    }

    private readonly int animationFrameWidth = 18;

    public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
    {
        int uniqueAnimationFrame = Main.tileFrame[Type] + i;
        if (i % 2 == 0)
            uniqueAnimationFrame += 2;
        uniqueAnimationFrame %= 2;

        // frameYOffset = modTile.animationFrameHeight * Main.tileFrame [type] will already be set before this hook is called
        // But we have a horizontal animated texture, so we use frameXOffset instead of frameYOffset
        frameXOffset = uniqueAnimationFrame * animationFrameWidth;
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        // Spend 9 ticks on each of 6 frames, looping
        frameCounter++;
        if (frameCounter >= 20)
        {
            frameCounter = 0;
            if (++frame >= 2)
            {
                frame = 0;
            }
        }
    }
}