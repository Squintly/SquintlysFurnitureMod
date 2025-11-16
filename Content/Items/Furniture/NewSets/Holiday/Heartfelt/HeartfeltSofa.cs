using SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Sofas;
using SquintlysFurnitureMod.Content.Items.Blocks.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Crafting.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Heartfelt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Holiday.Heartfelt;

internal class HeartfeltSofa : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 23;
        Item.height = 15;

        Item.value = Item.buyPrice(silver: 1);

        Item.DefaultToPlaceableTile(ModContent.TileType<Sofas_LR>(), (int)Sofas_LR.StyleID.Heartfelt);
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<HeartfeltBlockItem>(), 5)
            .AddIngredient(ItemID.Silk, 2)
            //.AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
    }
}