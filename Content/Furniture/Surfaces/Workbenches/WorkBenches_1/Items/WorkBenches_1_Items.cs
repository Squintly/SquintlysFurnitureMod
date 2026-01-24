using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Surfaces.Workbenches.WorkBenches_1.Items;

internal class WorkBenches_1_Items : ModItem
{
    public class WorkBenches_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new WorkBenches_1_Items(0)); //CinderblockWorkBench
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
            return "CinderblockWorkBench";
        }

        throw new Exception("Invalid style");
    }

    public WorkBenches_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<WorkBenches_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 30);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //CinderblockWorkBench
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 4)
            .Register();
        }
    }
}