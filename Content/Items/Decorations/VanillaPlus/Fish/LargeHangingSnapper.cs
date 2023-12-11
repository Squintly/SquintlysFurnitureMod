using SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Fish;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Fish;

internal class LargeHangingSnapper : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 19;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 7, copper: 50);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<LargeHangingFishTile>();
        Item.placeStyle = 3;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.RedSnapper)
            .Register();
    }
}