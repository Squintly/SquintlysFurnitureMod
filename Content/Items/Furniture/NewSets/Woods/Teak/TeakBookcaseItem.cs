using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Woods.Teak;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Woods.Teak;

internal class TeakBookcaseItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<TeakBookcase>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<TeakWood>(), 20)
            .AddIngredient(ItemID.Book, 10)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}