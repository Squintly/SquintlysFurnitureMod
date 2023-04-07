using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines;

public class Valentines1x1WallTile : ModTile
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
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
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
            item = ModContent.ItemType<GoldHeartBow>();

        else if (frame == 1)
            item = ModContent.ItemType<HeartBow>();

        else if (frame == 2)
            item = ModContent.ItemType<SmallGoldHeartDecal>();

        else if (frame == 3)
            item = ModContent.ItemType<GoldHeartDecal>();

        else if (frame == 4)
            item = ModContent.ItemType<SmallHeartDecal>();

        else if (frame == 5)
            item = ModContent.ItemType<HeartDecal>();

        else if (frame == 6)
            item = ModContent.ItemType<HeartStrand>();

        else if (frame == 7)
            item = ModContent.ItemType<LaceDecal>();

        else if (frame == 8)
            item = ModContent.ItemType<GoldHeartStrand>();

        else if (frame == 9)
            item = ModContent.ItemType<BigHeartDecal>();

        else if (frame == 10)
            item = ModContent.ItemType<LaceHeartDecal>();

        if (item > 0)
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, item);

        return base.Drop(i, j);
    }
}
