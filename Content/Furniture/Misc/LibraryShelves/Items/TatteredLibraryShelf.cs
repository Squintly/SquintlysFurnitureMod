using SquintlysFurnitureMod.Content.Furniture.Misc.Bookcases;
using SquintlysFurnitureMod.Content.Furniture.Misc.LibraryShelves;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.LibraryShelves.Items;

internal class TatteredLibraryShelf : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 30;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<LibraryShelves_3>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 20)
            .AddIngredient(ItemID.Book, 15)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
    }
}