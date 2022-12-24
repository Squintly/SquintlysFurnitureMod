using SquintlysFurnitureMod.Content.Tiles.Decorations.Misc;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc;

internal class DecorativeVineRope : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Decorative Vine Rope");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 10;
	}

	public override void SetDefaults()
	{
		base.Item.width = 32;
		base.Item.height = 24;

		base.Item.value = Item.buyPrice(copper:20);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<DecorativeRopeTile>();
		base.Item.placeStyle = 2;
	}

	public override void AddRecipes()
	{
		base.CreateRecipe()
			.AddIngredient(ItemID.VineRopeCoil)
			.Register();
	}
}
