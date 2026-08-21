using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bathroom.Toilets.Toilets_1.Items;

internal class Toilets_1_Items : ModItem
{
    public class Toilets_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Toilets_1_Items(0)); //TatteredToilet
            mod.AddContent(new Toilets_1_Items(1)); //RepairedToilet
            mod.AddContent(new Toilets_1_Items(2)); //StoneBrickToilet
            mod.AddContent(new Toilets_1_Items(3)); //RedBrickToiletd
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
            return "TatteredToilet";
        }
        if (style == 1)
        {
            return "RepairedToilet";
        }
        if (style == 2)
        {
            return "StoneBrickToilet";
        }
        if (style == 3)
        {
            return "RedBrickToilet";
        }
        throw new Exception("Invalid style");
    }

    public Toilets_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Toilets_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 30);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //TatteredToilet
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 6)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 1) //RepairedToilet
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(0)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 2) //StoneBrickToilet
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 6)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 3) //RedBrickToiletd
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 6)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}