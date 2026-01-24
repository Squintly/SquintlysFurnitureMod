using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bedroom.Beds.TwoTall.Beds_2Tall_3.Items;

internal class ImperialBed : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 30;

        Item.value = Item.buyPrice(silver: 4);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<ImperialBeds>());
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}