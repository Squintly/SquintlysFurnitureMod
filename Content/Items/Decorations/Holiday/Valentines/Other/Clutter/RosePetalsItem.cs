using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines.Other;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines.Other.Clutter;

internal class RosePetalsItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 14;
        Item.height = 8;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<RosePetals>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.FlowerPacketRed)
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
    }
}