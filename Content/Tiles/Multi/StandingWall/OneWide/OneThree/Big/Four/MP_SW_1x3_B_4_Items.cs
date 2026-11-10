using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Multi.StandingWall.OneWide.OneThree.Big.Four;

internal class MP_SW_1x3_B_4_Items : ModItem
{
    public MP_SW_1x3_B_4_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public class MP_SW_1x3_B_4_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 1; i++)
            {
                mod.AddContent(new MP_SW_1x3_B_4_Items(i));
            }
        }

        public void Unload()
        {
        }
    }
    public enum MP_SW_1x3_B_4_Style
    {
        Tool = 0
    }
    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(MP_SW_1x3_B_4_Style), style);

        throw new Exception("Invalid style");
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<MP_SW_1x3_B_4>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;
        if (placeStyle == 0) //Tools
        {
            Item.value = Item.buyPrice(silver: 30);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //Tools
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddRecipeGroup(RecipeGroupID.IronBar, 10)
                .AddTile(ModContent.TileType<Worktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 30)
                .AddTile(ModContent.TileType<ShopVeggies>())
                .Register();
        }
    }
}