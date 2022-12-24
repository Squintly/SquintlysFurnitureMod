using SquintlysFurnitureMod.Content.Tiles.Decorations.Misc;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Items.Blocks;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc;

internal class BrokenObeliskItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Broken Obelisk");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 22;
		base.Item.height = 22;

		base.Item.value = Item.buyPrice(copper:10);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<BrokenObeliskTile>();
	}

	public override void AddRecipes()
	{
		base.CreateRecipe()
			.AddIngredient(ItemID.SandstoneBrick, 10)
			.AddTile(TileID.WorkBenches)
			.Register();

        base.CreateRecipe()
            .AddIngredient(ModContent.ItemType<PolishedSandstoneBrickItem>(), 10)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
