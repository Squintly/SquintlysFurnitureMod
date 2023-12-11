using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Halloween.Other.BellJars;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Halloween.Decorations.BellJars;

public class WormBell : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoAttach[Type] = true;
        Main.tileNoFail[Type] = false;

        Main.tileLavaDeath[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
        TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);

        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        AnimationFrameHeight = 18;
        RegisterItemDrop(ModContent.ItemType<BellJarItemWorm>());
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        frameCounter++;
        if (frameCounter >= 9)
        {
            frameCounter = 0;
            frame++;
            frame %= 7;
        }
    }
}