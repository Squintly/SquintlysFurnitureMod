using Terraria.ID;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Festive;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Festive;

internal class FestiveChandelierItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Festive Chandelier");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
        base.Item.width = 23;
        base.Item.height = 22;

        base.Item.value = Item.buyPrice(silver: 6);
		base.Item.maxStack = 999;

		base.Item.useStyle = (ItemUseStyleID.Swing);
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<FestiveChandelier>();

	}
    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.CandyCaneBlock, 4)
            .AddIngredient(ItemID.Torch, 4)
            .AddIngredient(ItemID.Chain)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        CreateRecipe(1)
            .AddIngredient(ItemID.GreenCandyCaneBlock, 4)
            .AddIngredient(ItemID.Torch, 4)
            .AddIngredient(ItemID.Chain)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        CreateRecipe(1).AddIngredient(ItemID.PineTreeBlock, 4)
            .AddIngredient(ItemID.Torch, 4)
            .AddIngredient(ItemID.Chain)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();
    }
}
