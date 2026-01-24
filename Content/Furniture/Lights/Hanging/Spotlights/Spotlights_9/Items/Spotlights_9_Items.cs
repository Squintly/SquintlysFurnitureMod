using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.Spotlights.Spotlights_9.Items;

internal class Spotlights_9_Items : ModItem
{
    public class Spotlights_9_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Spotlights_9_Items(0)); //TatteredSpotlight
            mod.AddContent(new Spotlights_9_Items(1)); //RepairedSpotlight
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
            return "TatteredSpotlight";
        }
        if (style == 1)
        {
            return "RepairedSpotlight";
        }
        throw new Exception("Invalid style");
    }

    public Spotlights_9_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Spotlights_9>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //TatteredSpotlight
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 5)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 1) //RepairedSpotlight
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(ItemID.Torch, 3)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(0)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}