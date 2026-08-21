using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bathroom.Sinks.Sinks_2.Items;

internal class Sinks_2_Items : ModItem
{
    public class Sinks_2_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Sinks_2_Items(0)); //ImperialSink
            mod.AddContent(new Sinks_2_Items(1)); //TatteredSink
            mod.AddContent(new Sinks_2_Items(2)); //RepairedSink
            mod.AddContent(new Sinks_2_Items(3)); //StoneBrickSink
            mod.AddContent(new Sinks_2_Items(4)); //RedBrickSinkd
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
            return "ImperialSink";
        }
        if (style == 1)
        {
            return "TatteredSink";
        }
        if (style == 2)
        {
            return "RepairedSink";
        }
        if (style == 3)
        {
            return "StoneBrickSink";
        }
        if (style == 4)
        {
            return "RedBrickSink";
        }
        throw new Exception("Invalid style");
    }

    public Sinks_2_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Sinks_2>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialSink
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 6)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //TatteredSink
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 6)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 2) //RepairedSink
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(ItemID.WaterBucket)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(1)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 3) //StoneBrickSink
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 6)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 4) //RedBrickSinkd
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 6)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}