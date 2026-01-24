using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bathroom.Baths.Baths_3.Items;

internal class Baths_3_Items : ModItem
{
    public class Baths_3_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Baths_3_Items(0)); //StoneBrickBathtub
            mod.AddContent(new Baths_3_Items(1)); //RedBrickBathdtub
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
            return "StoneBrickBathtub";
        }
        if (style == 1)
        {
            return "RedBrickBathtub";
        }
        throw new Exception("Invalid style");
    }

    public Baths_3_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Baths_3>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickBathtub
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 14)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 1) //RedBrickBathtub
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 14)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}