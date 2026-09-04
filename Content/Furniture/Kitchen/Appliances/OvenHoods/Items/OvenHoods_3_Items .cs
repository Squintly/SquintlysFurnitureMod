using SquintlysFurnitureMod.Content.Furniture.Kitchen.Appliances.Dishwashers;
using SquintlysFurnitureMod.Content.Furniture.Kitchen.Appliances.KitchenSinks;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Kitchen.Appliances.OvenHoods.Items;

internal class OvenHoods_3_Items : ModItem
{
    public class OvenHoods_3_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 4; i++)
            {
                mod.AddContent(new OvenHoods_3_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum OvenHoods_3_Items_Style
    {
        OvenHoodModern = 0,
        OvenHoodVintage = 1,
        OvenHoodAntique = 2,
        OvenHoodRetro = 3
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(OvenHoods_3_Items_Style), style);

        throw new Exception("Invalid style");
    }

    public OvenHoods_3_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<OvenHoods_3>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 30);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddRecipeGroup(RecipeGroupID.Wood, 10)
        .AddRecipeGroup(RecipeGroupID.IronBar, 10)
        .AddTile(ModContent.TileType<Worktable>())
        .Register();
    }
}