using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using SquintlysFurnitureMod.Content.Furniture.Misc.Doors;
using SquintlysFurnitureMod.Content.Furniture.Misc.Platforms;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Misc;

internal class ImperialPlatform : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 22;

        Item.value = Item.buyPrice(silver: 1);

        Item.DefaultToPlaceableTile(ModContent.TileType<Platforms>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 1)
            .Register();
    }
}