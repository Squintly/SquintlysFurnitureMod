using SquintlysFurnitureMod.Content.Tiles.Blocks.VanillaPlus;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks.VanillaPlus;

internal class PaleSandstoneColumnItem : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Pale Sandstone Column");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 18;

        Item.value = Item.buyPrice(copper: 0);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<PaleSandstoneColumn>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.SandstoneBrick)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}