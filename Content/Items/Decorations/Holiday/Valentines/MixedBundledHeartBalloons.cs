using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines;

internal class MixedBundledHeartBalloons : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Mixed Bundled Heart Balloons");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 28;
		base.Item.height = 32;

		base.Item.value = Item.buyPrice(copper:1);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<MixedBundledHeartBalloonTile>();
    }

	public override void AddRecipes()
	{
		base.CreateRecipe()
			.AddIngredient(ModContent.ItemType<WhiteHeartBalloon>())
            .AddIngredient(ModContent.ItemType<HeartBalloon>())
            .AddIngredient(ModContent.ItemType<GoldHeartBalloon>())
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
	}
}
