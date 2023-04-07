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

public class SmallCrackers : ModTile
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

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.addTile(base.Type);

        base.AddMapEntry(new Color(12, 69, 6), base.CreateMapEntryName("Year's End Decoration"));
    }

    public override bool Drop(int i, int j)
    {
        Tile t = Main.tile[i, j];
        int frame = t.TileFrameX / 18;
        int item = 0;

        if (frame == 0)
            item = ModContent.ItemType<YellowCracker>();

        else if (frame == 1)
            item = ModContent.ItemType<BlueCracker>();

        else if (frame == 2)
            item = ModContent.ItemType<GreenCracker>();

        else if (frame == 3)
            item = ModContent.ItemType<RedCracker>();

        else if (frame == 4)
            item = ModContent.ItemType<WhiteCracker>();

        else if (frame == 5)
            item = ModContent.ItemType<BlackCracker>();

        else if (frame == 6)
            item = ModContent.ItemType<CrackerPile1>();

        else if (frame == 7)
            item = ModContent.ItemType<CrackerPile2>();

        else if (frame == 8)
            item = ModContent.ItemType<CrackerPile3>();

        if (item > 0)
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, item);

        return base.Drop(i, j);
    }
}
