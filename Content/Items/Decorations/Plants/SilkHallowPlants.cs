using SquintlysFurnitureMod.Content.Tiles.Decorations.Plants;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Plants;

internal class SilkHallowPlants : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Silk Hallow Plants");
		base.Tooltip.SetDefault("Absolutely ingest for rad unicorn times (side effects include death)");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 16;
		base.Item.height = 16;
		base.Item.value = Item.buyPrice(0, 0, 7);
		base.Item.maxStack = 999;
		base.Item.useStyle = 1;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;
		base.Item.autoReuse = true;
		base.Item.consumable = true;
		base.Item.createTile = ModContent.TileType<SilkHallowPlantsTile>();
	}

	public override void AddRecipes()
	{
		base.CreateRecipe().AddIngredient(369).AddIngredient(225)
			.AddTile(18)
			.Register();
	}
}
