using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Modern;
using SquintlysFurnitureMod.Content.Tiles.Surface.ThreeWide.ThreeThree;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Future.Guns;

internal class FutureGunStand : ModItem
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

        Item.DefaultToPlaceableTile(ModContent.TileType<S_3x3_6>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:Guns")
            .AddIngredient(ModContent.ItemType<ModernWeaponStand>())
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}