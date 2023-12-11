using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Halloween.Alchemy.Cauldrons;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Halloween.Alchemy;

public class BigCauldron : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoAttach[Type] = true;
        Main.tileNoFail[Type] = false;

        Main.tileLavaDeath[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
        TileObjectData.newTile.Width = 2;
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.CoordinateHeights = new int[1] { 24 };
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
        TileObjectData.newTile.DrawYOffset = -6;

        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        AnimationFrameHeight = 24;
        RegisterItemDrop(ModContent.ItemType<BigCauldronItem>());
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