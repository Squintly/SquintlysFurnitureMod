using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bedroom.RoyalBeds.FourTall.RoyalBeds_4Tall_6.Items;

internal class TatteredFourPoster : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 30;

        Item.value = Item.buyPrice(silver: 4);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<TatteredFourPosters>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.Wood, 20)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
    }
}

internal class RepairedFourPoster : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 30;

        Item.value = Item.buyPrice(silver: 4);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<RepairedFourPosters>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.Wood, 10)
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ModContent.ItemType<TatteredFourPoster>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}