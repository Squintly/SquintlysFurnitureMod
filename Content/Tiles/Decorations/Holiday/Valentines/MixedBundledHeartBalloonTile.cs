using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines;

public class MixedBundledHeartBalloonTile : ModTile
{
	public override void SetStaticDefaults() {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoAttach[Type] = true;
        Main.tileNoFail[base.Type] = false;

        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        
        TileID.Sets.DisableSmartCursor[Type] = true;

        AddMapEntry(new Color(12, 69, 6), base.CreateMapEntryName("Heart Balloons"));

        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.Width = 2;
        TileObjectData.newTile.Height = 2;
		TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };

        TileObjectData.addTile(Type);

        AnimationFrameHeight = 36;
    }
    public override void KillMultiTile(int x, int y, int frameX, int frameY)
    {
        Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, ModContent.ItemType<MixedBundledHeartBalloons>());
    }

    //public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
    //{
    //    int uniqueAnimationFrame = Main.tileFrame[Type] + i;
    //    if (i % 2 == 0)
    //        uniqueAnimationFrame += 3;
    //    uniqueAnimationFrame %= 4;

    //    // frameYOffset = modTile.animationFrameHeight * Main.tileFrame [type] will already be set before this hook is called
    //    // But we have a horizontal animated texture, so we use frameXOffset instead of frameYOffset
    //    frameXOffset = uniqueAnimationFrame * animationFrameWidth;
    //}

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        frameCounter++;
        if (frameCounter >= 20)
        {
            frameCounter = 0;
            frame++;
            frame %= 4;
        }
    }
}
