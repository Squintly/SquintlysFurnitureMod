using SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Plants.Reeds;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Plants.Reeds;

internal class SeaweedBasket : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 5);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<SilkSeaweed>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.GrassSeeds)
            .AddIngredient(ItemID.WaterBucket)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}