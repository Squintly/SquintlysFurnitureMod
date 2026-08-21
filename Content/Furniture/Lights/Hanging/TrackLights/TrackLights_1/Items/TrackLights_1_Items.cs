using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.TrackLights.TrackLights_1.Items;

internal class TrackLights_1_Items : ModItem
{
    public class TrackLights_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new TrackLights_1_Items(0)); //ImperialTrackLight
            mod.AddContent(new TrackLights_1_Items(1)); //StoneBrickTrackLight
            mod.AddContent(new TrackLights_1_Items(2)); //RedBrickTrackLight
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
            return "ImperialTrackLight";
        }
        if (style == 1)
        {
            return "StoneBrickTrackLight";
        }
        if (style == 2)
        {
            return "RedBrickTrackLight";
        }

        throw new Exception("Invalid style");
    }

    public TrackLights_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<TrackLights_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialTrackLight
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 6)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //StoneBrickTrackLight
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 6)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //RedBrickTrackLight
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 6)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}