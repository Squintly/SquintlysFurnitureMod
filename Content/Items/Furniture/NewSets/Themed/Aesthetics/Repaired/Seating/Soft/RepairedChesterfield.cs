using SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Chesterfields;
using SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Sofas;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Tattered.Seating.Soft;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Repaired.Seating.Soft;

internal class RepairedChesterfield : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 22;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<Chesterfields_3Tall_6>(), (int)Chesterfields_3Tall_6.StyleID.Repaired);
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ModContent.ItemType<TatteredChesterfield>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}