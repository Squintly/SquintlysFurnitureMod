using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Holiday.Heartfelt;
using SquintlysFurnitureMod.Content.Items.WallItems.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Blocks.Holiday;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks.Holiday;

internal class HeartfeltBlockItem : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Heartfelt Block");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;

        Item.value = Item.buyPrice(silver: 5);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<HeartfeltBlock>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(30)
            .AddIngredient(ItemID.LifeCrystal)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();

        CreateRecipe(30)
           .AddIngredient(ItemID.LifeCrystal)
           .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
           .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<HeartfeltPlatform>(), 2)
            .Register();

        CreateRecipe()
           .AddIngredient(ModContent.ItemType<BigHeartfeltPlatform>(), 2)
           .Register();

        CreateRecipe()
           .AddIngredient(ModContent.ItemType<HeartfeltWallItem>(), 4)
           .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
           .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<HeartfeltWallItem>(), 4)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
    }
}