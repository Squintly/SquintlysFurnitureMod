using SquintlysFurnitureMod.Content.Items.Blocks;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.WallTiles;

namespace SquintlysFurnitureMod.Content.Items.WallItems;

internal class SandstonePillarWallItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Sandstone Pillar Wall");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 100;
	}

	public override void SetDefaults()
	{
		base.Item.width = 32;
		base.Item.height = 32;

		base.Item.value = Item.buyPrice(copper:0);
		base.Item.value = Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createWall = ModContent.WallType<SandstonePillarWall>();
	}

	public override void AddRecipes()
	{
        base.CreateRecipe(4)
           .AddIngredient(ModContent.ItemType<SandstonePillarItem>())
           .AddTile(TileID.WorkBenches)
           .Register();
	}
}
