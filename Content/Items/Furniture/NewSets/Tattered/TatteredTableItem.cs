using Terraria.ID;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Tattered;

internal class TatteredTableItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Tattered Table");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.value = Item.buyPrice(copper: 60);
		base.Item.maxStack = 999;

		base.Item.useStyle = (ItemUseStyleID.Swing);
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;
		base.Item.autoReuse = true;

		base.Item.consumable = true;
		base.Item.createTile = ModContent.TileType<Tiles.Furniture.NewSets.Tattered.TatteredTableTile>();

	}
    public override void AddRecipes()
    {
		CreateRecipe(1)
			.AddIngredient(ItemID.Wood, 8)
			.AddTile(TileID.WorkBenches)
            .AddCondition(Recipe.Condition.InGraveyardBiome)
            .Register();
    }
}
