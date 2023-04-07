using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines;
using SquintlysFurnitureMod.Content.Items.Blocks;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines;

internal class ChocolateBowl : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Bowl of Chocolates");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 16;
		base.Item.height = 12;

		base.Item.value = Item.buyPrice(copper:1);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<Valentines1x1>();
        base.Item.placeStyle = 0;
    }

	public override void AddRecipes()
	{
		base.CreateRecipe()
			.AddIngredient(ItemID.Glass, 4)
            .AddIngredient(ModContent.ItemType<ChocolateBlockItem>())
            .AddTile(TileID.WorkBenches)
            .Register();
	}
}
