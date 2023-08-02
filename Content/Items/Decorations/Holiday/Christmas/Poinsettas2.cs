using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Christmas;

internal class Poinsettas2 : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Poinsettas");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 34;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<Crimbo2x2>();
        Item.placeStyle = 6;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.DirtBlock, 1)
            .AddIngredient(ItemID.FlowerPacketRed)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();
    }
}