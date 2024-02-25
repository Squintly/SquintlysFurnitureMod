using SquintlysFurnitureMod.Content.Items.Decorations.Crafting;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Color = Microsoft.Xna.Framework.Color;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Crafting;

public class PrintingPressTile : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 18 };

        TileObjectData.newTile.Origin = new Point16(0, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        AnimationFrameHeight = 54;
        RegisterItemDrop(ModContent.ItemType<PrintingPress>());

        AddMapEntry(new Color(200, 200, 200), Language.GetText("Printing Press"));
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        frameCounter++;
        if (frameCounter >= 9)
        {
            frameCounter = 0;
            frame++;
            frame %= 4;
        }
    }
}