using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
using SquintlysFurnitureMod.Content.WallTiles.Woods.Teak;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.WallItems.Woods.Teak;

public class TeakShingleWallItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useTurn = true;
        Item.autoReuse = true;
        Item.useAnimation = 15;
        Item.useTime = 7;
        Item.useStyle = ItemUseStyleID.Swing;

        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createWall = ModContent.WallType<TeakShingleWall>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
            .AddIngredient<TeakShinglesItem>()
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}