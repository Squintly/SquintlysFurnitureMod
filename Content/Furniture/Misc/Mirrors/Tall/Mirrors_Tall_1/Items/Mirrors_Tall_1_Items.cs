using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Mirrors.Tall.Mirrors_Tall_1.Items;

internal class Mirrors_Tall_1_Items : ModItem
{
    public class Mirrors_Tall_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Mirrors_Tall_1_Items(0)); //ImperialTallMirror
            mod.AddContent(new Mirrors_Tall_1_Items(1)); //StoneBrickTallMirror
            mod.AddContent(new Mirrors_Tall_1_Items(2)); //RedBrickTallMirror
            mod.AddContent(new Mirrors_Tall_1_Items(3)); //CinderblockTallMirror
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
            return "ImperialTallMirror";
        }
        if (style == 1)
        {
            return "StoneBrickTallMirror";
        }
        if (style == 2)
        {
            return "RedBrickTallMirror";
        }
        if (style == 3)
        {
            return "CinderblockTallMirror";
        }

        throw new Exception("Invalid style");
    }

    public Mirrors_Tall_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Mirrors_Tall_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 2);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialWideMirror
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //StoneBrickWideMirror
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //RedBrickWideMirror
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 3) //CinderblockWideMirror
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}