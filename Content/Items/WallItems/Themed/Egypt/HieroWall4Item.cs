using SquintlysFurnitureMod.Content.Items.Blocks.Themed.Egypt;
using SquintlysFurnitureMod.Content.WallTiles.Themed.Egypt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.WallItems.Themed.Egypt;

internal class HieroWall4Item : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 0);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createWall = ModContent.WallType<HieroWall4>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddIngredient(ModContent.ItemType<HieroBlock4Item>())
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}