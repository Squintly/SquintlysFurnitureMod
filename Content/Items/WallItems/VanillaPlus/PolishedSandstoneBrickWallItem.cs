using SquintlysFurnitureMod.Content.Items.Blocks.VanillaPlus;
using SquintlysFurnitureMod.Content.WallTiles.VanillaPlus;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.WallItems.VanillaPlus;

public class PolishedSandstoneBrickWallItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;

        Item.useTurn = true;
        Item.autoReuse = true;
        Item.useAnimation = 15;
        Item.useTime = 7;
        Item.useStyle = ItemUseStyleID.Swing;

        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createWall = ModContent.WallType<PolishedSandstoneBrickWall>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
            .AddIngredient<PolishedSandstoneBrickItem>()
            .AddTile(18)
            .Register();
    }
}