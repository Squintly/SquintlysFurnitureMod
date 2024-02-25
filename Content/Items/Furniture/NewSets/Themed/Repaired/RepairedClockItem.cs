using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Tattered;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Themed.Repaired;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Repaired;

internal class RepairedClockItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 13;
        Item.height = 20;

        Item.value = Item.buyPrice(copper: 60);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<RepairedClock>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddIngredient(ItemID.Glass, 3)
            .AddIngredient(ModContent.ItemType<TatteredClockItem>())
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}