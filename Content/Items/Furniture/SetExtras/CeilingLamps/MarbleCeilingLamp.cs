using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.CeilingLamps;

internal class MarbleCeilingLamp : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Marble Ceiling Lamp");
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
        Item.createTile = ModContent.TileType<Tiles.Furniture.SetExtras.CeilingLampsTile>();
        Item.placeStyle = 31;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.MarbleBlock, 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}