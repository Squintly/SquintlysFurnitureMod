using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Clutter.Cleaning;

internal class WoodenBucket : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 12;
        Item.height = 14;

        Item.value = Item.buyPrice(copper: 1);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_4>());
        Item.placeStyle = 8;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 5)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}