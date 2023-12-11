using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas.Surface;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Christmas.Decorations.Surface.Figures;

internal class TreeGnome : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 14;
        Item.height = 28;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<Crimbo1x2>();
        Item.placeStyle = 4;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.PineTreeBlock)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();
    }
}