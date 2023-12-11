using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines;
using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines.Decorations.Hanging;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines.Decorations;

public class HeartStrings : ModTile
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
        TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);

        TileObjectData.newTile.Origin = new Point16(0, 0);

        TileObjectData.newTile.RandomStyleRange = 9;
        TileObjectData.newTile.StyleWrapLimit = 111;
        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        RegisterItemDrop(ModContent.ItemType<HeartStringsItem>());
    }
}