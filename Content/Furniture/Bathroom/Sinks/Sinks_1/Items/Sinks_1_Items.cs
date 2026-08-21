using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bathroom.Sinks.Sinks_1.Items;

internal class Sinks_1_Items : ModItem
{
    public class Sinks_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Sinks_1_Items(0)); //CinderblockSink
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
            return "CinderblockSink";
        }
        throw new Exception("Invalid style");
    }

    public Sinks_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Sinks_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //CinderblockSink
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 6)
            .AddIngredient(ItemID.WaterBucket)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}