using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;

public class TrainSet : ModTile
{
	public override void SetStaticDefaults() {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoAttach[Type] = true;
        Main.tileNoFail[base.Type] = false;

        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        
        TileID.Sets.DisableSmartCursor[Type] = true;

        AddMapEntry(new Color(12, 69, 6), base.CreateMapEntryName("Festive Decoration"));

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1); 
        TileObjectData.newTile.Width = 2;
        TileObjectData.newTile.Height = 1;
		TileObjectData.newTile.CoordinateHeights = new int[1] { 18 };
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);

        TileObjectData.addTile(Type);

        AnimationFrameHeight = 20;
    }

	public override void KillMultiTile(int x, int y, int frameX, int frameY) {
		Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, ModContent.ItemType<Items.Decorations.Holiday.Christmas.TrainSetItem>());
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
