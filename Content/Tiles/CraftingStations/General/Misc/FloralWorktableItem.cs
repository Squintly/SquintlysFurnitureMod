using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;

internal class FloralWorktableItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 25;

        Item.value = Item.buyPrice(silver: 10);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<FloralWorktable>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddRecipeGroup("SquintlyFurnitureMod:FlowerSeeds", 4)
            .AddTile(TileID.Sawmill)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.SilverCoin, 10)
            .AddTile(ModContent.TileType<ShopFlowers>())
            .Register();
    }
}