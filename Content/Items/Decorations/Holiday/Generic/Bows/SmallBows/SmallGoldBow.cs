using SquintlysFurnitureMod.Content.Tiles.Decorations.Crafting;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Generic;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Generic.Bows.SmallBows;

internal class SmallGoldBow : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<SmallBowsTile>();
        Item.placeStyle = 3;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<DecoBoxTile>())
            .Register();
    }
}