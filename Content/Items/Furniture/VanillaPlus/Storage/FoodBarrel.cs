using SquintlysFurnitureMod.Content.Tiles.Furniture.VanillaPlus;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.VanillaPlus.Storage;

internal class FoodBarrel : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 26;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);

        Item.useStyle = 1;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<FoodBarrelTile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 9)
            .AddRecipeGroup(RecipeGroupID.IronBar)
            .AddRecipeGroup(RecipeGroupID.Fruit)
            .AddTile(TileID.Sawmill)
            .Register();
    }
}