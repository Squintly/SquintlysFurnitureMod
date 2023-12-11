using SquintlysFurnitureMod.Content.Tiles.Furniture.VanillaPlus;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.VanillaPlus.Storage;

internal class FishBarrel : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 22;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);

        Item.useStyle = 1;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<FishBarrelTile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 9)
            .AddRecipeGroup(RecipeGroupID.IronBar)
            .AddIngredient(ItemID.AtlanticCod)
            .AddTile(TileID.Sawmill)
            .Register();

        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 9)
            .AddRecipeGroup(RecipeGroupID.IronBar)
            .AddIngredient(ItemID.Bass)
            .AddTile(TileID.Sawmill)
            .Register();

        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 9)
            .AddRecipeGroup(RecipeGroupID.IronBar)
            .AddIngredient(ItemID.Flounder)
            .AddTile(TileID.Sawmill)
            .Register();

        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 9)
            .AddRecipeGroup(RecipeGroupID.IronBar)
            .AddIngredient(ItemID.NeonTetra)
            .AddTile(TileID.Sawmill)
            .Register();

        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 9)
            .AddRecipeGroup(RecipeGroupID.IronBar)
            .AddIngredient(ItemID.RedSnapper)
            .AddTile(TileID.Sawmill)
            .Register();

        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 9)
            .AddRecipeGroup(RecipeGroupID.IronBar)
            .AddIngredient(ItemID.Tuna)
            .AddTile(TileID.Sawmill)
            .Register();

        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 9)
            .AddRecipeGroup(RecipeGroupID.IronBar)
            .AddIngredient(ItemID.Salmon)
            .AddTile(TileID.Sawmill)
            .Register();

        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 9)
            .AddRecipeGroup(RecipeGroupID.IronBar)
            .AddIngredient(ItemID.Trout)
            .AddTile(TileID.Sawmill)
            .Register();
    }
}