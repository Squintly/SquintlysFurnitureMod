using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Storage.Chests.Chests_1.Items;

internal class Chests_1_Items : ModItem
{
    public class Chests_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Chests_1_Items(0)); //ImperialChest
            mod.AddContent(new Chests_1_Items(1)); //TatteredChest
            mod.AddContent(new Chests_1_Items(2)); //RepairedChest
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
            return "ImperialChest";
        }

        if (style == 1)
        {
            return "TatteredChest";
        }

        if (style == 2)
        {
            return "RepairedChest";
        }

        throw new Exception("Invalid style");
    }

    public Chests_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Chests_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialChest
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();
        }

        if (placeStyle == 1) //TatteredChest
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }

        if (placeStyle == 2) //RepairedChest
        {
            CreateRecipe()
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(1)).Type)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}