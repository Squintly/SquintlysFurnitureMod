using SquintlysFurnitureMod.Content.Items.Blocks.Themed.Egypt;
using SquintlysFurnitureMod.Content.WallTiles.Other;
using SquintlysFurnitureMod.Content.WallTiles.Themed.Egypt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.WallItems.Themed.Egypt;

internal class FadedHieroWallSmallItem : ModItem
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

        Item.createWall = ModContent.WallType<FadedHieroWallSmall>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddIngredient(ModContent.ItemType<FadedHieroBlock1Item>())
           .AddTile(TileID.WorkBenches)
           .Register();

        CreateRecipe(4)
           .AddIngredient(ModContent.ItemType<FadedHieroBlock2Item>())
           .AddTile(TileID.WorkBenches)
           .Register();

        CreateRecipe(4)
           .AddIngredient(ModContent.ItemType<FadedHieroBlock3Item>())
           .AddTile(TileID.WorkBenches)
           .Register();

        CreateRecipe(4)
           .AddIngredient(ModContent.ItemType<FadedHieroBlock4Item>())
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}