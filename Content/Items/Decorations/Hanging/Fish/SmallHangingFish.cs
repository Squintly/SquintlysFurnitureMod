using SquintlysFurnitureMod.Content.Tiles.Decorations.Hanging;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Hanging;

internal class SmallHangingFish : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Small Hanging Fish");
		base.Tooltip.SetDefault("Small fry in a big sea");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 28;
		base.Item.height = 32;
		base.Item.value = Item.buyPrice(0, 0, 5);
		base.Item.maxStack = 999;
		base.Item.useStyle = 1;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;
		base.Item.autoReuse = true;
		base.Item.consumable = true;
		base.Item.createTile = ModContent.TileType<SmallHangingFishTile>();
		base.Item.placeStyle = 0;
	}

	public override void AddRecipes()
	{
		base.CreateRecipe().AddIngredient(2300).Register();
		base.CreateRecipe().AddIngredient(2297).Register();
		base.CreateRecipe().AddIngredient(2301).Register();
		base.CreateRecipe().AddIngredient(2298).Register();
		base.CreateRecipe().AddIngredient(4401).Register();
		base.CreateRecipe().AddIngredient(2290).Register();
		base.CreateRecipe().AddIngredient(2299).Register();
	}
}
