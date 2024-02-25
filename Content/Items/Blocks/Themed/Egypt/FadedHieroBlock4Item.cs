using SquintlysFurnitureMod.Content.Items.Blocks.VanillaPlus;
using SquintlysFurnitureMod.Content.Items.WallItems.Themed.Egypt;
using SquintlysFurnitureMod.Content.Tiles.Blocks.Themed.Egypt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks.Themed.Egypt;

internal class FadedHieroBlock4Item : ModItem
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

        Item.createTile = ModContent.TileType<FadedHieroBlock4>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
           .AddRecipeGroup("SquintlyFurnitureMod:HieroBlocks")
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}