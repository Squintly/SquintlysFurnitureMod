using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bedroom.Beds.TwoTall.Beds_2Tall_1.Items;

internal class Beds_2Tall_1_Items : ModItem
{
    public class Beds_2Tall_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Beds_2Tall_1_Items(0)); //StoneBrickBed
            mod.AddContent(new Beds_2Tall_1_Items(1)); //RedBrickBed
            mod.AddContent(new Beds_2Tall_1_Items(2)); //CinderblockBed
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
            return "StoneBrickBed";
        }
        if (style == 1)
        {
            return "RedBrickBed";
        }
        if (style == 2)
        {
            return "CinderblockBed";
        }

        throw new Exception("Invalid style");
    }

    public Beds_2Tall_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Beds_2Tall_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 4);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickBed
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 1) //RedBrickBed
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //CinderblockBed
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}