using SquintlysFurnitureMod.Content.Items.Blocks.Holiday;
using SquintlysFurnitureMod.Content.Items.Materials;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines.Decorations;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Heartfelt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines.Decorations.Wall.Decals;

internal class LaceDecal : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 8;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<Valentines1x1WallTile>();
        Item.placeStyle = 7;
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<DecalSheet>(), 1)
            .AddIngredient(ModContent.ItemType<HeartfeltBlockItem>())
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
    }
}