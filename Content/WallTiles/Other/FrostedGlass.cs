using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Easter.Other;
using SquintlysFurnitureMod.Content.Items.WallItems.Other;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace SquintlysFurnitureMod.Content.WallTiles.Other;

public class FrostedGlass : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        Main.wallLight[Type] = true;
        WallID.Sets.Transparent[Type] |= true;
        AddMapEntry(new Color(187, 248, 252));
    }
}

public class FrostedRecipes : ModSystem
{
    public override void AddRecipes()
    {
        Recipe recipe = Recipe.Create(ItemID.Glass);
        recipe.AddIngredient(ModContent.ItemType<FrostedGlassItem>(), 4);
        recipe.Register();
    }
}