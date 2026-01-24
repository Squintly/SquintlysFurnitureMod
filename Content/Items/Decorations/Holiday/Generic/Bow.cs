using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using SquintlysFurnitureMod.Content.Tiles.Wall.TwoWide.TwoTwo;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Generic;

internal class Bow : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 30;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<W_2x2_8>();
        Item.placeStyle = 2;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Silk, 6)
            .AddTile(ModContent.TileType<DecoBoxTile>())
            .Register();
    }
}