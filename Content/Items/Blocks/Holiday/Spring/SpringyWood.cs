using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Holiday.Vernal;
using SquintlysFurnitureMod.Content.Items.WallItems.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Blocks.Holiday.Spring;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks.Holiday.Spring;

internal class SpringyWood : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Heartfelt Block");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;

        Item.value = Item.buyPrice(copper: 0);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<SpringyWoodBlock>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
           .AddIngredient(ModContent.ItemType<SpringyWoodWallItem>(), 4)
           .AddTile(TileID.WorkBenches)
           .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<SpringtimePlatformItem>(), 2)
            .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<SpringtimePlatformFloralItem>(), 2)
            .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<SpringtimeShelfItem>(), 2)
            .Register();
    }
}