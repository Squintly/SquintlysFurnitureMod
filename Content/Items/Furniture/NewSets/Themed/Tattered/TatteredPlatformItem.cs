using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Themed.Tattered;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Tattered;

internal class TatteredPlatformItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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

        Item.createTile = ModContent.TileType<TatteredPlatformTile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
            .AddRecipeGroup(RecipeGroupID.Wood, 1)
            .AddCondition(Condition.InGraveyard)
            .Register();
    }
}