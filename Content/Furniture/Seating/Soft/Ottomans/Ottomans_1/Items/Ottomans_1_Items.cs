using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Ottomans.Ottomans_1.Items;

internal class Ottomans_1_Items : ModItem
{
    public class Ottomans_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Ottomans_1_Items(0)); //StoneBrickOttoman
            mod.AddContent(new Ottomans_1_Items(1)); //RedBrickOttoman
            mod.AddContent(new Ottomans_1_Items(2)); //CinderblockOttoman
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
            return "StoneBrickOttoman";
        }

        if (style == 1)
        {
            return "RedBrickOttoman";
        }

        if (style == 2)
        {
            return "CinderblockOttoman";
        }

        throw new Exception("Invalid style");
    }

    public Ottomans_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Ottomans_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickOttoman
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }

        if (placeStyle == 1) //RedBrickOttoman
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }

        if (placeStyle == 1) //CinderblockOttoman
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 5)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}