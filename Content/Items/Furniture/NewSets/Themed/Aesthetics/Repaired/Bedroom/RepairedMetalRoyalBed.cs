using SquintlysFurnitureMod.Content.Furniture.Bedroom.RoyalBeds.ThreeTall;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Tattered.Bedroom;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Repaired.Bedroom;

internal class RepairedMetalRoyalBed : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 22;

        Item.value = Item.buyPrice(silver: 4);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<RoyalBeds_3Tall_12>());
        Item.placeStyle = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.Wood, 10)
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ModContent.ItemType<TatteredMetalRoyalBed>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}