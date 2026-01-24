using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Surface.Torchieres.Torchieres_4.Items;

internal class Torchieres_4_Items : ModItem
{
    public class Torchieres_4_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Torchieres_4_Items(0)); //TatteredTorchiere
            mod.AddContent(new Torchieres_4_Items(1)); //RepairedTorchiere
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
            return "TatteredTorchiere";
        }
        if (style == 1)
        {
            return "RepairedTorchiere";
        }

        throw new Exception("Invalid style");
    }

    public Torchieres_4_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Torchieres_4>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 2);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //TatteredTorchiere
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 1) //RepairedTorchiere
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 1)
            .AddIngredient(ItemID.Torch)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(0)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}