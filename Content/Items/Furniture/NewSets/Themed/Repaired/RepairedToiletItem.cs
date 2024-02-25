using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Tattered;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Themed.Repaired;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Repaired;

internal class RepairedToiletItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 26;

        Item.value = Item.buyPrice(copper: 0);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<RepairedToilet>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(ModContent.ItemType<TatteredToiletItem>())
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}