using SquintlysFurnitureMod.Content.Furniture.Bathroom.Baths;
using SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Armchairs;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Bathroom;

internal class ConfusinglyLargeBathtubItem : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 20;

        Item.value = Item.buyPrice(silver: 1);

        Item.DefaultToPlaceableTile(ModContent.TileType<ConfusinglyLargeBathtub>());
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 30)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}