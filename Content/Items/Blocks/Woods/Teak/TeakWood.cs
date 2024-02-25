using SquintlysFurnitureMod.Content.Tiles.Blocks.Woods.Teak;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;

internal class TeakWood : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Pale Sandstone Column");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 22;

        Item.value = Item.buyPrice(copper: 50);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<TeakBlock>();
    }
    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddRecipeGroup("SquintlyFurnitureMod:TeakWalls", 4)
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}