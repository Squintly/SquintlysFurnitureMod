using SquintlysFurnitureMod.Content.Items.Blocks.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Heartfelt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Holiday.Heartfelt;

internal class HeartfeltBedItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 16;

        Item.value = Item.buyPrice(silver: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<HeartfeltBedTile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<HeartfeltBlockItem>(), 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
    }
}