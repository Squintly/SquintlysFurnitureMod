using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt;
using SquintlysFurnitureMod.Content.Items.Blocks;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Heartfelt;

internal class BigHeartfeltPlatform : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Heartfelt Platform");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
        base.Item.width = 20;
        base.Item.height = 18;

        base.Item.value = Item.buyPrice(silver: 1);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = (ItemUseStyleID.Swing);
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<BigHeartfeltPlatformTile>();

	}
	public override void AddRecipes()
	{
		CreateRecipe(2)
			.AddIngredient(ModContent.ItemType<HeartfeltBlockItem>(), 1)
            //.AddIngredient(ItemID.Silk)
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
	}
}
