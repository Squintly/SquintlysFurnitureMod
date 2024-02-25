using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Festive;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Holiday.Festive;

internal class FestiveCandelabraItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 3);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<FestiveCandelabra>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:Festive", 5)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        //CreateRecipe(1)
        //    .AddIngredient(ItemID.CandyCaneBlock, 5)
        //    .AddIngredient(ItemID.Torch, 3)
        //    .AddTile(ModContent.TileType<FestiveWorktable>())
        //    .Register();

        //CreateRecipe(1)
        //    .AddIngredient(ItemID.GreenCandyCaneBlock, 5)
        //    .AddIngredient(ItemID.Torch, 3)
        //    .AddTile(ModContent.TileType<FestiveWorktable>())
        //    .Register();

        //CreateRecipe(1)
        //    .AddIngredient(ItemID.PineTreeBlock, 5)
        //    .AddIngredient(ItemID.Torch, 3)
        //    .AddTile(ModContent.TileType<FestiveWorktable>())
        //    .Register();
    }
}