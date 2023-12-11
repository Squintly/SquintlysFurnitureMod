using SquintlysFurnitureMod.Content.Tiles.Decorations.Crafting;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Halloween.Decorations.BellJars;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Halloween.Other.BellJars;

internal class BellJarItemWorm : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<WormBell>();
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Glass, 6)
            .AddRecipeGroup(RecipeGroupID.Wood, 1)
            .AddIngredient(ItemID.RottenChunk)
            .AddTile(ModContent.TileType<DecoBoxTile>())
            .Register();
    }
}