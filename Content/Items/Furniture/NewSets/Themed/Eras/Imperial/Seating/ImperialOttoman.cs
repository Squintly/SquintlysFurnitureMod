using SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Ottomans;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Seating;

internal class ImperialOttoman : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 18;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<Ottomans_3>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}