using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Doors.Doors_Windowed.Items;

internal class Doors_Windowed_Items : ModItem
{
    public class Doors_Windowed_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Doors_Windowed_Items(0)); //ImperialWindowedDoor
            mod.AddContent(new Doors_Windowed_Items(1)); //ImperialWindowedDoorRound
            mod.AddContent(new Doors_Windowed_Items(2)); //TatteredWindowedDoor
            mod.AddContent(new Doors_Windowed_Items(3)); //TatteredWindowedDoorRound
            mod.AddContent(new Doors_Windowed_Items(4)); //RepairedWindowedDoor
            mod.AddContent(new Doors_Windowed_Items(5)); //RepairedWindowedDoorRound
            mod.AddContent(new Doors_Windowed_Items(6)); //CinderblockWindowedDoor
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
            return "ImperialDoorWindowed";
        }
        if (style == 1)
        {
            return "ImperialDoorRoundWindowed";
        }
        if (style == 2)
        {
            return "TatteredDoorWindowed";
        }
        if (style == 3)
        {
            return "TatteredDoorRoundWindowed";
        }
        if (style == 4)
        {
            return "RepairedDoorWindowed";
        }
        if (style == 5)
        {
            return "RepairedDoorRoundWindowed";
        }
        if (style == 6)
        {
            return "CinderblockDoorWindowed";
        }

        throw new Exception("Invalid style");
    }

    public Doors_Windowed_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Doors_Windowed_Closed>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 2);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialWindowedDoor
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 6)
            .AddIngredient(ItemID.Glass)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //ImperialWindowedDoorRound
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 6)
            .AddIngredient(ItemID.Glass)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 2) //TatteredWindowedDoor
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 6)
            .AddIngredient(ItemID.Glass)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 3) //TatteredWindowedDoorRound
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 6)
            .AddIngredient(ItemID.Glass)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 4) //RepairedWindowedDoor
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(2)).Type)
            .AddIngredient(ItemID.Glass)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 5) //RepairedWindowedDoorRound
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(3)).Type)
            .AddIngredient(ItemID.Glass)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 6) //CinderblockWindowedDoor
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 6)
            .AddIngredient(ItemID.Glass)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}