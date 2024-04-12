using SquintlysFurnitureMod.Content.Tiles.Decorations.Crafting.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Easter.Baskets;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Easter.Baskets;

internal class SpringBasket : ModItem
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

        Item.createTile = ModContent.TileType<SpringBaskets>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 6)
            .AddIngredient(ItemID.Silk, 5)
            .AddRecipeGroup("SquintlyFurnitureMod:FlowerSeeds", 4)
            .AddTile(ModContent.TileType<FloralWorktable>())
            .Register();
    }
}