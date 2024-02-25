using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Tattered;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Themed.Repaired;
using SquintlysFurnitureMod.Content.Tiles.Furniture.SetExtras.KingBeds;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Repaired;

internal class RepairedKingBedItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 2);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<RepairedKingBed>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.Wood, 10)
            .AddIngredient(ItemID.Silk, 3)
            .AddIngredient(ModContent.ItemType<TatteredKingBedItem>())
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}