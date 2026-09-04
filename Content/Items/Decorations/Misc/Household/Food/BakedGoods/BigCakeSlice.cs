using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;
using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneTwo.Big;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.BakedGoods;

internal class BigCakeSlice : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 28;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<S_1x2_B_6>();
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup("SquintlyFurnitureMod:Flours", 2)
            .AddRecipeGroup("SquintlyFurnitureMod:Sugars", 2)
            .AddRecipeGroup("SquintlyFurnitureMod:Eggs")
            .AddTile(TileID.CookingPots)
            .Register();

        CreateRecipe(4)
            .AddIngredient(Mod.Find<ModItem>("BigCake").Type)
            .AddTile(TileID.CookingPots)
            .Register();
    }
}