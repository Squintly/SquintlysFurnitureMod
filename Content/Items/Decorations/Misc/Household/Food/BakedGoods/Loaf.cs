using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;
using SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoOne.Normal;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.BakedGoods;

internal class Loaf : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 16;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<S_2x1_N_4>();
        Item.placeStyle = 2;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup("SquintlyFurnitureMod:Flours", 2)
            .AddIngredient(Mod.Find<ModItem>("Salt").Type)
            .AddIngredient(Mod.Find<ModItem>("Yeast").Type)
            .AddTile(TileID.CookingPots)
            .Register();
    }
}