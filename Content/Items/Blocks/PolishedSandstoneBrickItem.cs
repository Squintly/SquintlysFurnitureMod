using SquintlysFurnitureMod.Content.Items.WallItems;
using SquintlysFurnitureMod.Content.Tiles.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks;

internal class PolishedSandstoneBrickItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Polished Sandstone Brick");
		base.Tooltip.SetDefault("Not as shiny as it looks");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 100;
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
		base.Item.createTile = ModContent.TileType<PolishedSandstoneBrickTile>();
		base.Item.placeStyle = 0;
	}

	public override void AddRecipes()
	{
		base.CreateRecipe().AddIngredient(607).AddTile(18)
			.Register();
		base.CreateRecipe().AddIngredient(ModContent.ItemType<PolishedSandstoneBrickWallItem>(), 4).AddTile(18)
			.Register();
	}
}
