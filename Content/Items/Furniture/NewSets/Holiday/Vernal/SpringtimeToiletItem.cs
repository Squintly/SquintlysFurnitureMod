using SquintlysFurnitureMod.Content.Items.Blocks.Holiday.Spring;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Vernal;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Holiday.Vernal;

internal class SpringtimeToiletItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 26;

        Item.value = Item.buyPrice(silver: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<SpringtimeToilet>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.ClayBlock, 4)
            .AddIngredient(ModContent.ItemType<SpringyWood>(), 4)
            .AddTile(ModContent.TileType<FloralWorktable>())
            .Register();
    }
}