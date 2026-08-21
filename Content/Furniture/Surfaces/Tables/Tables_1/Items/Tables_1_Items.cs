using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Surfaces.Tables.Tables_1.Items;

internal class Tables_1_Items : ModItem
{
    public class Tables_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Tables_1_Items(0)); //ImperialBar
            mod.AddContent(new Tables_1_Items(1)); //ImperialConsole
            mod.AddContent(new Tables_1_Items(2)); //TatteredBar
            mod.AddContent(new Tables_1_Items(3)); //TatteredConsole
            mod.AddContent(new Tables_1_Items(4)); //RepairedBar
            mod.AddContent(new Tables_1_Items(5)); //RepairedConsole
            mod.AddContent(new Tables_1_Items(6)); //CinderblockTable
            mod.AddContent(new Tables_1_Items(7)); //CinderblockBar
            mod.AddContent(new Tables_1_Items(8)); //CinderblockConsole
            mod.AddContent(new Tables_1_Items(9)); //StoneBrickCoveredTable
            mod.AddContent(new Tables_1_Items(10)); //RedBrickCoveredTable
            mod.AddContent(new Tables_1_Items(11)); //CinderblockCoveredTable
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
            return "ImperialConsole";
        }
        if (style == 1)
        {
            return "ImperialBar";
        }
        if (style == 2)
        {
            return "TatteredConsole";
        }
        if (style == 3)
        {
            return "TatteredBar";
        }
        if (style == 4)
        {
            return "RepairedConsole";
        }
        if (style == 5)
        {
            return "RepairedBar";
        }
        if (style == 6)
        {
            return "CinderblockTable";
        }
        if (style == 7)
        {
            return "CinderblockBar";
        }
        if (style == 8)
        {
            return "CinderblockConsole";
        }
        if (style == 9)
        {
            return "StoneBrickCoveredTable";
        }
        if (style == 10)
        {
            return "RedBrickCoveredTable";
        }
        if (style == 11)
        {
            return "CinderblockCoveredTable";
        }

        throw new Exception("Invalid style");
    }

    public Tables_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tables_1>(), placeStyle);

        Item.width = 16;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0 | placeStyle == 1) //ImperialConsole, ImperialBar
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 8)
            .AddTile(TileID.WorkBenches)
            .Register();
        }

        if (placeStyle == 2 | placeStyle == 3) //TatteredConsole, TatteredBar
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 8)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }

        if (placeStyle == 4) //RepairedConsole, RepairedBar
        {
            CreateRecipe(1)
           .AddRecipeGroup(RecipeGroupID.Wood, 4)
           .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(2)).Type)
           .AddTile(TileID.WorkBenches)
           .Register();
        }

        if (placeStyle == 5) //RepairedConsole, RepairedBar
        {
            CreateRecipe(1)
           .AddRecipeGroup(RecipeGroupID.Wood, 4)
           .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(3)).Type)
           .AddTile(TileID.WorkBenches)
           .Register();
        }

        if (placeStyle == 6 | placeStyle == 7 | placeStyle == 8) //CinderblockTable, CinderblockBar, CinderblockConsole
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 8)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }

        if (placeStyle == 9) //StoneBrickCoveredTable
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 8)
            .AddIngredient(ItemID.Silk, 4)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }

        if (placeStyle == 10) //RedBrickCoveredTable
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 8)
            .AddIngredient(ItemID.Silk, 4)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }

        if (placeStyle == 11) //CinderblockCoveredTable
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 8)
            .AddIngredient(ItemID.Silk, 4)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}