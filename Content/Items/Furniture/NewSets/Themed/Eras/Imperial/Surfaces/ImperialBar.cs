using SquintlysFurnitureMod.Content.Furniture.Storage.Cabinets;
using SquintlysFurnitureMod.Content.Furniture.Surfaces.Tables;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Surfaces;

internal class ImperialBar : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 22;

        Item.value = Item.buyPrice(silver: 1);

        Item.DefaultToPlaceableTile(ModContent.TileType<Tables>());
        Item.placeStyle = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup(ModContent.TileType<ImperialWood>(), 8)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}