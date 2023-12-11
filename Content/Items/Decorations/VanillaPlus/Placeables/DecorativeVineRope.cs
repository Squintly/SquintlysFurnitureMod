using SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Placeables;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Placeables;

internal class DecorativeVineRope : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 24;

        Item.value = Item.buyPrice(copper: 20);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<DecorativeRopeTile>();
        Item.placeStyle = 2;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.VineRopeCoil)
            .Register();
    }
}