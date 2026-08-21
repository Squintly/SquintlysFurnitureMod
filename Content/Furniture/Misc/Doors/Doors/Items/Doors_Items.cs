using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Doors.Doors.Items;

internal class Doors_Items : ModItem
{
    public class Doors_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Doors_Items(0)); //ImperialDoor
            mod.AddContent(new Doors_Items(1)); //ImperialDoorRound
            mod.AddContent(new Doors_Items(2)); //TatteredDoor
            mod.AddContent(new Doors_Items(3)); //TatteredDoorRound
            mod.AddContent(new Doors_Items(4)); //RepairedDoor
            mod.AddContent(new Doors_Items(5)); //RepairedDoorRound
            mod.AddContent(new Doors_Items(6)); //RedBrickDoor
            mod.AddContent(new Doors_Items(7)); //StoneBrickDoorBarred
            mod.AddContent(new Doors_Items(8)); //RedBrickDoorBarred
            mod.AddContent(new Doors_Items(9)); //CinderblockDoor
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
            return "ImperialDoor";
        }
        if (style == 1)
        {
            return "ImperialDoorRound";
        }
        if (style == 2)
        {
            return "TatteredDoor";
        }
        if (style == 3)
        {
            return "TatteredDoorRound";
        }
        if (style == 4)
        {
            return "RepairedDoor";
        }
        if (style == 5)
        {
            return "RepairedDoorRound";
        }
        if (style == 6)
        {
            return "RedBrickDoor";
        }
        if (style == 7)
        {
            return "StoneBrickDoorBarred";
        }
        if (style == 8)
        {
            return "RedBrickDoorBarred";
        }
        if (style == 9)
        {
            return "CinderblockDoor";
        }

        throw new Exception("Invalid style");
    }

    public Doors_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Doors_Closed>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 2);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialDoor
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 6)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //ImperialDoorRound
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 6)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 2) //TatteredDoor
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 6)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 3) //TatteredDoorRound
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 6)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 4) //RepairedDoor
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(2)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 5) //RepairedDoorRound
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(3)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 6) //RedBrickDoor
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 6)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 7) //StoneBrickDoorBarred
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 6)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 8) //RedBrickDoorBarred
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 6)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 9) //CinderblockDoor
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 6)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}