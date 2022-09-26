using SquintlysFurnitureMod.Content.Items.Blocks;
using SquintlysFurnitureMod.Content.WallTiles;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.WallItems;

public class PolishedSandstoneBrickWallItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Polished Sandstone Brick Wall");
		base.Tooltip.SetDefault("Okay, maybe it's a *little* shiny");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 400;
	}

	public override void SetDefaults()
	{
		base.Item.width = 16;
		base.Item.height = 16;
		base.Item.maxStack = 999;
		base.Item.useTurn = true;
		base.Item.autoReuse = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 7;
		base.Item.useStyle = 1;
		base.Item.consumable = true;
		base.Item.createWall = ModContent.WallType<PolishedSandstoneBrickWall>();
	}

	public override void AddRecipes()
	{
		base.CreateRecipe(4).AddIngredient<PolishedSandstoneBrickItem>().AddTile(18)
			.Register();
	}
}
