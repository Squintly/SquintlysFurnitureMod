using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.Lanterns.Lanterns_5.Items;

internal class Lanterns_5_Items : ModItem
{
    public class Lanterns_5_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Lanterns_5_Items(0)); //ImperialLantern
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
            return "ImperialLantern";
        }

        throw new Exception("Invalid style");
    }

    public Lanterns_5_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Lanterns_5>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialLantern
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 6)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}