using SquintlysFurnitureMod.Content.Tiles.Multi.StandingWall.OneWide.OneFour.Big;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Historical.Spears;

internal class SpearLong : ModItem
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

        Item.DefaultToPlaceableTile(ModContent.TileType<MP_1x4_B_6>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.IronBar, 15)
            .AddRecipeGroup(RecipeGroupID.Wood, 5)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}