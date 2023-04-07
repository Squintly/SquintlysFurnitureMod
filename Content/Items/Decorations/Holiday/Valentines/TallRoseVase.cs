using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines;
internal class TallRoseVase : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Tall Rose Vase");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 6;
		base.Item.height = 26;

		base.Item.value = Item.buyPrice(copper:1);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<Vases>();
        base.Item.placeStyle = 1;
    }

	public override void AddRecipes()
	{
		base.CreateRecipe()
			.AddIngredient(ItemID.Glass, 3)
            .AddIngredient(ItemID.FlowerPacketRed)
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
	}
}
