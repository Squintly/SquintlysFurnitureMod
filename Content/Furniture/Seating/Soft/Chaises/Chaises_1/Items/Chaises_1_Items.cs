using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Chaises.Chaises_1.Items;

internal class Chaises_1_Items : ModItem
{
    public class Chaises_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Chaises_1_Items(0)); //CinderblockChaise
            mod.AddContent(new Chaises_1_Items(1)); //StoneBrickChaise
            mod.AddContent(new Chaises_1_Items(2)); //RedBrickChaise
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
            return "CinderblockChaise";
        }
        if (style == 1)
        {
            return "StoneBrickChaise";
        }
        if (style == 2)
        {
            return "RedBrickChaise";
        }

        throw new Exception("Invalid style");
    }

    public Chaises_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Chaises_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //CinderblockChaise
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 6)
            .AddIngredient(ItemID.Silk, 3)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 1) //StoneBrickChaise
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 6)
            .AddIngredient(ItemID.Silk, 3)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //RedBrickChaise
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 6)
            .AddIngredient(ItemID.Silk, 3)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
       
    }
}