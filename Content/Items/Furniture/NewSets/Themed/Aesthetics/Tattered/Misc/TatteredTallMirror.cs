using SquintlysFurnitureMod.Content.Furniture.Misc.Mirrors;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Tattered.Misc;

internal class TatteredTallMirror : ModItem
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
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
            .AddCondition(Condition.InGraveyard)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}