using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt;
using SquintlysFurnitureMod.Content.Items.Blocks;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Heartfelt;

internal class HeartfeltCraftingTable : ModItem
{
    public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Heartfelt Crafting Table");
        Tooltip.SetDefault("Used for special crafting");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
        base.Item.width = 24;
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

		base.Item.createTile = ModContent.TileType<HeartfeltCraftingTableTile>();
    }
	public override void AddRecipes()
	{
		CreateRecipe(1)
			.AddIngredient(ModContent.ItemType<HeartfeltBlockItem>(), 8)
			.AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.Glass)
            //.AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddTile(TileID.WorkBenches)
			.Register();
	}
}
