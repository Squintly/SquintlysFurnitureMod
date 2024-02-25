using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Festive;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Holiday.Festive;

internal class FestiveCeilingLampItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;

        Item.value = Item.buyPrice(copper: 20);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<FestiveCeilingLamp>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:Festive", 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        //CreateRecipe(1)
        //    .AddIngredient(ItemID.GreenCandyCaneBlock, 4)
        //    .AddIngredient(ItemID.Torch)
        //    .AddTile(ModContent.TileType<FestiveWorktable>())
        //    .Register();

        //CreateRecipe(1)
        //    .AddIngredient(ItemID.PineTreeBlock, 4)
        //    .AddIngredient(ItemID.Torch)
        //    .AddTile(ModContent.TileType<FestiveWorktable>())
        //    .Register();
    }
}