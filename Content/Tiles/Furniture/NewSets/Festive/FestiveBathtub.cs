using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Festive;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Festive;

public class FestiveBathtub : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoAttach[Type] = true;
        Main.tileNoFail[Type] = false;

        Main.tileLavaDeath[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        AdjTiles = new int[] { TileID.Bathtubs };
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

        TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 18 };

        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
        TileObjectData.addAlternate(1);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        RegisterItemDrop(ModContent.ItemType<FestiveBathtubItem>());
        AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Bathtub"));
    }

    private readonly int animationFrameHeight = 54;

    public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
    {
        int uniqueAnimationFrame = Main.tileFrame[Type] + i;
        if (i % 2 == 0)
            uniqueAnimationFrame += 3;
        if (i % 3 == 0)
            uniqueAnimationFrame += 3;
        if (i % 4 == 0)
            uniqueAnimationFrame += 3;
        uniqueAnimationFrame %= 14;

        // frameYOffset = modTile.animationFrameHeight * Main.tileFrame [type] will already be set before this hook is called
        // But we have a horizontal animated texture, so we use frameXOffset instead of frameYOffset
        frameYOffset = uniqueAnimationFrame * animationFrameHeight;
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        // Spend 9 ticks on each of 6 frames, looping
        frameCounter++;
        if (frameCounter >= 9)
        {
            frameCounter = 0;
            if (++frame >= 14)
            {
                frame = 0;
            }
        }
    }
}