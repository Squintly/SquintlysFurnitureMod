using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bedroom.Beds.ThreeTall.Beds_3Tall_1.Items;

internal class Beds_3Tall_1_Items : ModItem
{
    public class Beds_4Tall_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Beds_3Tall_1_Items(0)); //StoneBrickCanopyBed
            mod.AddContent(new Beds_3Tall_1_Items(1)); //RedBrickCanopyBed
            mod.AddContent(new Beds_3Tall_1_Items(2)); //CinderBlockCanopyBed
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
            return "StoneBrickCanopyBed";
        }
        if (style == 1)
        {
            return "RedBrickCanopyBed";
        }
        if (style == 2)
        {
            return "CinderblockCanopyBed";
        }

        throw new Exception("Invalid style");
    }

    public Beds_3Tall_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Beds_3Tall_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 4);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickCanopyBed
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 1) //RedBrickCanopyBed
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //CinderBlockCanopyBed
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 15)
            .AddIngredient(ItemID.Silk, 5)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}