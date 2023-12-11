using SquintlysFurnitureMod.Content.Tiles.Furniture.SetExtras.CeilingLamps;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.CeilingLamps;

internal class CeilingLamp : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Ceiling Lamp");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;

        Item.value = Item.buyPrice(gold: 2);

        Item.useStyle = (ItemUseStyleID.HoldUp);
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<CeilingLampsTile>();
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.GoldBar)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches)
            .Register();

        CreateRecipe(1)
            .AddIngredient(ItemID.PlatinumBar)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}