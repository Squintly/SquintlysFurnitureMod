using SquintlysFurnitureMod.Content.Tiles.Multi.StandingWall.OneWide.OneThree.Big;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Future.Guns;

internal class FutureGunStanding : ModItem
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

        Item.DefaultToPlaceableTile(ModContent.TileType<MP_SW_1x3_B_LR_2>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.ExplosivePowder, 2)
            .AddRecipeGroup(RecipeGroupID.IronBar, 5)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}