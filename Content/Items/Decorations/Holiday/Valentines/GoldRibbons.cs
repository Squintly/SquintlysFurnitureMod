using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines;
using SquintlysFurnitureMod.Content.Items.Blocks;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines;

internal class GoldRibbons : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Gold Ribbons");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 16;
		base.Item.height = 10;

		base.Item.value = Item.buyPrice(copper:1);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<GoldRibbonTile>();
	}

	public override void AddRecipes()
	{
		base.CreateRecipe()
			.AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ModContent.ItemType<HeartfeltBlockItem>())
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
	}
}
