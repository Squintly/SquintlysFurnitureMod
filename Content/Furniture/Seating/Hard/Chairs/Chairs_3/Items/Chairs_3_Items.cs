using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Seating.Hard.Chairs.Chairs_3.Items;

internal class Chairs_3_Items : ModItem
{
    public class Chairs_3_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Chairs_3_Items(0)); //ImperialGoldenChair
            mod.AddContent(new Chairs_3_Items(1)); //ImperialWoodenChair
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
            return "ImperialGoldenChair";
        }
        if (style == 1)
        {
            return "ImperialWoodenChair";
        }

        throw new Exception("Invalid style");
    }

    public Chairs_3_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Chairs_3>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialGoldenChair
        {
            CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //ImperialWoodenChair
        {
            CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}