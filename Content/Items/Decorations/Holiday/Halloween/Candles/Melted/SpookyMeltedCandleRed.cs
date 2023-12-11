using SquintlysFurnitureMod.Content.Tiles.Decorations.Crafting;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Halloween.Candles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Halloween.Candles.Melted;

internal class SpookyMeltedCandleRed : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 18;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<CandlesSmallRed>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.GoldBar)
            .AddIngredient(ItemID.Torch)
            .AddIngredient(ItemID.RedDye)
            .AddTile(ModContent.TileType<DecoBoxTile>())
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.PlatinumBar)
            .AddIngredient(ItemID.Torch)
            .AddIngredient(ItemID.RedDye)
            .AddTile(ModContent.TileType<DecoBoxTile>())
            .Register();
    }
}