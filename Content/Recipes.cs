using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Items.WallItems;

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
