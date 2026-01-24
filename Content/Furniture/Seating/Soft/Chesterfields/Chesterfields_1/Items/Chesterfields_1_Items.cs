using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Chesterfields.Chesterfields_1.Items;

internal class Chesterfields_1_Items : ModItem
{
    public class Chesterfields_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Chesterfields_1_Items(0)); //StoneBrickChesterfield
            mod.AddContent(new Chesterfields_1_Items(1)); //RedBrickChesterfield
            mod.AddContent(new Chesterfields_1_Items(2)); //CinderblockChesterfield
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
            return "StoneBrickChesterfield";
        }
        if (style == 1)
        {
            return "RedBrickChesterfield";
        }
        if (style == 2)
        {
            return "CinderblockChesterfield";
        }

        throw new Exception("Invalid style");
    }

    public Chesterfields_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Chesterfields_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickChesterfield
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 8)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 1) //RedBrickChesterfield
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 8)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //CinderblockChesterfield
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 8)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}