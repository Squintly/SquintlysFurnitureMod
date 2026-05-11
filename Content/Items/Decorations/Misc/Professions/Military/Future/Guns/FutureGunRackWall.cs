using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Modern;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Modern.Guns;
using SquintlysFurnitureMod.Content.Tiles.Wall.ThreeWide.ThreeTwo;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Future.Guns;

internal class FutureGunRackWall : ModItem
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

        Item.DefaultToPlaceableTile(ModContent.TileType<W_3x2_4>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:Guns")
            .AddIngredient(ModContent.ItemType<ModernWeaponRack>())
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}