using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Surface.Candles.Candles_3.Items;

internal class Candles_3_Items : ModItem
{
    public class Candles_2_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Candles_3_Items(0)); //ImperialCandle
            mod.AddContent(new Candles_3_Items(1)); //TatteredCandle
            mod.AddContent(new Candles_3_Items(2)); //TatteredCandleSilver
            mod.AddContent(new Candles_3_Items(3)); //RepairedCandle
            mod.AddContent(new Candles_3_Items(4)); //RepairedCandleSilver
            mod.AddContent(new Candles_3_Items(5)); //StoneBrickCandle
            mod.AddContent(new Candles_3_Items(6)); //RedBrickCandle
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
            return "ImperialCandle";
        }
        if (style == 1)
        {
            return "TatteredCandle";
        }
        if (style == 2)
        {
            return "TatteredCandleSilver";
        }
        if (style == 3)
        {
            return "RepairedCandle";
        }
        if (style == 4)
        {
            return "RepairedCandleSilver";
        }
        if (style == 5)
        {
            return "StoneBrickCandle";
        }
        if (style == 6)
        {
            return "RedBrickCandle";
        }

        throw new Exception("Invalid style");
    }

    public Candles_3_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Candles_3>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialCandle
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //TatteredCandle
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 2) //TatteredCandleSilver
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 3) //RepairedCandle
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 2)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(1)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 4) //RepairedCandleSilver
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 2)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(2)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 5) //StoneBrickCandle
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 6) //RedBrickCandle
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}