using SquintlysFurnitureMod.Content.Furniture.Lights.Surface.Candles;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Tattered.Lighting.Surface;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Repaired.Lighting.Surface;

internal class RepairedCandle : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 12;
        Item.height = 22;

        Item.value = Item.buyPrice(copper: 20);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<Candles_8>());
        Item.placeStyle = 2;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 2)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(ModContent.ItemType<TatteredCandle>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}