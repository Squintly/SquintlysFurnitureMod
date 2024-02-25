using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Festive;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Holiday.Festive;

internal class FestiveSofaItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 23;
        Item.height = 15;

        Item.value = Item.buyPrice(copper: 60);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<FestiveSofa>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:Festive", 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        //CreateRecipe(1)
        //    .AddIngredient(ItemID.GreenCandyCaneBlock, 5)
        //    .AddIngredient(ItemID.Silk, 2)
        //    .AddTile(ModContent.TileType<FestiveWorktable>())
        //    .Register();

        //CreateRecipe(1)
        //    .AddIngredient(ItemID.PineTreeBlock, 5)
        //    .AddIngredient(ItemID.Silk, 2)
        //    .AddTile(ModContent.TileType<FestiveWorktable>())
        //    .Register();
    }
}