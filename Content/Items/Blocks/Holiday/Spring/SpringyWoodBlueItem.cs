using SquintlysFurnitureMod.Content.Items.WallItems.Holiday.Spring;
using SquintlysFurnitureMod.Content.Tiles.Blocks.Holiday.Spring;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks.Holiday.Spring;

internal class SpringyWoodBlueItem : ModItem
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

        Item.createTile = ModContent.TileType<SpringyWoodBlue>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
           .AddIngredient(ModContent.ItemType<SpringyWood>())
           .AddIngredient(ItemID.SkyBluePaint)
           .AddTile(TileID.WorkBenches)
           .Register();

        CreateRecipe()
           .AddIngredient(ModContent.ItemType<SpringyWoodBlueWallItem>(), 4)
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}