using SquintlysFurnitureMod.Content.Tiles.Decorations.Misc;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc;

internal class DecorativeWebItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Decorative Web");
		base.Tooltip.SetDefault("Let my house stay spooky, gosh darn it!n/Requires support");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 10;
	}

	public override void SetDefaults()
	{
		base.Item.width = 16;
		base.Item.height = 16;
		base.Item.value = Item.buyPrice(0, 0, 0, 1);
		base.Item.maxStack = 999;
		base.Item.useStyle = 1;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;
		base.Item.autoReuse = true;
		base.Item.consumable = true;
		base.Item.createTile = ModContent.TileType<DecorativeWebTile>();
		base.Item.placeStyle = 0;
	}

	public override void AddRecipes()
	{
		base.CreateRecipe().AddIngredient(150, 5).Register();
	}
}
