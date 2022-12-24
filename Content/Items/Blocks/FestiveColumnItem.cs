using SquintlysFurnitureMod.Content.Items.WallItems;
using SquintlysFurnitureMod.Content.Tiles.Blocks;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;

namespace SquintlysFurnitureMod.Content.Items.Blocks;

internal class FestiveColumnItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Festive Column");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 100;
	}

	public override void SetDefaults()
	{
		base.Item.width = 16;
		base.Item.height = 16;

		base.Item.value = Item.buyPrice(copper:0);
		base.Item.value = Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<FestiveColumn>();
	}

	public override void AddRecipes()
	{
        base.CreateRecipe()
           .AddIngredient(ItemID.CandyCaneBlock)
           .AddTile(ModContent.TileType<FestiveWorktable>())
           .Register();

        base.CreateRecipe()
           .AddIngredient(ItemID.GreenCandyCaneBlock)
           .AddTile(ModContent.TileType<FestiveWorktable>())
           .Register();

        base.CreateRecipe()
           .AddIngredient(ItemID.PineTreeBlock)
           .AddTile(ModContent.TileType<FestiveWorktable>())
           .Register();
    }
}
