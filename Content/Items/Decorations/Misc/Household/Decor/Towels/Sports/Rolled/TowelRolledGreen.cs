using SquintlysFurnitureMod.Content.Tiles.Decorations.Misc.Household.Decor.Towels;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Decor.Towels.Sports.Rolled;

internal class TowelRolledGreen : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;

        Item.value = Item.buyPrice(gold: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<TowelsRolled>();
        Item.placeStyle = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Silk, 1)
            .AddIngredient(ItemID.GreenDye)
            .AddTile(TileID.Loom)
            .Register();

        CreateRecipe()
           .AddIngredient(ItemID.Silk, 1)
           .AddIngredient(ItemID.GreenDye)
           .AddTile(TileID.LivingLoom)
           .Register();
    }
}