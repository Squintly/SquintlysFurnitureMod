using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoOne.Normal.Six;

internal class S_2x1_N_6_Items : ModItem
{
    public S_2x1_N_6_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public class S_2x1_N_6_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 2; i++)
            {
                mod.AddContent(new S_2x1_N_6_Items(i));
            }
        }

        public void Unload()
        {
        }
    }
    public enum S_2x1_N_6_Style
    {
        Pie = 0,
        BakingTray = 1
    }
    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_2x1_N_6_Style), style);

        throw new Exception("Invalid style");
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_2x1_N_6>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;
        if (placeStyle == 0) //pies
        {
            Item.value = Item.buyPrice(silver: 23);
        }
        if (placeStyle == 1) //baking tray
        {
            Item.value = Item.buyPrice(silver: 3);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //pies
        {
            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:Flours", 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Sugars", 4)
                .AddRecipeGroup("SquintlyFurnitureMod:AllFruit")
                .AddIngredient(ItemID.ClayBlock)
                .AddTile(ModContent.TileType<Stoves>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 23)
                .AddTile(ModContent.TileType<ShopBread>())
                .Register();
        }
        if (placeStyle == 1) //baking tray
        {
            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:Flours", 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Sugars", 4)
                .AddRecipeGroup(RecipeGroupID.IronBar)
                .AddTile(ModContent.TileType<Stoves>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 3)
                .AddTile(ModContent.TileType<ShopBread>())
                .Register();
        }
    }
}