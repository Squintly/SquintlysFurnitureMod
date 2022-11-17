using SquintlysFurnitureMod.Content.Tiles.Decorations.Hanging;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Hanging.Fish;

internal class SmallHangingFish : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Small Hanging Fish");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 28;
		base.Item.height = 32;

		base.Item.value = Item.buyPrice(silver:5);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<SmallHangingFishTile>();
	}

	public override void AddRecipes()
	{
		base.CreateRecipe()
			.AddIngredient(ItemID.Bass)
			.Register();

		base.CreateRecipe()
			.AddIngredient(ItemID.AtlanticCod)
			.Register();

		base.CreateRecipe()
			.AddIngredient(ItemID.Flounder).
			Register();

		base.CreateRecipe()
			.AddIngredient(ItemID.Salmon)
			.Register();

		base.CreateRecipe()
			.AddIngredient(ItemID.RedSnapper)
			.Register();

		base.CreateRecipe()
			.AddIngredient(ItemID.Trout)
			.Register();

		base.CreateRecipe()
			.AddIngredient(ItemID.Tuna)
			.Register();
	}
}
