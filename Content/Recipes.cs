using SquintlysFurnitureMod.Content.Items.WallItems;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content
{
    public class Recipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.Glass);
            recipe.AddIngredient(ModContent.ItemType<FrostedGlassItem>(), 4);
            recipe.Register();
        }
    }
}