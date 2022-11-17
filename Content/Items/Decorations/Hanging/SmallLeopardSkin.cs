using SquintlysFurnitureMod.Content.Tiles.Decorations.Hanging;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Hanging;

internal class SmallLeopardSkin : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Small Leopard Skin");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 18;
		base.Item.height = 15;

		base.Item.value = Item.buyPrice(gold:1);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<SmallAnimalSkinsTile>();
		base.Item.placeStyle = 1;
	}

	public override void AddRecipes()
	{
		base.CreateRecipe(2)
			.AddIngredient(ItemID.LeopardSkin)
			.AddTile(TileID.WorkBenches)
			.Register();
	}
}
