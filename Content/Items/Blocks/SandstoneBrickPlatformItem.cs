using SquintlysFurnitureMod.Content.Tiles.Blocks;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks;

public class SandstoneBrickPlatformItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Sandstone Brick Platform");
		base.Tooltip.SetDefault("Because matching is important.");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 200;
	}

	public override void SetDefaults()
	{
		base.Item.width = 8;
		base.Item.height = 10;
		base.Item.maxStack = 999;
		base.Item.useTurn = true;
		base.Item.autoReuse = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 10;
		base.Item.useStyle = 1;
		base.Item.consumable = true;
		base.Item.createTile = ModContent.TileType<SandstoneBrickPlatform>();
	}

	public override void AddRecipes()
	{
		base.CreateRecipe(2).AddIngredient(607).AddTile(18)
			.Register();
	}
}
