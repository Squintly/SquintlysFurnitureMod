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

public class Banners : ModTile
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

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.addTile(base.Type);

        base.AddMapEntry(new Color(12, 69, 6), base.CreateMapEntryName("Festive Decoration"));
    }

    public override void KillMultiTile(int x, int y, int frameX, int frameY)
    {
        int item = 0;
        switch (frameX / 18)
        {
            case 0:
                item = ModContent.ItemType<RedBanner>();
                break;
            case 1:
                item = ModContent.ItemType<RedTreeBanner>();
                break;
            case 2:
                item = ModContent.ItemType<RedSnowflakeBanner>();
                break;
            case 3:
                item = ModContent.ItemType<GreenSantaBanner>();
                break;
            case 4:
                item = ModContent.ItemType<GreenSnowflakeBanner>();
                break;
            case 5:
                item = ModContent.ItemType<GreenBanner>();
                break;
            case 6:
                item = ModContent.ItemType<BlueSnowflakeBanner>();
                break;
            case 7:
                item = ModContent.ItemType<BlueSantaBanner>();
                break;
            case 8:
                item = ModContent.ItemType<BlueStarBanner>();
                break;
            case 9:
                item = ModContent.ItemType<DreidelBanner>();
                break;
            case 10:
                item = ModContent.ItemType<BlueBanner>();
                break;
            case 11:
                item = ModContent.ItemType<WhiteTreeBanner>();
                break;
            case 12:
                item = ModContent.ItemType<WhiteStarBanner>();
                break;
            case 13:
                item = ModContent.ItemType<StripeBanner>();
                break;
            case 14:
                item = ModContent.ItemType<HollyBanner>();
                break;
            case 15:
                item = ModContent.ItemType<WhiteBanner>();
                break;

        }
        if (item > 0)
        {
            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 16, 16, item);
        }
    }
}
