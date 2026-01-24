using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Surface.Lamps.Lamps_1.Items;

internal class Lamps_1_Items : ModItem
{
    public class Lamps_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Lamps_1_Items(0)); //ImperialLamp
            mod.AddContent(new Lamps_1_Items(1)); //StoneBrickLamp
            mod.AddContent(new Lamps_1_Items(2)); //RedBrickLamp
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
            return "ImperialLamp";
        }
        if (style == 1)
        {
            return "StoneBrickLamp";
        }
        if (style == 2)
        {
            return "RedBrickLamp";
        }
        throw new Exception("Invalid style");
    }

    public Lamps_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Lamps_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialLamp
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 3)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //StoneBrickLamp
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 3)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //RedBrickLamp
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 3)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}