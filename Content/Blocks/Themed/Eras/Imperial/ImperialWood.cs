using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;

public class ImperialWood : Solid
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(92, 54, 38));
    }
}

internal class ImperialWoodItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<ImperialWood>());

        Item.width = 28;
        Item.height = 22;

        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddIngredient(ItemID.DynastyWood, 2)
           .AddRecipeGroup("SquintlyFurnitureMod:GoldBar")
           .AddTile(TileID.WorkBenches)
           .Register();

        CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:ImperialPlatforms", 2)
            .Register();

        CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:ImperialWalls", 4)
            .Register();
    }
}