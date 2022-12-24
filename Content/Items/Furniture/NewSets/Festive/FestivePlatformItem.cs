using Terraria.ID;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Festive;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Festive;

internal class FestivePlatformItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Festive Platform");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
        base.Item.width = 24;
        base.Item.height = 14;

        base.Item.value = Item.buyPrice(copper: 0);
		base.Item.maxStack = 999;

		base.Item.useStyle = (ItemUseStyleID.Swing);
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<FestivePlatform>();

	}
    public override void AddRecipes()
    {
        CreateRecipe(4)
            .AddIngredient(ItemID.CandyCaneBlock)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        CreateRecipe(4)
            .AddIngredient(ItemID.GreenCandyCaneBlock)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        CreateRecipe(4)
            .AddIngredient(ItemID.PineTreeBlock)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();
    }
}
