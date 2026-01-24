using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Top.OneWide.OneOne.Normal;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Christmas.Decorations.Hanging;

internal class FestiveBauble : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 10;
        Item.height = 16;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<T_1x1_N_5>();
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Glass)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();
    }
}