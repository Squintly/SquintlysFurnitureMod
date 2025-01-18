//using SquintlysFurnitureMod.Content.Furniture.Misc.LibraryShelves;
//using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Tattered.Misc;
//using Terraria;
//using Terraria.GameContent.Creative;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Repaired.Misc;

//internal class RepairedLibraryShelf : ModItem
//{
//    public override void SetStaticDefaults()
//    {
//        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
//    }

//    public override void SetDefaults()
//    {
//        Item.width = 30;
//        Item.height = 30;

//        Item.value = Item.buyPrice(copper: 60);
//        Item.maxStack = Item.CommonMaxStack;

//        Item.DefaultToPlaceableTile(ModContent.TileType<LibraryShelves_3>());
//        Item.placeStyle = 0;
//    }

//    public override void AddRecipes()
//    {
//        CreateRecipe(1)
//            .AddRecipeGroup(RecipeGroupID.Wood, 10)
//            .AddIngredient(ItemID.Book, 7)
//            .AddIngredient(ModContent.ItemType<TatteredLibraryShelf>())
//            .AddTile(TileID.WorkBenches)
//            .Register();
//    }
//}