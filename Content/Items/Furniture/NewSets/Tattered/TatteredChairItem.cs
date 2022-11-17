using Terraria.ID;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Tattered;

internal class TatteredChairItem : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Tattered Chair");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
        base.Item.width = 16;
        base.Item.height = 30;
        
		base.Item.value = Item.buyPrice(copper: 0);

        base.Item.maxStack = 999;

		base.Item.useStyle = (ItemUseStyleID.Swing);
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;

		base.Item.createTile = ModContent.TileType<Tiles.Furniture.NewSets.Tattered.TatteredChairTile>();

	}
    public override void AddRecipes()
    {
		CreateRecipe(1)
			.AddIngredient(ItemID.Wood, 4)
			.AddTile(TileID.WorkBenches)
            .AddCondition(Recipe.Condition.InGraveyardBiome)
            .Register();
    }
}
