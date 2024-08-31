using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Easter.Other;
using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Normal;
using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneTwo.Big;
using SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoTwo.Normal;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.BakedGoods;

internal class Bunbasket : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 24;

        Item.value = Item.buyPrice(copper: 10);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<S_2x1_B_2>();
        Item.placeStyle = 4;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup("SquintlyFurnitureMod:Flours")
            .AddIngredient(ModContent.ItemType<Yeast>())
            .AddRecipeGroup(RecipeGroupID.Wood, 2)
            .AddTile(TileID.CookingPots)
            .Register();
    }
}
