using Terraria.ID;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Festive;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Festive;

internal class FestiveSinkItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Festive Sink");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
        base.Item.width = 16;
        base.Item.height = 17;

        base.Item.value = Item.buyPrice(copper: 60);
		base.Item.maxStack = 999;

		base.Item.useStyle = (ItemUseStyleID.Swing);
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<FestiveSink>();

	}
    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.CandyCaneBlock, 6)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        CreateRecipe(1)
            .AddIngredient(ItemID.GreenCandyCaneBlock, 6)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        CreateRecipe(1)
            .AddIngredient(ItemID.PineTreeBlock, 6)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();
    }
}
