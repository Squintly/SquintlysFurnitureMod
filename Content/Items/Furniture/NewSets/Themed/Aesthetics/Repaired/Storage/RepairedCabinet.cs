using SquintlysFurnitureMod.Content.Furniture.Storage.Cabinets;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Tattered.Storage;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Repaired.Storage;

internal class RepairedCabinet : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 26;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<Cabinets_2>());
        Item.placeStyle = 2;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddRecipeGroup(RecipeGroupID.IronBar, 1)
            .AddIngredient(ModContent.ItemType<TatteredCabinet>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}