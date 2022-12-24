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

public class Hanging1x1Crimbo : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[base.Type] = true;
        TileID.Sets.DisableSmartCursor[base.Type] = true;

        Main.tileLavaDeath[base.Type] = false;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

		Main.tileNoFail[base.Type] = false;
        Main.tileNoAttach[base.Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.Width= 1;
        TileObjectData.newTile.CoordinateHeights = new int[1] { 18 };
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);

        TileObjectData.newTile.Origin = new Point16(0, 0);

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.addTile(base.Type);

        base.AddMapEntry(new Color(12, 69, 6), base.CreateMapEntryName("Festive Decoration"));
    }
    public override bool Drop(int i, int j)
    {
        Tile t = Main.tile[i, j];
        int frame = t.TileFrameX / 18;
        int item = 0;

        if (frame == 0)
            item = ModContent.ItemType<WhiteMistletoe>();

        else if (frame == 1)
            item = ModContent.ItemType<RedMistletoe>();

        else if (frame == 2)
            item = ModContent.ItemType<BigBell>();

        else if (frame == 3)
            item = ModContent.ItemType<LittleBells>();

        else if (frame == 4)
            item = ModContent.ItemType<GreenBauble>();

        else if (frame == 5)
            item = ModContent.ItemType<RedBauble>();

        else if (frame == 6)
            item = ModContent.ItemType<BlueBauble>();

        else if (frame == 7)
            item = ModContent.ItemType<GoldBauble>();

        else if (frame == 8)
            item = ModContent.ItemType<WhiteBauble>();

        if (item > 0)
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, item);

        return base.Drop(i, j);
    }
}
