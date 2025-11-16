using SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Chesterfields;
using SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Sofas;
using SquintlysFurnitureMod.Content.Items.Blocks.Holiday.Spring;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Crafting.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Vernal;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Holiday.Vernal.Chairs;

internal class SpringtimeSofa : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 17;

        Item.value = Item.buyPrice(silver: 1);

        Item.DefaultToPlaceableTile(ModContent.TileType<Sofas_3>(), (int)Sofas_3.StyleID.Vernal);
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<SpringyWood>(), 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<FloralWorktable>())
            .Register();
    }
}