using SquintlysFurnitureMod.Content.Items.Materials;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Crafting.General;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Easter.Other;
using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big;
using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Normal;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;

internal class CheeseSlice : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 16;

        Item.value = Item.buyPrice(copper: 10);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<S_1x1_B_2>();
        Item.placeStyle = 11;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup("SquintlyFurnitureMod:Milks")
            .AddTile(TileID.CookingPots)
            .Register(); 

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<CheeseWheel>())
            .AddTile(TileID.CookingPots)
            .Register();
    }
}
