using SquintlysFurnitureMod.Content.Tiles.Furniture.SetExtras.Armchairs;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.Armchairs;

internal class BambooArmchair : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Bamboo Armchair");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 2);

        Item.useStyle = (ItemUseStyleID.Swing);
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<ArmchairsTile>();
        Item.placeStyle = 43;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.BambooBlock, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}