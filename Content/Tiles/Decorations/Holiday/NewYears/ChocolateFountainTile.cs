using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Christmas.Toys;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.NewYears;

public class ChocolateFountainTile : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoAttach[Type] = true;
        Main.tileNoFail[Type] = false;

        Main.tileLavaDeath[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);

        TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);

        TileObjectData.newTile.Origin = new Point16(0, 0);

        TileObjectData.newTile.StyleLineSkip = 18;
        RegisterItemDrop(ModContent.ItemType<ToyTrainItem>());

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        AnimationFrameHeight = 36;
        TileObjectData.addTile(Type);
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        frameCounter++;
        if (frameCounter >= 9)
        {
            frameCounter = 0;
            frame++;
            frame %= 8;
        }
    }
}