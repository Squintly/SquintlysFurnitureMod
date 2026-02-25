using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Surfaces.Workbenches.WorkBenches_10.Items;

internal class WorkBenches_10_Items : ModItem
{
    public class WorkBenches_10_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new WorkBenches_10_Items(0)); //TatteredWorkBench
            mod.AddContent(new WorkBenches_10_Items(1)); //RepairedWorkBench
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
            return "TatteredWorkBench";
        }
        if (style == 1)
        {
            return "RepairedWorkBench";
        }

        throw new Exception("Invalid style");
    }

    public WorkBenches_10_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<WorkBenches_10>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 30);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //TatteredWorkBench
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 1) //RepairedWorkBench
        {
            CreateRecipe()
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(0)).Type)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
    }
}