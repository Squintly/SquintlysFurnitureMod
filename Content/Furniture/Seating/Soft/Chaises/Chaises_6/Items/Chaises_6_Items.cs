using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Seating.Soft.Chaises.Chaises_6.Items;

internal class Chaises_6_Items : ModItem
{
    public class Chaises_6_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Chaises_6_Items(0)); //TatteredChaise
            mod.AddContent(new Chaises_6_Items(1)); //RepairedChaise
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
            return "TatteredChaise";
        }

        if (style == 1)
        {
            return "RepairedChaise";
        }

        throw new Exception("Invalid style");
    }

    public Chaises_6_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Chaises_6>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //TatteredChaise
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 6)
            .AddIngredient(ItemID.Silk, 3)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }

        if (placeStyle == 1) //RepairedChaise
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(ItemID.Silk, 1)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(0)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}