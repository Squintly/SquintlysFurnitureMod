using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bedroom.RoyalBeds.ThreeTall.RoyalBeds_3Tall_6.Items;

internal class TatteredRoyalBed : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 4);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<TatteredRoyalBeds>());
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

internal class RepairedRoyalBed : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 24;

        Item.value = Item.buyPrice(silver: 4);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<RepairedRoyalBeds>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.Wood, 10)
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ModContent.ItemType<TatteredRoyalBed>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}