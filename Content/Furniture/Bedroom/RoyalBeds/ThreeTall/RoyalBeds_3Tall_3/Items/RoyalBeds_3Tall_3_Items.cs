using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bedroom.RoyalBeds.ThreeTall.RoyalBeds_3Tall_3.Items;

internal class ImperialRoyalBed : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<ImperialRoyalBeds>());
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 20)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}