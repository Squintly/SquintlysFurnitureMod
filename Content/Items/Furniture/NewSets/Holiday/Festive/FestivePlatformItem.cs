using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;
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

        //CreateRecipe(4)
        //    .AddIngredient(ItemID.GreenCandyCaneBlock)
        //    .AddTile(ModContent.TileType<FestiveWorktable>())
        //    .Register();

        //CreateRecipe(4)
        //    .AddIngredient(ItemID.PineTreeBlock)
        //    .AddTile(ModContent.TileType<FestiveWorktable>())
        //    .Register();
    }
}