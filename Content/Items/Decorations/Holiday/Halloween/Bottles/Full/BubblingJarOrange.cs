using SquintlysFurnitureMod.Content.Tiles.Decorations.Crafting;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Halloween.Bottles.Jars;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Halloween.Bottles.Full;

internal class BubblingJarOrange : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 22;
        Item.height = 28;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<BubblingJarOrangeTile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Bottle)
            .AddIngredient(ItemID.Fireblossom)
            .AddTile(ModContent.TileType<DecoBoxTile>())
            .Register();
    }
}