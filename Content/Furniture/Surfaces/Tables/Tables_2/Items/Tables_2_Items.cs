using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Surfaces.Tables.Tables_2.Items;

internal class Tables_2_Items : ModItem
{
    public class Tables_2_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Tables_2_Items(0)); //TatteredTable
            mod.AddContent(new Tables_2_Items(1)); //RepairedTable
            mod.AddContent(new Tables_2_Items(2)); //Stone BrickTable
            mod.AddContent(new Tables_2_Items(3)); //StoneBrickBar
            mod.AddContent(new Tables_2_Items(4)); //StoneBrickConsole
            mod.AddContent(new Tables_2_Items(5)); //RedBrickTable
            mod.AddContent(new Tables_2_Items(6)); //RedBrickBar
            mod.AddContent(new Tables_2_Items(7)); //RedBrickConsole
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
            return "TatteredTable";
        }
        if (style == 1)
        {
            return "RepairedTable";
        }
        if (style == 2)
        {
            return "StoneBrickTable";
        }
        if (style == 3)
        {
            return "StoneBrickBar";
        }
        if (style == 4)
        {
            return "StoneBrickConsole";
        }
        if (style == 5)
        {
            return "RedBrickTable";
        }
        if (style == 6)
        {
            return "RedBrickBar";
        }
        if (style == 7)
        {
            return "RedBrickConsole";
        }

        throw new Exception("Invalid style");
    }

    public Tables_2_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tables_2>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //TatteredTable
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 8)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }

        if (placeStyle == 1) //RepairedTable
        {
            CreateRecipe(1)
           .AddRecipeGroup(RecipeGroupID.Wood, 4)
           .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(0)).Type)
           .AddTile(TileID.WorkBenches)
           .Register();
        }

        if (placeStyle == 2 | placeStyle == 3 | placeStyle == 4) //StoneBrickTable, StoneBrickBar, StoneBrickConsole
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 8)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }

        if (placeStyle == 5 | placeStyle == 6 | placeStyle == 7) //RedBrickTable, RedBrickBar, RedBrickConsole
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 8)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}