using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Surfaces.Tables.Tables_12.Items;

internal class Tables_12_Items : ModItem
{
    public class Tables_12_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Tables_12_Items(0)); //TatteredCoveredTable
            mod.AddContent(new Tables_12_Items(1)); //RepairedCoveredTable
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
            return "TatteredCoveredTable";
        }
        if (style == 1)
        {
            return "RepairedCoveredTable";
        }

        throw new Exception("Invalid style");
    }

    public Tables_12_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tables_12>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //TatteredCoveredTable
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 8)
            .AddIngredient(ItemID.Silk, 4)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }

        if (placeStyle == 1) //RepairedCoveredTable
        {
            CreateRecipe(1)
           .AddRecipeGroup(RecipeGroupID.Wood, 4)
           .AddIngredient(ItemID.Silk, 4)
           .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(0)).Type)
           .AddTile(TileID.WorkBenches)
           .Register();
        }
    }
}