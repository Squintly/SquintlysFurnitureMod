using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bathroom.Baths.Baths_1.Items;

internal class Baths_1_Items : ModItem
{
    public class Baths_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 4; i++)
            {
                mod.AddContent(new Baths_1_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        if (style == 0)
        {
            return "ImperialBathtub";
        }
        if (style == 1)
        {
            return "TatteredBathtub";
        }
        if (style == 2)
        {
            return "RepairedBathtub";
        }
        if (style == 3)
        {
            return "CinderblockBathtub";
        }
        throw new Exception("Invalid style");
    }

    public Baths_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Baths_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialBathtub
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 14)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //TatteredBathtub
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 14)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 2) //RepairedBathtub
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 7)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(1)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 3) //CinderblockBathtub
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 14)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}