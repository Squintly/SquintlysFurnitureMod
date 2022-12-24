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

public class HangingCrimbo2x2 : ModTile
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
        TileObjectData.newTile.Width = 2;
        TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);

        TileObjectData.newTile.Origin = new Point16(0, 0);

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
                item = ModContent.ItemType<Sun>();
                break;
            case 1:
                item = ModContent.ItemType<Moon>();
                break;
            case 2:
                item = ModContent.ItemType<Wreath>();
                break;
            case 3:
                item = ModContent.ItemType<Skates>();
                break;
            case 4:
                item = ModContent.ItemType<RedBow>();
                break;
            case 5:
                item = ModContent.ItemType<GreenBow>();
                break;
            case 6:
                item = ModContent.ItemType<BlueBow>();
                break;
            case 7:
                item = ModContent.ItemType<WhiteBow>();
                break;
            case 8:
                item = ModContent.ItemType<GoldBow>();
                break;
        }
        if (item > 0)
        {
            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 16, 16, item);
        }
    }
}
