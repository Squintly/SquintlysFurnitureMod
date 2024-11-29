using SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Armchairs;
using SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Ottomans;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Tattered.Seating.Soft;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Repaired.Seating.Soft;

internal class RepairedOttoman : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 18;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<Ottomans_6>());
        Item.placeStyle = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 2)
            .AddIngredient(ItemID.Silk)
            .AddIngredient(ModContent.ItemType<TatteredOttoman>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}