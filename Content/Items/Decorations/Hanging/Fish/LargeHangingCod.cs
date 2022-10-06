using SquintlysFurnitureMod.Content.Tiles.Decorations.Hanging;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Hanging.Fish;

internal class LargeHangingCod : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Hanging Cod");
		base.Tooltip.SetDefault("Cod dang it, again?");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 24;
		base.Item.height = 46;
		base.Item.value = Item.buyPrice(0, 0, 5);
		base.Item.maxStack = 999;
		base.Item.useStyle = 1;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;
		base.Item.autoReuse = true;
		base.Item.consumable = true;
		base.Item.createTile = ModContent.TileType<LargeHangingFishTile>();
		base.Item.placeStyle = 0;
	}

	public override void AddRecipes()
	{
		base.CreateRecipe().AddIngredient(2299).Register();
	}
}
