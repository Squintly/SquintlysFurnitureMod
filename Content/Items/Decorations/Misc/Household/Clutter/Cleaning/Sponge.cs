using SquintlysFurnitureMod.Content.Tiles.Decorations.Misc.Household.Clutter.Cleaning;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Clutter.Cleaning;

internal class Sponge : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 8;

        Item.value = Item.buyPrice(gold: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<SpongeTile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.HoneyAbsorbantSponge)
            .AddTile(TileID.HeavyWorkBench)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.LavaAbsorbantSponge)
            .AddTile(TileID.HeavyWorkBench)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.SuperAbsorbantSponge)
            .AddTile(TileID.HeavyWorkBench)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.UltraAbsorbantSponge)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}