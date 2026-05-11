using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Historical.Hammers;
using SquintlysFurnitureMod.Content.Tiles.Surface.ThreeWide.ThreeThree;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Historical.Picks;

internal class PickRack : ModItem
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

        Item.DefaultToPlaceableTile(ModContent.TileType<S_3x3_8>());
        Item.placeStyle = 3;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:Picks")
            .AddIngredient(ModContent.ItemType<WeaponStandEmpty>())
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}