using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bedroom.Nightstands.Nightstands_1.Items;

internal class Nightstands_1_Items : ModItem
{
    public class Nightstands_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Nightstands_1_Items(0)); //ImperialNightstand
            mod.AddContent(new Nightstands_1_Items(1)); //TatteredNightstand
            mod.AddContent(new Nightstands_1_Items(2)); //RepairedNightstand
            mod.AddContent(new Nightstands_1_Items(3)); //StoneBrickNightstand
            mod.AddContent(new Nightstands_1_Items(4)); //RedBrickNightstand
            mod.AddContent(new Nightstands_1_Items(5)); //CinderblockNightstand
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
            return "ImperialNightstand";
        }
        if (style == 1)
        {
            return "TatteredNightstand";
        }
        if (style == 2)
        {
            return "RepairedNightstand";
        }
        if (style == 3)
        {
            return "StoneBrickNightstand";
        }
        if (style == 4)
        {
            return "RedBrickNightstand";
        }
        if (style == 5)
        {
            return "CinderblockNightstand";
        }
        throw new Exception("Invalid style");
    }

    public Nightstands_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Nightstands_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialNightstand
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //TatteredNightstand
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 2) //RepairedNightstand
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddRecipeGroup(RecipeGroupID.IronBar, 1)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(1)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 3) //StoneBrickNightstand
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 4) //RedBrickNightstand
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 5) //CinderblockNightstand
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}