using SquintlysFurnitureMod.Content.Items.Blocks;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Heartfelt;

internal class HeartfeltCeilingLamp : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 18;

        Item.value = Item.buyPrice(silver: 1);

        Item.useStyle = (ItemUseStyleID.Swing);
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<HeartfeltCeilingLampTile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<HeartfeltBlockItem>(), 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
    }
}