using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines;
using SquintlysFurnitureMod.Content.Items.Blocks;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines;

internal class HeartDecal : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Heart Decal");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 14;
		base.Item.height = 14;

		base.Item.value = Item.buyPrice(copper:1);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<Valentines1x1WallTile>();
        base.Item.placeStyle = 5;
    }

	public override void AddRecipes()
	{
		base.CreateRecipe(2)
			.AddIngredient(ItemID.Silk, 3)
            .AddIngredient(ModContent.ItemType<HeartfeltBlockItem>())
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
	}
}
