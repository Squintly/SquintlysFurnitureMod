using SquintlysFurnitureMod.Content.Tiles.Wall.ThreeWide.ThreeTwo;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Modern.Guns;

internal class GunRackWall : ModItem
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

        Item.DefaultToPlaceableTile(ModContent.TileType<W_3x2_8>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.ExplosivePowder, 6)
            .AddRecipeGroup(RecipeGroupID.IronBar, 12)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}