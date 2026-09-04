using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;
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
}