using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoTwo.Six;

internal class S_2x2_6_Items : ModItem
{
    public S_2x2_6_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public class S_2x2_6_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 1; i++)
            {
                mod.AddContent(new S_2x2_6_Items(i));
            }
        }

        public void Unload()
        {
        }
    }
    public enum S_2x2_6_Style
    {
        BasketWide = 0
    }
    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_2x2_6_Style), style);

        throw new Exception("Invalid style");
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_2x2_6>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;
        if (placeStyle == 0) //BasketWide
        {
            Item.value = Item.buyPrice(copper: 10);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //BasketWide
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddTile(ModContent.TileType<Worktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 10)
                .AddTile(ModContent.TileType<ShopMisc>())
                .Register();
        }
    }
}