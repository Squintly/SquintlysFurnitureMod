using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Sofas.Sofas_1.Items;

internal class Sofas_1_Items : ModItem
{
    public class Sofas_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Sofas_1_Items(0)); //FestiveSofa
            mod.AddContent(new Sofas_1_Items(1)); //StoneBrickSofa
            mod.AddContent(new Sofas_1_Items(2)); //RedBrickSofa
            mod.AddContent(new Sofas_1_Items(3)); //CinderblockSofa
            mod.AddContent(new Sofas_1_Items(4)); //CinderblockBench
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
            return "FestiveSofa";
        }

        if (style == 1)
        {
            return "StoneBrickSofa";
        }

        if (style == 2)
        {
            return "RedBrickSofa";
        }

        if (style == 3)
        {
            return "CinderblockSofa";
        }

        if (style == 4)
        {
            return "CinderblockBench";
        }

        throw new Exception("Invalid style");
    }

    public Sofas_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Sofas_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //FestiveSofa
        {
            CreateRecipe()
            .AddRecipeGroup("SquintlyFurnitureMod:Festive", 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<FestiveWorktable>())
            .Register();
        }

        if (placeStyle == 1) //StoneBrickSofa
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }

        if (placeStyle == 2) //RedBrickSofa
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }

        if (placeStyle == 3 | placeStyle == 4) //CinderblockSofa
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}