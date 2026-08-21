using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.Spotlights.Spotlights_2.Items;

internal class Spotlights_2_Items : ModItem
{
    public class Spotlights_2_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Spotlights_2_Items(0)); //TeakSpotlight
            mod.AddContent(new Spotlights_2_Items(1)); //StoneBrickSpotlight
            mod.AddContent(new Spotlights_2_Items(2)); //RedBrickSpotlight
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
            return "TeakSpotlight";
        }
        if (style == 1)
        {
            return "StoneBrickSpotlight";
        }
        if (style == 2)
        {
            return "RedBrickSpotlight";
        }

        throw new Exception("Invalid style");
    }

    public Spotlights_2_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Spotlights_2>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //TeakSpotlight
        {
            CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<TeakWood>(), 5)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //StoneBrickSpotlight
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 5)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //RedBrickSpotlight
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 5)
            .AddIngredient(ItemID.Torch, 3)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}