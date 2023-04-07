using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Christmas;

internal class TippedTop : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Top");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 12;
		base.Item.height = 16;
		
		base.Item.value = Item.buyPrice(copper:1);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<FestiveClutter>();
		base.Item.placeStyle = 8;
	}

	public override void AddRecipes()
	{
		base.CreateRecipe()
			.AddRecipeGroup(RecipeGroupID.Wood, 1)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();
	}
}
