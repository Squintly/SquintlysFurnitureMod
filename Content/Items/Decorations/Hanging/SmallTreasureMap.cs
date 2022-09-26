using SquintlysFurnitureMod.Content.Tiles.Decorations.Hanging;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Hanging;

internal class SmallTreasureMap : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Small Treasure Map");
		base.Tooltip.SetDefault("For the pint-sized pirate crew");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 38;
		base.Item.height = 32;
		base.Item.value = Item.buyPrice(0, 0, 50);
		base.Item.maxStack = 999;
		base.Item.useStyle = 1;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;
		base.Item.autoReuse = true;
		base.Item.consumable = true;
		base.Item.createTile = ModContent.TileType<SmallTreasureMapTile>();
		base.Item.placeStyle = 0;
	}

	public override void AddRecipes()
	{
		base.CreateRecipe().AddIngredient(2495).AddTile(18)
			.Register();
	}
}
