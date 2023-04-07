using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.NewYears;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.NewYears;

public class SmallRibbonRosettes : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[base.Type] = true;
        TileID.Sets.DisableSmartCursor[base.Type] = true;

        Main.tileLavaDeath[base.Type] = false;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

		Main.tileNoFail[base.Type] = false;
        Main.tileNoAttach[base.Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
        TileObjectData.newTile.Height = 2;
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);

        TileObjectData.newTile.Origin = new Point16(0, 0);

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.addTile(base.Type);

        base.AddMapEntry(new Color(12, 69, 6), base.CreateMapEntryName("Year's End Decoration"));
    }
    public override void KillMultiTile(int x, int y, int frameX, int frameY)
    {
        int item = 0;
        switch (frameX / 18)
        {
            case 0:
                item = ModContent.ItemType<SmallWhiteRibbonRosette>();
                break;
            case 1:
                item = ModContent.ItemType<SmallBlackRibbonRosette>();
                break;
            case 2:
                item = ModContent.ItemType<SmallBlueRibbonRosette>();
                break;
            case 3:
                item = ModContent.ItemType<SmallGoldRibbonRosette>();
                break;
            case 4:
                item = ModContent.ItemType<SmallGreenRibbonRosette>();
                break;
            case 5:
                item = ModContent.ItemType<SmallRedRibbonRosette>();
                break;
            case 6:
                item = ModContent.ItemType<SmallPurpleRibbonRosette>();
                break;
            case 7:
                item = ModContent.ItemType<SmallOrangeRibbonRosette>();
                break;
        }
        if (item > 0)
        {
            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 16, 16, item);
        }
    }
}
