using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.CeilingLamps.CeilingLamps_1.Items;

internal class CeilingLamps_1_Items : ModItem
{
    public class CeilingLamps_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new CeilingLamps_1_Items(0)); //ImperialCeilingLamp
            mod.AddContent(new CeilingLamps_1_Items(1)); //CinderblockCeilingLamp
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
            return "ImperialCeilingLamp";
        }
        if (style == 1)
        {
            return "CinderblockCeilingLamp";
        }

        throw new Exception("Invalid style");
    }

    public CeilingLamps_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<CeilingLamps_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 30);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialCeilingLamp
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //CinderblockCeilingLamp
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}