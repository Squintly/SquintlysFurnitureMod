using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Festive;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Festive;

internal class FestiveBedItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Festive Bed");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
        base.Item.width = 32;
        base.Item.height = 18;

        base.Item.value = Item.buyPrice(silver: 4);

		base.Item.maxStack = 999;

		base.Item.useStyle = (ItemUseStyleID.Swing);
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<FestiveBed>();

	}
    public override void AddRecipes()
    {
		CreateRecipe(1)
			.AddIngredient(ItemID.CandyCaneBlock, 15)
			.AddIngredient(ItemID.Silk, 5)
			.AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        CreateRecipe(1)
            .AddIngredient(ItemID.GreenCandyCaneBlock, 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        CreateRecipe(1)
            .AddIngredient(ItemID.PineTreeBlock, 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();	
    }
}
