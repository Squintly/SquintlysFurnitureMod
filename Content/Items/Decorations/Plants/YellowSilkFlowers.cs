using SquintlysFurnitureMod.Content.Tiles.Decorations.Plants;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Plants;

internal class YellowSilkFlowers : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Yellow Silk Flowers");
		base.Tooltip.SetDefault("All the color, none of the bees! (Maybe some of the bees. It's hard to tell.)");
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
		base.Item.createTile = ModContent.TileType<YellowSilkFlowersTile>();
	}

	public override void AddRecipes()
	{
		base.CreateRecipe().AddIngredient(4047).AddIngredient(225)
			.AddTile(18)
			.Register();
	}
}
