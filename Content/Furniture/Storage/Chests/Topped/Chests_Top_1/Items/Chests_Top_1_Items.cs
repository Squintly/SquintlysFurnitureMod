using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Storage.Chests.Topped.Chests_Top_1.Items;

internal class Chests_Top_1_Items : ModItem
{
    public class Chests_Top_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Chests_Top_1_Items(0)); //StoneBrickChest
            mod.AddContent(new Chests_Top_1_Items(1)); //RedBrickChest
            mod.AddContent(new Chests_Top_1_Items(2)); //CinderblockChest
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
            return "StoneBrickChest";
        }

        if (style == 1)
        {
            return "RedBrickChest";
        }

        if (style == 2)
        {
            return "CinderblockChest";
        }

        throw new Exception("Invalid style");
    }

    public Chests_Top_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Chests_Top_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickChest
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }

        if (placeStyle == 1) //RedBrickChest
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }

        if (placeStyle == 2) //CinderblockChest
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}