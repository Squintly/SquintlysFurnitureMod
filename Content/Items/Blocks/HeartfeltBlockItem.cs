using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Heartfelt;
using SquintlysFurnitureMod.Content.Items.WallItems;
using SquintlysFurnitureMod.Content.Tiles.Blocks;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks;

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

        Item.value = Item.buyPrice(copper: 0);

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
        CreateRecipe()
           .AddIngredient(ModContent.ItemType<HeartfeltWallItem>(), 4)
           .AddTile(TileID.WorkBenches)
           .Register();

        CreateRecipe(10)
            .AddIngredient(ItemID.LifeCrystal)
            .AddTile(TileID.WorkBenches)
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

        CreateRecipe(10)
            .AddIngredient(ItemID.LifeCrystal)
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
    }
}