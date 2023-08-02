using SquintlysFurnitureMod.Content.Items.WallItems;
using SquintlysFurnitureMod.Content.Tiles.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks;

internal class FadedHieroBlock2Item : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Faded Hieroglyphic Block");
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

        Item.createTile = ModContent.TileType<FadedHieroBlock2>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
           .AddIngredient(ModContent.ItemType<HieroBlock2Item>())
           .AddTile(TileID.WorkBenches)
           .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<PolishedSandstoneBrickItem>())
            .AddTile(TileID.WorkBenches)
            .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<FadedHieroWall2Item>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}