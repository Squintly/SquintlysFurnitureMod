using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Seating.Hard.Stools.Stools_1.Items;

internal class Stools_1_Items : ModItem
{
    public class Stools_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Stools_1_Items(0)); //CinderblockStool
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
            return "CinderblockStool";
        }

        throw new Exception("Invalid style");
    }

    public Stools_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Stools_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 30);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //CinderblockStool
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 4)
            .AddIngredient(ItemID.Silk, 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}