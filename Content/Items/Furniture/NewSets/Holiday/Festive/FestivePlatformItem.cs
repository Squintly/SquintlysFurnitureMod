using SquintlysFurnitureMod.Content.Tiles.Decorations.Crafting.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Festive;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Holiday.Festive;

internal class FestivePlatformItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 14;

        Item.value = Item.buyPrice(copper: 0);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<FestivePlatform>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
            .AddRecipeGroup("SquintlyFurnitureMod:Festive")
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();
    }

    public class FestivePlatformRecipe : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe candycanerecipe = Recipe.Create(ItemID.CandyCaneBlock);
            candycanerecipe.AddIngredient(ModContent.ItemType<FestivePlatformItem>(), 2);
            candycanerecipe.Register();

            Recipe greencandycanerecipe = Recipe.Create(ItemID.GreenCandyCaneBlock);
            greencandycanerecipe.AddIngredient(ModContent.ItemType<FestivePlatformItem>(), 2);
            greencandycanerecipe.Register();

            Recipe recipe = Recipe.Create(ItemID.PineTreeBlock);
            recipe.AddIngredient(ModContent.ItemType<FestivePlatformItem>(), 2);
            recipe.Register();
        }
    }
}