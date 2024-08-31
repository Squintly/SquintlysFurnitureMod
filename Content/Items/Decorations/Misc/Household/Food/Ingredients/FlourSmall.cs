using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Easter.Other;
using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big;
using SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoTwo.Normal;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;

internal class FlourSmall : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 24;

        Item.value = Item.buyPrice(copper: 20);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<S_1x1_B_4>();
        Item.placeStyle = 7;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<Flour>(), 2)
            .AddTile(TileID.WorkBenches)
            .Register();

        CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<FlourBig>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
