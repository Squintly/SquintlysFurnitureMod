using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bedroom.Dressers.Dressers_1.Items;

internal class Dressers_1_Items : ModItem
{
    public class Dressers_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Dressers_1_Items(0)); //ImperialDresser
            mod.AddContent(new Dressers_1_Items(1)); //RepairedDresser
            mod.AddContent(new Dressers_1_Items(2)); //StoneBrickDresser
            mod.AddContent(new Dressers_1_Items(3)); //RedBrickDresser
            mod.AddContent(new Dressers_1_Items(4)); //CinderblockDresser
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
            return "ImperialDresser";
        }
        if (style == 1)
        {
            return "RepairedDresser";
        }
        if (style == 2)
        {
            return "StoneBrickDresser";
        }
        if (style == 3)
        {
            return "RedBrickDresser";
        }
        if (style == 4)
        {
            return "CinderblockDresser";
        }
        throw new Exception("Invalid style");
    }

    public Dressers_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Dressers_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialDresser
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 16)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //RepairedDresser
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 8)
            .AddIngredient(Mod.Find<ModItem>(Dressers_Animated_1_Items.GetInternalNameFromStyle(0)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 2) //StoneBrickDresser
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 16)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 3) //RedBrickDresser
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 16)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 4) //CinderblockDresser
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 16)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}