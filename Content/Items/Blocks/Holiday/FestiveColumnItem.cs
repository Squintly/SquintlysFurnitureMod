using SquintlysFurnitureMod.Content.Tiles.Blocks.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Blocks.Holiday;

internal class FestiveColumnItem : ModItem
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Festive Column");
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;

        Item.value = Item.buyPrice(copper: 0);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<FestiveColumn>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
           .AddRecipeGroup("SquintlyFurnitureMod:Festive")
           .AddTile(ModContent.TileType<FestiveWorktable>())
           .Register();
    }
}