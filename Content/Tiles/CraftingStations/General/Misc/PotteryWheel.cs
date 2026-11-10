using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;

public class PotteryWheel : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;
        Main.tileLavaDeath[Type] = false;
        Main.tileNoAttach[Type] = true;

        Main.tileLighted[Type] = true;
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        AdjTiles = new int[] { TileID.Torches };

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 18 };
        TileObjectData.newTile.Origin = new Point16(0, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(165, 83, 58), Language.GetText("Pottery Wheel"));

        AnimationFrameHeight = 56;
    }
    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        frameCounter++;
        if (frameCounter >= 12)
        {
            frameCounter = 0;
            frame++;
            frame %= 5;
        }
    }

    public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
    {
        var tile = Main.tile[i, j];
        if (tile.TileFrameY < 56)
        {
            frameYOffset = Main.tileFrame[type] * 56;
        }
    }
}

public class PotteryWheelItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 6);

        Item.DefaultToPlaceableTile(ModContent.TileType<PotteryWheel>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.IronBar, 2)
            .AddRecipeGroup(RecipeGroupID.Wood, 20)
            .AddIngredient(ItemID.ClayBlock, 5)
            .AddTile(TileID.WorkBenches)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.SilverCoin, 18)
            .AddTile(ModContent.TileType<ShopSmith>())
            .Register();
    }
}