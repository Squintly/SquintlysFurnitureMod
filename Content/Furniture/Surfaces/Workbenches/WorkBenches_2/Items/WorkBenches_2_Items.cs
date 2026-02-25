using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Surfaces.Workbenches.WorkBenches_2.Items;

internal class WorkBenches_2_Items : ModItem
{
    public class WorkBenches_2_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new WorkBenches_2_Items(0)); //StoneBrickWorkBench
            mod.AddContent(new WorkBenches_2_Items(1)); //RedBrickWorkBench
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
            return "StoneBrickWorkBench";
        }
        if (style == 1)
        {
            return "RedBrickWorkBench";
        }

        throw new Exception("Invalid style");
    }

    public WorkBenches_2_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<WorkBenches_2>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 30);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickWorkBench
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 4)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 1) //RedBrickWorkBench
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 4)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}