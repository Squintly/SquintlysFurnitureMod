using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Hobbies.Toys.Stuffies;

internal class SpringChick : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 16;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<S_1x1_B_6>();
        Item.placeStyle = 2;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<FloralWorktable>())
            .Register();
    }
}