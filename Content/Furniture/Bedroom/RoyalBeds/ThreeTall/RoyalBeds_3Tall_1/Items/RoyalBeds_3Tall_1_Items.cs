using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bedroom.RoyalBeds.ThreeTall.RoyalBeds_3Tall_1.Items;

internal class RoyalBeds_3Tall_1_Items : ModItem
{
    public class RoyalBeds_3Tall_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new RoyalBeds_3Tall_1_Items(0)); //StoneBrickFourPoster
            mod.AddContent(new RoyalBeds_3Tall_1_Items(1)); //RedBrickFourPoster
            mod.AddContent(new RoyalBeds_3Tall_1_Items(2)); //CinderblockFourPoster
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
            return "StoneBrickFourPoster";
        }
        if (style == 1)
        {
            return "RedBrickFourPoster";
        }
        if (style == 2)
        {
            return "CinderblockFourPoster";
        }

        throw new Exception("Invalid style");
    }

    public RoyalBeds_3Tall_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<RoyalBeds_3Tall_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 4);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickFourPoster
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 20)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 1) //RedBrickFourPoster
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 20)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //CinderblockFourPoster
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 20)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}