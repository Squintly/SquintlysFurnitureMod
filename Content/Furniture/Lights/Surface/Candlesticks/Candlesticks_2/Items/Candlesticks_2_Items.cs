using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Surface.Candlesticks.Candlesticks_2.Items;

internal class Candlesticks_2_Items : ModItem
{
    public class Candlesticks_2_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Candlesticks_2_Items(0)); //StoneBrickCandlestick
            mod.AddContent(new Candlesticks_2_Items(1)); //RedBrickCandlestick
            mod.AddContent(new Candlesticks_2_Items(2)); //CinderblockCandlestick
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
            return "StoneBrickCandlestick";
        }
        if (style == 1)
        {
            return "RedBrickCandlestick";
        }
        if (style == 2)
        {
            return "CinderblockCandlestick";
        }

        throw new Exception("Invalid style");
    }

    public Candlesticks_2_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Candlesticks_2>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickCandlestick
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 1) //RedBrickCandlestick
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //CinderblockCandlestick
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}