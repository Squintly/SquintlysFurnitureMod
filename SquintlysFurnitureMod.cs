using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod
{
	public class SquintlysFurnitureMod : Mod
	{
        //Recipes
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.Glass);
            recipe.AddIngredient<Content.Items.WallItems.FrostedGlassItem>(4);
            recipe.Register();
        }
    }
}