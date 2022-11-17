using SquintlysFurnitureMod.Content.Items.WallItems;
using SquintlysFurnitureMod.Content.Tiles.Blocks;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks;

internal class FadedHieroBlock : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Faded Hieroglyphic Block");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 100;
	}

	public override void SetDefaults()
	{
		base.Item.width = 16;
		base.Item.height = 16;

		base.Item.value = Item.buyPrice(copper:0);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<FadedHieroBlockTile>();
	}

	public override void AddRecipes()
	{
		base.CreateRecipe()
			.AddIngredient(ModContent.ItemType<HieroBlock>())
			.AddTile(TileID.WorkBenches)
			.Register();

		base.CreateRecipe()
			.AddIngredient(ItemID.SandstoneBrick)
			.AddTile(TileID.WorkBenches)
			.Register();

		base.CreateRecipe()
			.AddIngredient(ModContent.ItemType<FadedHieroWallItem>(), 4)
			.AddTile(TileID.WorkBenches)
			.Register();
	}
}
