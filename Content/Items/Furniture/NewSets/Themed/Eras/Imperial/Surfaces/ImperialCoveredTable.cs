using SquintlysFurnitureMod.Content.Furniture.Surfaces.Tables;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Surfaces;

internal class ImperialCoveredTable : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 26;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<Tables_3>());
        Item.placeStyle = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 8)
            .AddIngredient(ItemID.Silk, 4)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}