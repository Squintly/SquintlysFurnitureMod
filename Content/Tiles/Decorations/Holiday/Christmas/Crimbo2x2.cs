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

public class Crimbo2x2 : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[base.Type] = true;
        TileID.Sets.DisableSmartCursor[base.Type] = true;

        Main.tileLavaDeath[base.Type] = false;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

		Main.tileNoFail[base.Type] = false;
        Main.tileNoAttach[base.Type] = true;

		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
		TileObjectData.newTile.Height = 2;
		TileObjectData.newTile.Width = 2;
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
        TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.addTile(base.Type);

        base.AddMapEntry(new Color(12, 69, 6), base.CreateMapEntryName("Festive Decoration"));
    }

    public override void KillMultiTile(int x, int y, int frameX, int frameY)
    {
        int item = 0;
        switch (frameX / 36)
        {
            case 0:
                item = ModContent.ItemType<BigTeddy>();
                break;
            case 1:
                item = ModContent.ItemType<Reindeer>();
                break;
            case 2:
                item = ModContent.ItemType<Diorama>();
                break;
            case 3:
                item = ModContent.ItemType<Angel>();
                break;
            case 4:
                item = ModContent.ItemType<BigSanta>();
                break;
            case 5:
                item = ModContent.ItemType<Poinsettas>();
                break;
            case 6:
                item = ModContent.ItemType<Poinsettas2>();
                break;
            case 7:
                item = ModContent.ItemType<PoinsettaSleigh>();
                break;
            case 8:
                item = ModContent.ItemType<PresentSleigh>();
                break;
            case 9:
                item = ModContent.ItemType<PresentPileLarge>();
                break;
        }
        if (item > 0)
        {
            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 16, 16, item);
        }
    }
}
