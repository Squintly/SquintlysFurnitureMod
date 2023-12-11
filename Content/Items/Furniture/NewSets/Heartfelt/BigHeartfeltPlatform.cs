using SquintlysFurnitureMod.Content.Items.Blocks.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Heartfelt;

internal class BigHeartfeltPlatform : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 18;

        Item.value = Item.buyPrice(silver: 1);

        Item.useStyle = (ItemUseStyleID.Swing);
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<BigHeartfeltPlatformTile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<HeartfeltBlockItem>(), 1)
            //.AddIngredient(ItemID.Silk)
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
    }
}