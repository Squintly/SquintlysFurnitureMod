using SquintlysFurnitureMod.Content.Furniture.Bathroom.Sinks;
using SquintlysFurnitureMod.Content.Furniture.Bedroom.Dressers;
using SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.Chandeliers;
using SquintlysFurnitureMod.Content.Furniture.Lights.Surface.Candelabras;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Lighting;

internal class ImperialChandelier : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);

        Item.DefaultToPlaceableTile(ModContent.TileType<Chandeliers>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 4)
            .AddIngredient(ItemID.Torch, 4)
            .AddIngredient(ItemID.Chain)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}