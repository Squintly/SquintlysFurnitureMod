using Terraria.ID;
using SquintlysFurnitureMod.Content.Tiles.Furniture.SetExtras;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.CeilingLamps;

internal class VortexCeilingLamp : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Vortex Ceiling Lamp");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
		base.Item.width = 16;
		base.Item.height = 16;

		base.Item.value = Item.buyPrice(gold: 2);
		base.Item.maxStack = 999;

		base.Item.useStyle = (ItemUseStyleID.HoldUp);
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;
		base.Item.autoReuse = true;

		base.Item.consumable = true;
		base.Item.createTile = ModContent.TileType<Tiles.Furniture.SetExtras.CeilingLampsTile>();
		base.Item.placeStyle = 36;

    }
    public override void AddRecipes()
    {
		CreateRecipe(1)
			.AddIngredient(ItemID.VortexBrick, 4)	
			.AddIngredient(ItemID.Torch)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
    }
}
