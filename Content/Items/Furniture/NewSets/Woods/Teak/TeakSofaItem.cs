using SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Sofas.Sofas_3;
using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Woods.Teak;

internal class TeakSofaItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 19;

        Item.value = Item.buyPrice(silver: 1);

        Item.DefaultToPlaceableTile(ModContent.TileType<Sofas_3>(), (int)Sofas_3.StyleID.Teak);
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<TeakWood>(), 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}