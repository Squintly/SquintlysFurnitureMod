using SquintlysFurnitureMod.Content.Furniture.Misc.Mirrors;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Tattered.Misc;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Repaired.Misc;

internal class RepairedTallMirror : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 30;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<Mirrors_Tall_2>());
        Item.placeStyle = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(ItemID.Glass, 1)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar")
            .AddIngredient(ModContent.ItemType<TatteredTallMirror>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}