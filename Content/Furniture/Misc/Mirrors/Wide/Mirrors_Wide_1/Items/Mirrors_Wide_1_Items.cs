using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Mirrors.Wide.Mirrors_Wide_1.Items;

internal class Mirrors_Wide_1_Items : ModItem
{
    public class Mirrors_Wide_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Mirrors_Wide_1_Items(0)); //ImperialWideMirror
            mod.AddContent(new Mirrors_Wide_1_Items(1)); //TatteredWideMirror
            mod.AddContent(new Mirrors_Wide_1_Items(2)); //RepairedWideMirror
            mod.AddContent(new Mirrors_Wide_1_Items(3)); //StoneBrickWideMirror
            mod.AddContent(new Mirrors_Wide_1_Items(4)); //RedBrickWideMirror
            mod.AddContent(new Mirrors_Wide_1_Items(5)); //CinderblockWideMirror
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
            return "ImperialWideMirror";
        }
        if (style == 1)
        {
            return "TatteredWideMirror";
        }
        if (style == 2)
        {
            return "RepairedWideMirror";
        }
        if (style == 3)
        {
            return "StoneBrickWideMirror";
        }
        if (style == 4)
        {
            return "RedBrickWideMirror";
        }
        if (style == 5)
        {
            return "CinderblockWideMirror";
        }

        throw new Exception("Invalid style");
    }

    public Mirrors_Wide_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Mirrors_Wide_1>(), placeStyle);

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
        if (placeStyle == 1) //TatteredWideMirror
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 2) //RepairedWideMirror
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(ItemID.Glass, 1)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar")
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(1)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 3) //StoneBrickWideMirror
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 4) //RedBrickWideMirror
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 5) //CinderblockWideMirror
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