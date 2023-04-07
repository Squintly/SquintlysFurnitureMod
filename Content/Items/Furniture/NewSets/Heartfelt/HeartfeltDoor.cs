using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt;
using SquintlysFurnitureMod.Content.Items.Blocks;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Heartfelt;

internal class HeartfeltDoor : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Heartfelt Door");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
        base.Item.width = 14;
        base.Item.height = 24;

        base.Item.value = Item.buyPrice(silver: 1);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = (ItemUseStyleID.Swing);
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<HeartfeltDoorClosed>();
    }
	public override void AddRecipes()
	{
		CreateRecipe(1)
			.AddIngredient(ModContent.ItemType<HeartfeltBlockItem>(), 6)
            //.AddIngredient(ItemID.Glass, 6)
            //.AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
			.Register();
	}
}
