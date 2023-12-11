using SquintlysFurnitureMod.Content.Tiles.Blocks.VanillaPlus;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks.VanillaPlus;

public class SandstoneBrickPlatformItem : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Sandstone Brick Platform");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 200;
    }

    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 14;

        Item.value = Item.buyPrice(copper: 0);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<SandstoneBrickPlatform>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
            .AddIngredient(ItemID.SandstoneBrick)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}