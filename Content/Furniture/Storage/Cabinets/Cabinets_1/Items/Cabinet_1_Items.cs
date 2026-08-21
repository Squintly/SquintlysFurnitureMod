using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Storage.Cabinets.Cabinets_1.Items;

internal class Cabinet_1_Items : ModItem
{
    public class Cabinet_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Cabinet_1_Items(0)); //StoneBrickCabinet
            mod.AddContent(new Cabinet_1_Items(1)); //RedBrickCabinet
            mod.AddContent(new Cabinet_1_Items(2)); //CinderblockCabinet
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
            return "StoneBrickCabinet";
        }

        if (style == 1)
        {
            return "RedBrickCabinet";
        }

        if (style == 2)
        {
            return "CinderblockCabinet";
        }

        throw new Exception("Invalid style");
    }

    public Cabinet_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Cabinets_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickCabinet
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }

        if (placeStyle == 1) //RedBrickCabinet
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }

        if (placeStyle == 2) //CinderblockCabinet
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}