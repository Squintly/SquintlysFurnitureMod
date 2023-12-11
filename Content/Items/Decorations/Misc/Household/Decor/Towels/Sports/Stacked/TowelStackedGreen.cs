using SquintlysFurnitureMod.Content.Tiles.Decorations.Misc.Household.Decor.Towels;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Decor.Towels.Sports.Stacked;

internal class TowelStackedGreen : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 28;

        Item.value = Item.buyPrice(gold: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<TowelsStacked>();
        Item.placeStyle = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Silk, 3)
            .AddIngredient(ItemID.GreenDye)
            .AddTile(TileID.Loom)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.Silk, 3)
            .AddIngredient(ItemID.GreenDye)
            .AddTile(TileID.LivingLoom)
            .Register();
    }
}