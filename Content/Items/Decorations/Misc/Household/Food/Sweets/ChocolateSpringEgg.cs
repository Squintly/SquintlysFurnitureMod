using SquintlysFurnitureMod.Content.Items.Blocks.Holiday;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Sweets.Edible;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Sweets;

internal class ChocolateSpringEgg : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 20;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<S_1x1_B_3>();
        Item.placeStyle = 4;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ChocolateBlockItem>(), 1)
            .AddTile(ModContent.TileType<FloralWorktable>())
            .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<EdibleChocEgg>(), 1)
            .Register();
    }
}