using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bedroom.RoyalBeds.TwoTall.RoyalBeds_2Tall_1.Items;

internal class RoyalBeds_2Tall_1_Items : ModItem
{
    public class RoyalBeds_2_Tall_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new RoyalBeds_2Tall_1_Items(0)); //StoneBrickRoyalBed
            mod.AddContent(new RoyalBeds_2Tall_1_Items(1)); //RedBrickRoyalBed
            mod.AddContent(new RoyalBeds_2Tall_1_Items(2)); //CinderblockRoyalBed
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
            return "StoneBrickRoyalBed";
        }
        if (style == 1)
        {
            return "RedBrickRoyalBed";
        }
        if (style == 2)
        {
            return "CinderblockRoyalBed";
        }

        throw new Exception("Invalid style");
    }

    public RoyalBeds_2Tall_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<RoyalBeds_2Tall_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 4);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickRoyalBed
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 20)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 1) //RedBrickRoyalBed
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 20)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //CinderblockRoyalBed
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 20)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}