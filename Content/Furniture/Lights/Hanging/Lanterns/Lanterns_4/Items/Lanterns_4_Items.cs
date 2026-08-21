using SquintlysFurnitureMod.Content.Items.Blocks.Holiday.Spring;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.Lanterns.Lanterns_4.Items;

internal class Lanterns_4_Items : ModItem
{
    public class Lanterns_4_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Lanterns_4_Items(0)); //SpringtimeLantern
            mod.AddContent(new Lanterns_4_Items(1)); //StoneBrickLantern
            mod.AddContent(new Lanterns_4_Items(2)); //RedBrickLantern
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
            return "SpringtimeLantern";
        }
        if (style == 1)
        {
            return "StoneBrickLantern";
        }
        if (style == 2)
        {
            return "RedBrickLantern";
        }

        throw new Exception("Invalid style");
    }

    public Lanterns_4_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Lanterns_4>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 30);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickLantern
        {
            CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<SpringyWood>(), 6)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<FloralWorktable>())
            .Register();
        }
        if (placeStyle == 1) //StoneBrickLantern
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 6)
            .AddIngredient(ItemID.Torch)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //RedBrickLantern
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 6)
            .AddIngredient(ItemID.Torch)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}