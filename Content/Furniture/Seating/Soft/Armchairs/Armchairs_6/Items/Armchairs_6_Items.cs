using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Armchairs.Armchairs_6.Items;

internal class Armchairs_6_Items : ModItem
{
    public class Armchairs_6_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Armchairs_6_Items(0)); //TatteredArmchair
            mod.AddContent(new Armchairs_6_Items(1)); //TatteredLawnchair
            mod.AddContent(new Armchairs_6_Items(2)); //RepairedArmchair
            mod.AddContent(new Armchairs_6_Items(3)); //RepairedLawnchair
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
            return "TatteredArmchair";
        }
        if (style == 1)
        {
            return "TatteredLawnchair";
        }
        if (style == 2)
        {
            return "RepairedArmchair";
        }
        if (style == 3)
        {
            return "RepairedLawnchair";
        }

        throw new Exception("Invalid style");
    }

    public Armchairs_6_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Armchairs_6>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 40);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //TatteredArmchair
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }

        if (placeStyle == 1) //TatteredLawnchair
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }

        if (placeStyle == 2) //RepairedArmchair
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 2)
            .AddIngredient(ItemID.Silk, 1)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(0)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }

        if (placeStyle == 3) //RepairedLawnchair
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 2)
            .AddIngredient(ItemID.Silk, 1)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(1)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}