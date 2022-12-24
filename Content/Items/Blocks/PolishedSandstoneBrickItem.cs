using SquintlysFurnitureMod.Content.Items.WallItems;
using SquintlysFurnitureMod.Content.Tiles.Blocks;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks;

internal class PolishedSandstoneBrickItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Polished Sandstone Brick");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 100;
	}

	public override void SetDefaults()
	{
		base.Item.width = 16;
		base.Item.height = 16;

        base.Item.maxStack = 999;

        base.Item.value = Item.buyPrice(copper:0);
		base.Item.rare = ItemRarityID.White;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<PolishedSandstoneBrickTile>();
	}

	public override void AddRecipes()
	{
		base.CreateRecipe()
			.AddIngredient(ItemID.SandstoneBrick)
			.AddTile(TileID.WorkBenches)
			.Register();

		base.CreateRecipe()
			.AddIngredient(ModContent.ItemType<PolishedSandstoneBrickWallItem>(), 4)
			.AddTile(TileID.WorkBenches)
			.Register();

        base.CreateRecipe()
            .AddIngredient(ModContent.ItemType<FadedHieroBlock1Item>(), 1)
            .AddTile(TileID.WorkBenches)
            .Register();

        base.CreateRecipe()
            .AddIngredient(ModContent.ItemType<FadedHieroBlock2Item>(), 1)
            .AddTile(TileID.WorkBenches)
            .Register();

        base.CreateRecipe()
            .AddIngredient(ModContent.ItemType<FadedHieroBlock3Item>(), 1)
            .AddTile(TileID.WorkBenches)
            .Register();

        base.CreateRecipe()
            .AddIngredient(ModContent.ItemType<FadedHieroBlock4Item>(), 1)
            .AddTile(TileID.WorkBenches)
            .Register();

        base.CreateRecipe()
            .AddIngredient(ModContent.ItemType<HieroBlock1Item>(), 1)
            .AddTile(TileID.WorkBenches)
            .Register();

        base.CreateRecipe()
            .AddIngredient(ModContent.ItemType<HieroBlock2Item>(), 1)
            .AddTile(TileID.WorkBenches)
            .Register();

        base.CreateRecipe()
            .AddIngredient(ModContent.ItemType<HieroBlock3Item>(), 1)
            .AddTile(TileID.WorkBenches)
            .Register();

        base.CreateRecipe()
            .AddIngredient(ModContent.ItemType<HieroBlock4Item>(), 1)
            .AddTile(TileID.WorkBenches)
            .Register();

        base.CreateRecipe()
            .AddIngredient(ModContent.ItemType<HieroWallSmallItem>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();

        base.CreateRecipe()
            .AddIngredient(ModContent.ItemType<FadedHieroWallSmallItem>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
