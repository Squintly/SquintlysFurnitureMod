using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Easter.Other;
using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big;
using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Normal;
using SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoTwo.Normal;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.BakedGoods;

internal class BigCake : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<S_2x2_8>();
        Item.placeStyle = 0;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup("SquintlyFurnitureMod:Flours", 8)
            .AddRecipeGroup("SquintlyFurnitureMod:Sugars", 8)
            .AddIngredient(ModContent.ItemType<Egg>(), 4)
            .AddTile(TileID.CookingPots)
            .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<CakeSlice>(), 4)
            .AddTile(TileID.CookingPots)
            .Register();
    }
}
