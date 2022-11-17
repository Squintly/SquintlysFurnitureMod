using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Tattered;

internal class TatteredBathtubItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Tattered Bathtub");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
        base.Item.width = 30;
        base.Item.height = 20;

        base.Item.value = Item.buyPrice(copper: 60);

		base.Item.maxStack = 999;

		base.Item.useStyle = (ItemUseStyleID.Swing);
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<Tiles.Furniture.NewSets.Tattered.TatteredBathtubTile>();

	}
    public override void AddRecipes()
    {
		CreateRecipe(1)
			.AddIngredient(ItemID.Wood, 14)
			.AddTile(TileID.WorkBenches)
            .AddCondition(Recipe.Condition.InGraveyardBiome)
            .Register();
    }
}
