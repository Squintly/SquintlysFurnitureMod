using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content
{
    public class RedBrickRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.RedBrick);
            recipe.AddRecipeGroup("SquintlyFurnitureMod:RedBrickWalls", 4);
            recipe.Register();
        }
    }

    public class StoneBrickRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.GrayBrick);
            recipe.AddRecipeGroup("SquintlyFurnitureMod:StoneBrickWalls", 4);
            recipe.Register();
        }
    }
    public class EggRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.FriedEgg);
            recipe.AddRecipeGroup("SquintlyFurnitureMod:Eggs", 4);
            recipe.AddTile(TileID.CookingPots);
            recipe.Register();
        }
    }
    public class SilkRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.Silk);
            recipe.AddIngredient(ModContent.ItemType<ThreadItem>(), 4);
            recipe.AddTile(ModContent.TileType<SewingBox>());
            recipe.Register();
        }
    }
    public class FridgeRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.IceBlock);
            recipe.AddTile(ModContent.TileType<Fridges>());
            recipe.Register();

            recipe = Recipe.Create(ItemID.SnowBlock);
            recipe.AddTile(ModContent.TileType<Fridges>());
            recipe.Register();
        }
}
}