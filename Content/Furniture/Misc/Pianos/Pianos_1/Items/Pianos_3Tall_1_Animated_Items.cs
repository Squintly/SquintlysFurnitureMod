using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Pianos.Pianos_1.Items;

internal class Pianos_3Tall_1_Animated_Items : ModItem
{
    public class Pianos_3Tall_1_Animated_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Pianos_3Tall_1_Animated_Items(0)); //RepairedPlayerPiano
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
            return "RepairedPlayerPiano";
        }

        throw new Exception("Invalid style");
    }

    public Pianos_3Tall_1_Animated_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Pianos_3Tall_1_Animated>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //RepairedPiano
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddIngredient(ItemID.Book)
            .AddIngredient(ItemID.Bone, 2)
            .AddIngredient(Mod.Find<ModItem>(Pianos_3Tall_1_Items.GetInternalNameFromStyle(0)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}