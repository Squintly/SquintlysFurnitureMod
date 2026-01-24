using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bathroom.Baths.Baths_1.Items;

internal class ConfusinglyLargeBathtubItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 20;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<ConfusinglyLargeBathtub>());
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 30)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}