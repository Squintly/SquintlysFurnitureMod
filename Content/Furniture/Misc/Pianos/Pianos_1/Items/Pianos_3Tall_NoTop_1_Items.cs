using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Pianos.Pianos_1.Items;

internal class Pianos_3Tall_NoTop_1_Items : ModItem
{
    public class Pianos_3Tall_NoTop_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Pianos_3Tall_NoTop_1_Items(0)); //ImperialHarpsichord
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
            return "ImperialHarpsichord";
        }

        throw new Exception("Invalid style");
    }

    public Pianos_3Tall_NoTop_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Pianos_3Tall_NoTop_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialHarpsichord
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 15)
            .AddIngredient(ItemID.Book)
            .AddIngredient(ItemID.Bone, 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}