using SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Armchairs;
using SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Chesterfields;
using SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Sofas;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Seating;

internal class ImperialChesterfield : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 22;

        Item.value = Item.buyPrice(silver: 1);

        Item.DefaultToPlaceableTile(ModContent.TileType<Chesterfields_3>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup(ModContent.TileType<ImperialWood>(), 8)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}