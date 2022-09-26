using SquintlysFurnitureMod.Content.Tiles.Decorations.Misc;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc;

internal class BrokenObeliskItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Broken Obelisk");
		base.Tooltip.SetDefault("... and despair.");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 32;
		base.Item.height = 32;
		base.Item.value = Item.buyPrice(0, 0, 0, 20);
		base.Item.maxStack = 999;
		base.Item.useStyle = 1;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;
		base.Item.autoReuse = true;
		base.Item.consumable = true;
		base.Item.createTile = ModContent.TileType<BrokenObeliskTile>();
		base.Item.placeStyle = 0;
	}

	public override void AddRecipes()
	{
		base.CreateRecipe().AddIngredient(607, 10).Register();
	}
}
