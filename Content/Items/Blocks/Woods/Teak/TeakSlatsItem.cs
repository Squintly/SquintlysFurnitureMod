using SquintlysFurnitureMod.Content.Items.WallItems.Woods.Teak;
using SquintlysFurnitureMod.Content.Tiles.Blocks.Woods.Teak;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;

internal class TeakSlatsItem : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Pale Sandstone Column");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;

        Item.value = Item.buyPrice(copper: 50);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<TeakSlats>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<TeakWood>())
            .AddTile(TileID.WorkBenches)
            .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<TeakSlatsWallItem>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}