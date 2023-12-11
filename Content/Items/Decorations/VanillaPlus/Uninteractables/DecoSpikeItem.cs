using SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Uninteractables;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Uninteractables;

internal class DecoSpikeItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
    }

    public override void SetDefaults()
    {
        Item.width = 22;
        Item.height = 18;

        Item.value = Item.buyPrice(copper: 20);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<DecoSpikes>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Spike)
            .Register();
    }
}