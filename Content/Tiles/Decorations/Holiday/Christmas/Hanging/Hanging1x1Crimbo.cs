using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Christmas.Decorations.Hanging;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas.Hanging;

public class Hanging1x1Crimbo : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.CoordinateHeights = new int[1] { 18 };
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);

        TileObjectData.newTile.Origin = new Point16(0, 0);

        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 111;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        RegisterItemDrop(ModContent.ItemType<Mistletoe>(), 1 | 0);
        RegisterItemDrop(ModContent.ItemType<FestiveBells>(), 2 | 3);
        RegisterItemDrop(ModContent.ItemType<FestiveBauble>(), 5 | 6 | 7 | 8 | 9);

        TileObjectData.addTile(Type);
    }
}