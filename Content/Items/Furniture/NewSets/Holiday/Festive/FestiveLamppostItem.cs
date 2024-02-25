using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Festive;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Holiday.Festive;

internal class FestiveLamppostItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 8;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<FestiveLamppost>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:Festive", 6)
            .AddIngredient(ItemID.Torch)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        //CreateRecipe(1)
        //    .AddIngredient(ItemID.GreenCandyCaneBlock, 6)
        //    .AddIngredient(ItemID.Torch)
        //    .AddTile(ModContent.TileType<FestiveWorktable>())
        //    .Register();

        //CreateRecipe(1)
        //    .AddIngredient(ItemID.PineTreeBlock, 6)
        //    .AddIngredient(ItemID.Torch)
        //    .AddTile(ModContent.TileType<FestiveWorktable>())
        //    .Register();
    }
}