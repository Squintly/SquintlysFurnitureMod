using SquintlysFurnitureMod.Content.Furniture.Misc.Platforms;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Tattered.Misc;

internal class TatteredShelf : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 18;

        Item.value = Item.buyPrice(copper: 0);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<Platforms>());
        Item.placeStyle = 5;
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
            .AddRecipeGroup(RecipeGroupID.Wood, 1)
            .AddCondition(Condition.InGraveyard)
            .Register();
    }
}