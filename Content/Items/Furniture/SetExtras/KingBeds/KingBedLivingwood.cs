using SquintlysFurnitureMod.Content.Tiles.Furniture.SetExtras.KingBeds;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.KingBeds;

internal class KingBedLivingwood : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 16;

        Item.value = Item.buyPrice(silver: 2);

        Item.useStyle = (ItemUseStyleID.Swing);
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<KingBeds4x2>();
        Item.placeStyle = 16;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.Wood, 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(TileID.LivingLoom)
            .Register();
    }
}