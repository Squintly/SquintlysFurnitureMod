using SquintlysFurnitureMod.Content.Tiles.Multi.StandingWall.OneWide.OneFour.Big;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Modern.Explosives;

internal class GrenadeLauncherStanding : ModItem
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

        Item.DefaultToPlaceableTile(ModContent.TileType<MP_1x4_B_LR_3>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:Explosives", 4)
            .AddRecipeGroup(RecipeGroupID.IronBar, 4)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}