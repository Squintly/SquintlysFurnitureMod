using IL.Terraria.GameContent.UI;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Plants;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Plants;

internal class SilkCorruptionPlants : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Silk Corruption Plants");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 24;
		base.Item.height = 26;

		base.Item.value = Item.buyPrice(silver:5);
		base.Item.rare = ItemRarityID.White;

		base.Item.maxStack = 999;

		base.Item.useStyle = ItemUseStyleID.Swing;
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;
		
		base.Item.createTile = ModContent.TileType<SilkCorruptionPlantsTile>();
	}

	public override void AddRecipes()
	{
        base.CreateRecipe()
            .AddIngredient(ItemID.CorruptSeeds)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
