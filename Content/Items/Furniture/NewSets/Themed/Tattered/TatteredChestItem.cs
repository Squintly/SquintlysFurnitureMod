using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Themed.Tattered;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Tattered;

internal class TatteredChestItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 30;

        Item.value = Item.buyPrice(silver: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<TatteredChest>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
    }
}