using Terraria.ID;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Festive;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Festive;

internal class FestiveCandelabraItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Festive Candelabra");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
        base.Item.width = 18;
        base.Item.height = 32;

        base.Item.value = Item.buyPrice(silver: 3);
		base.Item.maxStack = 999;

		base.Item.useStyle = (ItemUseStyleID.Swing);
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<FestiveCandelabra>();

	}
    public override void AddRecipes()
    {
		CreateRecipe(1)
			.AddIngredient(ItemID.CandyCaneBlock, 5)
			.AddIngredient(ItemID.Torch, 3)
			.AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        CreateRecipe(1)
            .AddIngredient(ItemID.GreenCandyCaneBlock, 5)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();

        CreateRecipe(1)
            .AddIngredient(ItemID.PineTreeBlock, 5)
            .AddIngredient(ItemID.Torch, 3)	
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();
    }
}
