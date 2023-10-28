using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Christmas;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;

public class TrainSet : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoAttach[Type] = true;
        Main.tileNoFail[Type] = false;

        Main.tileLavaDeath[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileObjectData.newTile.Width = 2;
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.CoordinateHeights = new int[1] { 18 };
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);

        TileObjectData.addTile(Type);

        AnimationFrameHeight = 20;
        RegisterItemDrop(ModContent.ItemType<TrainSetItem>());
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        frameCounter++;
        if (frameCounter >= 9)
        {
            frameCounter = 0;
            frame++;
            frame %= 31;
        }
    }

    //private readonly int animationFrameHeight = 18;

    //public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
    //{
    //    int uniqueAnimationFrame = Main.tileFrame[Type] + i;
    //    if (i % 2 == 0)
    //        uniqueAnimationFrame += 0;
    //    if (i % 3 == 0)
    //        uniqueAnimationFrame += 0;
    //    if (i % 4 == 0)
    //        uniqueAnimationFrame += 0;

    //    uniqueAnimationFrame %= 31;

    //    frameYOffset = modTile.animationFrameHeight * Main.tileFrame[type] will already be set before this hook is called
    //    But we have a horizontal animated texture, so we use frameXOffset instead of frameYOffset
    //    frameYOffset = uniqueAnimationFrame * animationFrameHeight;
    //}

    //public override void AnimateTile(ref int frame, ref int frameCounter)
    //{
    //    frameCounter++;
    //    if (frameCounter >= 20)
    //    {
    //        frameCounter = 0;
    //        frame++;
    //        frame %= 31;
    //    }
    //}
}