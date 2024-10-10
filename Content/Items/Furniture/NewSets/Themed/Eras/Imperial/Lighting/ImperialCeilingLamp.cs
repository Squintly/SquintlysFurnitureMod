using SquintlysFurnitureMod.Content.Furniture.Bathroom.Sinks;
using SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.CeilingLamps;
using SquintlysFurnitureMod.Content.Furniture.Lights.Surface.Candelabras;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Lighting;

internal class ImperialCeilingLamp : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 14;

        Item.value = Item.buyPrice(silver: 1);

        Item.DefaultToPlaceableTile(ModContent.TileType<CeilingLamps>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}