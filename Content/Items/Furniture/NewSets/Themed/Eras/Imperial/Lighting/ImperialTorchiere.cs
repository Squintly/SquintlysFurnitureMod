using SquintlysFurnitureMod.Content.Furniture.Bathroom.Sinks;
using SquintlysFurnitureMod.Content.Furniture.Lights.Surface.Torchieres;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Lighting;

internal class ImperialTorchiere : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);

        Item.DefaultToPlaceableTile(ModContent.TileType<Torchieres>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 4)
            .AddIngredient(ItemID.Torch, 8)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}