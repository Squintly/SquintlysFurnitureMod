using SquintlysFurnitureMod.Content.Tiles.Decorations.Hanging;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Hanging;

internal class SmallZebraSkin : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Small Zebra Skin");
		base.Tooltip.SetDefault("A zorse is a zorse, of course");
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
		base.Item.createTile = ModContent.TileType<SmallAnimalSkinsTile>();
		base.Item.placeStyle = 2;
	}

	public override void AddRecipes()
	{
		base.CreateRecipe(2).AddIngredient(2283).AddTile(18)
			.Register();
	}
}
