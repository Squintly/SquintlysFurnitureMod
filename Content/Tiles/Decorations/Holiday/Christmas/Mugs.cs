using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Christmas;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;

public class Mugs : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[base.Type] = true;
        TileID.Sets.DisableSmartCursor[base.Type] = true;

        Main.tileLavaDeath[base.Type] = false;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        Main.tileNoFail[base.Type] = false;
        Main.tileNoAttach[base.Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
        TileObjectData.newTile.CoordinateHeights = new int[1] { 22 };
        TileObjectData.newTile.DrawYOffset = -2;

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.addTile(base.Type);

        base.AddMapEntry(new Color(12, 69, 6), base.CreateMapEntryName("Festive Mug"));
    }

    public override bool Drop(int i, int j)
    {
        Tile t = Main.tile[i, j];
        int frame = t.TileFrameX / 18;
        int item = 0;

        if (frame == 0)
            item = ModContent.ItemType<RedMug>();

        else if (frame == 1)
            item = ModContent.ItemType<GreenMug>();

        else if (frame == 2)
            item = ModContent.ItemType<WhiteMug>();

        if (item > 0)
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, item);

        return base.Drop(i, j);
    }
    
    private readonly int animationFrameHeight = 22;

    public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
    {
        int uniqueAnimationFrame = Main.tileFrame[Type] + i;
        if (i % 2 == 0)
            uniqueAnimationFrame += 3;
        if (i % 3 == 0)
            uniqueAnimationFrame += 3;
        if (i % 4 == 0)
            uniqueAnimationFrame += 3;
        uniqueAnimationFrame %= 4;

        // frameYOffset = modTile.animationFrameHeight * Main.tileFrame [type] will already be set before this hook is called
        // But we have a horizontal animated texture, so we use frameXOffset instead of frameYOffset
        frameYOffset = uniqueAnimationFrame * animationFrameHeight;
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        frameCounter++;
        if (frameCounter >= 9) //ticks
        {
            frameCounter = 0;
            if (++frame >= 4)
            {
                frame = 0;
            }
        }
    }
}
