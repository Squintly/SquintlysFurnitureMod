using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines.Balloons;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Heartfelt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines.Balloons;

internal class MixedBundledHeartBalloons : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<MixedBundledHeartBalloonTile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<WhiteHeartBalloon>())
            .AddIngredient(ModContent.ItemType<HeartBalloon>())
            .AddIngredient(ModContent.ItemType<GoldHeartBalloon>())
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
    }
}