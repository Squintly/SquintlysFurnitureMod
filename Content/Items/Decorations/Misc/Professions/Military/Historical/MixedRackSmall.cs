using SquintlysFurnitureMod.Content.Tiles.Surface.ThreeWide.ThreeThree;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Historical;

internal class MixedRackSmall : ModItem
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

        Item.DefaultToPlaceableTile(ModContent.TileType<S_3x3_4>());
        Item.placeStyle = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:Weapons")
            .AddIngredient(ModContent.ItemType<WeaponStandEmpty>())
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}