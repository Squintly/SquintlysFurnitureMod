using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Bathroom.Baths.Baths_1.Items;

internal class Baths_Animated_1_Items : ModItem
{
    public class Baths_Animated_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Baths_Animated_1_Items(0)); //CinderblockBathtubLeaky
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
            return "CinderblockBathtubLeaky";
        }
        throw new Exception("Invalid style");
    }

    public Baths_Animated_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Baths_Animated_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //CinderblockBathtubLeaky
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 14)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}