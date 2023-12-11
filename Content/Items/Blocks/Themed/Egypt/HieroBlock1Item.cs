using SquintlysFurnitureMod.Content.Items.Blocks.VanillaPlus;
using SquintlysFurnitureMod.Content.Items.WallItems.Themed.Egypt;
using SquintlysFurnitureMod.Content.Tiles.Blocks.Themed.Egypt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks.Themed.Egypt;

internal class HieroBlock1Item : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Hieroglyphic Block");
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

        Item.createTile = ModContent.TileType<HieroBlock1>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
           .AddIngredient(ModContent.ItemType<FadedHieroWall1Item>())
           .AddTile(TileID.WorkBenches)
           .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<PolishedSandstoneBrickItem>())
            .AddTile(TileID.WorkBenches)
            .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<HieroWall1Item>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}