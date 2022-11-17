using Terraria.ID;
using SquintlysFurnitureMod.Content.Tiles.Furniture.SetExtras;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.Armchairs;

internal class BoneArmchair : ModItem
{
	public override void SetStaticDefaults()
	{
		base.DisplayName.SetDefault("Bone Armchair");
		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[base.Type] = 1;
	}

	public override void SetDefaults()
	{
        base.Item.width = 30;
        base.Item.height = 32;

        base.Item.value = Item.buyPrice(silver: 2);
		base.Item.maxStack = 999;

		base.Item.useStyle = (ItemUseStyleID.Swing);
		base.Item.useTurn = true;
		base.Item.useAnimation = 15;
		base.Item.useTime = 15;

		base.Item.autoReuse = true;
		base.Item.consumable = true;
		
		base.Item.createTile = ModContent.TileType<Tiles.Furniture.SetExtras.Armchairs>();
		base.Item.placeStyle = 11;

	}
    public override void AddRecipes()
    {
		CreateRecipe(1)
			.AddIngredient(ItemID.Bone, 4)
			.AddIngredient(ItemID.Silk)
			.AddTile(TileID.BoneWelder)
			.Register();
    }
}
