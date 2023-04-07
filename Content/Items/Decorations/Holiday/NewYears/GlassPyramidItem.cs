using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.NewYears;
using SquintlysFurnitureMod.Content.Tiles.Decorations;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.NewYears;

internal class GlassPyramidItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Glass Pyramid");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 22;
		base.Item.height = 48;

		base.Item.value = Item.buyPrice(copper:1);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<GlassPyramid>();
	}

	public override void AddRecipes()
	{
		base.CreateRecipe()
			.AddIngredient(ItemID.Glass, 6)
            .AddTile(ModContent.TileType<DecoBoxTile>())
            .Register();
	}
}
