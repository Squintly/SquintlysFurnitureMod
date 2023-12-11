using SquintlysFurnitureMod.Content.Items.Blocks.VanillaPlus;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Themed.Egypt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Themed.Egypt;

internal class ObeliskItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 14;
        Item.height = 30;

        Item.value = Item.buyPrice(copper: 10);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<ObeliskTile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.SandstoneBrick, 10)
            .AddTile(TileID.WorkBenches)
            .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<PolishedSandstoneBrickItem>(), 10)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}