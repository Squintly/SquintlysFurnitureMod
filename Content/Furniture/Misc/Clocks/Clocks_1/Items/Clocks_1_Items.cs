using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Clocks.Clocks_1.Items;

internal class Clocks_1_Items : ModItem
{
    public class Clocks_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Clocks_1_Items(0)); //ImperialClock
            mod.AddContent(new Clocks_1_Items(1)); //StoneBrickClock
            mod.AddContent(new Clocks_1_Items(2)); //RedBrickClock
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
            return "ImperialClock";
        }
        if (style == 1)
        {
            return "StoneBrickClock";
        }
        if (style == 2)
        {
            return "RedBrickClock";
        }

        throw new Exception("Invalid style");
    }

    public Clocks_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Clocks_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialClock
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 16)
            .AddIngredient(ItemID.Glass, 6)
            .AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //StoneBrickClock
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 16)
            .AddIngredient(ItemID.Glass, 6)
            .AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //RedBrickClock
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 16)
            .AddIngredient(ItemID.Glass, 8)
            .AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}