using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bathroom.Baths.Baths_1.Items;

internal class Baths_Tall_1_Items : ModItem
{
    public class Baths_Tall_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Baths_Tall_1_Items(0)); //ImperialBathtubFancy
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
            return "ImperialBathtubFancy";
        }
        throw new Exception("Invalid style");
    }

    public Baths_Tall_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Baths_Tall_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialBathtubFancy
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 14)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}