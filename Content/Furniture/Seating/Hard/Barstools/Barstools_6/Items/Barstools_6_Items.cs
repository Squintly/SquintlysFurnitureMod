using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Seating.Hard.Barstools.Barstools_6.Items;

internal class Barstools_6_Items : ModItem
{
    public class Barstools_6_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Barstools_6_Items(0)); //TatteredBarstool
            mod.AddContent(new Barstools_6_Items(1)); //RepairedBarstool
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
            return "TatteredBarstool";
        }
        if (style == 1)
        {
            return "RepairedBarstool";
        }

        throw new Exception("Invalid style");
    }

    public Barstools_6_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Barstools_6>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 30);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //TatteredBarstool
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }

        if (placeStyle == 1) //RepairedBarstool
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 2)
            .AddIngredient(ItemID.Silk)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(0)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}