using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.CeilingLamps.CeilingLamps_2.Items;

internal class CeilingLamps_2_Items : ModItem
{
    public class CeilingLamps_2_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new CeilingLamps_2_Items(0)); //TatteredCeilingLamp
            mod.AddContent(new CeilingLamps_2_Items(1)); //RepairedCeilingLamp
            mod.AddContent(new CeilingLamps_2_Items(2)); //StoneBrickCeilingLamp
            mod.AddContent(new CeilingLamps_2_Items(3)); //RedBrickCeilingLamp
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
            return "TatteredCeilingLamp";
        }
        if (style == 1)
        {
            return "RepairedCeilingLamp";
        }
        if (style == 2)
        {
            return "StoneBrickCeilingLamp";
        }
        if (style == 3)
        {
            return "RedBrickCeilingLamp";
        }

        throw new Exception("Invalid style");
    }

    public CeilingLamps_2_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<CeilingLamps_2>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 30);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //TatteredCeilingLamp
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 1) //RepairedCeilingLamp
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 2)
            .AddIngredient(ItemID.Torch)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(0)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 2) //StoneBrickCeilingLamp
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 3) //RedBrickCeilingLamp
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}