using SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.Spotlights;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Tattered.Lighting.Hanging;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Repaired.Lighting.Hanging;

internal class RepairedSpotlight : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<Spotlights_9>());
        Item.placeStyle = 1;
    }
    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(ItemID.Torch, 3)
            .AddIngredient(ModContent.ItemType<TatteredSpotlight>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}