using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.TrackLights.TrackLights_2.Items;

internal class TrackLights_2_Items : ModItem
{
    public class TrackLights_2_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new TrackLights_2_Items(0)); //CinderblockTrackLight
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
            return "CinderblockTrackLight";
        }

        throw new Exception("Invalid style");
    }

    public TrackLights_2_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<TrackLights_2>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //CinderblockTrackLight
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 6)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}