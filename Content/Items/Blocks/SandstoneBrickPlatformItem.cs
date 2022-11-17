using SquintlysFurnitureMod.Content.Tiles.Blocks;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks;

public class SandstoneBrickPlatformItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Sandstone Brick Platform");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 200;
	}

	public override void SetDefaults()
	{
		base.Item.width = 24;
		base.Item.height = 14;

		base.Item.maxStack = 999;

		base.Item.value = Item.buyPrice(copper:0);
		base.Item.rare = ItemRarityID.White;

        base.Item.useStyle = ItemUseStyleID.Swing;
        base.Item.useTurn = true;
        base.Item.useAnimation = 15;
        base.Item.useTime = 15;

        base.Item.autoReuse = true;
        base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<SandstoneBrickPlatform>();
	}

	public override void AddRecipes()
	{
		base.CreateRecipe(2)
			.AddIngredient(ItemID.SandstoneBrick)
			.AddTile(TileID.WorkBenches)
			.Register();
	}
}
