using SquintlysFurnitureMod.Content.Furniture.Seating.Hard.Stools;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.Stools;

internal class VortexStool : ModItem
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
        Item.placeStyle = 39;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.VortexBrick, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
    }
}