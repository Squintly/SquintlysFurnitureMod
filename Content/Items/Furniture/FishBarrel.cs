using SquintlysFurnitureMod.Content.Tiles.Furniture;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture;

internal class FishBarrel : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Fish Barrel");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 22;
		base.Item.height = 32;

		base.Item.value = Item.buyPrice(silver:1);

		base.Item.maxStack = 999;

		base.Item.useStyle = 1;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<FishBarrelTile>();
		base.Item.placeStyle = 0;
	}

	public override void AddRecipes()
	{
		base.CreateRecipe()
			.AddRecipeGroup(RecipeGroupID.Wood, 9)
			.AddIngredient(RecipeGroupID.IronBar)
			.AddTile(TileID.Sawmill)
			.Register();
	}
}
