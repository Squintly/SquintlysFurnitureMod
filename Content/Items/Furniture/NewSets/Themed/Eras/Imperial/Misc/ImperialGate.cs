using SquintlysFurnitureMod.Content.Furniture.Lights.Surface.Candelabras;
using SquintlysFurnitureMod.Content.Furniture.Misc.Bookcases;
using SquintlysFurnitureMod.Content.Furniture.Misc.Doors;
using SquintlysFurnitureMod.Content.Furniture.Misc.Gates;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Misc;

internal class ImperialGate : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);

        Item.DefaultToPlaceableTile(ModContent.TileType<Gates_Closed>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 12)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}