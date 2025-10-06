using SquintlysFurnitureMod.Content.Furniture.Seating.Hard.Stools;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.Stools;

internal class ObsidianStool : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 18;
        Item.height = 18;

        Item.value = Item.buyPrice(silver: 2);

        Item.DefaultToPlaceableTile(ModContent.TileType<Stools_2>());
        Item.placeStyle = 17;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.Obsidian, 2)
            .AddIngredient(ItemID.Hellstone, 2)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.Hellforge)
            .Register();
    }
}