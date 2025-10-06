using SquintlysFurnitureMod.Content.Tiles.Wall.ThreeWide.ThreeOne.Big;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Historical.Swords;

internal class SwordMounted : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 2);

        Item.DefaultToPlaceableTile(ModContent.TileType<W_3x1_B_LR_10>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.IronBar, 10)
            .AddRecipeGroup(RecipeGroupID.Wood, 5)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}