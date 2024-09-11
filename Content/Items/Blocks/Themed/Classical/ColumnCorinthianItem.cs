using SquintlysFurnitureMod.Content.Blocks.Unsolids.Pillars.Classical;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks.Themed.Classical;

internal class ColumnCorinthianItem : ModItem
{
    public override void SetStaticDefaults()
    {
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

        Item.createTile = ModContent.TileType<ColumnCorinthian>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
           .AddIngredient(ItemID.MarbleBlock)
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}