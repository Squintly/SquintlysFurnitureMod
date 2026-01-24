using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Seating.Hard.Barstools.Barstools_1.Items;

internal class Barstools_1_Items : ModItem
{
    public class Barstools_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Barstools_1_Items(0)); //StoneBrickBarstool
            mod.AddContent(new Barstools_1_Items(1)); //RedBrickBarstool
            mod.AddContent(new Barstools_1_Items(2)); //CinderblockBarstool
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
            return "StoneBrickBarstool";
        }
        if (style == 1)
        {
            return "RedBrickBarstool";
        }
        if (style == 2)
        {
            return "CinderblockBarstool";
        }

        throw new Exception("Invalid style");
    }

    public Barstools_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Barstools_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 30);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickBarstool
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 4)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 1) //RedBrickBarstool
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 4)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //CinderblockBarstool
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 4)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}