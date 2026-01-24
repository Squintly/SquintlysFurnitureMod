using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Surface.Lamps.Lamps_11.Items;

internal class Lamps_11_Items : ModItem
{
    public class Lamps_11_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Lamps_11_Items(0)); //TatteredLamp
            mod.AddContent(new Lamps_11_Items(1)); //RepairedLamp
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
            return "TatteredLamp";
        }
        if (style == 1)
        {
            return "RepairedLamp";
        }

        throw new Exception("Invalid style");
    }

    public Lamps_11_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Lamps_11>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //TatteredLamp
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 1) //RepairedLamp
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 1)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(0)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}