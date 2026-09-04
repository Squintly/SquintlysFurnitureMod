using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;
using SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoOne.Big;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.BakedGoods;

internal class Cake : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 20;

        Item.value = Item.buyPrice(copper: 10);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<S_2x1_B_4>();
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup("SquintlyFurnitureMod:Flours", 2)
            .AddRecipeGroup("SquintlyFurnitureMod:Sugars")
            .AddRecipeGroup("SquintlyFurnitureMod:Eggs")
            .AddTile(TileID.CookingPots)
            .Register();
    }
}