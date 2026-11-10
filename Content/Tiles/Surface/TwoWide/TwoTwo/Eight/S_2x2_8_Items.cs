using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoTwo.Eight;

internal class S_2x2_8_Items : ModItem
{
    public class S_2x2_8_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 2; i++)
            {
                mod.AddContent(new S_2x2_8_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_2x2_8_Style
    {
        DecoVineBasket = 0,
        BigCake = 1,
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_2x2_8_Style), style);

        throw new Exception("Invalid style");
    }

    public S_2x2_8_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_2x2_8>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //DecoVineBasket
        {
            Item.value = Item.buyPrice(silver: 6);
        }
        if (placeStyle == 0) //BigCake
        {
            Item.value = Item.buyPrice(silver: 3);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //DecoVineBasket
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddIngredient(ItemID.GrassSeeds, 2)
                .AddIngredient(ItemID.Silk, 2)
                .AddTile(ModContent.TileType<SewingBox>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 6)
                .AddTile(ModContent.TileType<ShopFlowers>())
                .Register();
        }
        if (placeStyle == 1) //BigCake
        {
            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:Flours", 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Sugars", 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Eggs", 2)
                .AddTile(ModContent.TileType<Stoves>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 3)
                .AddTile(ModContent.TileType<ShopBread>())
                .Register();

            CreateRecipe()
                .AddIngredient(Mod.Find<ModItem>("CakeSlice").Type, 4)
                .AddTile(ModContent.TileType<CuttingBoard>())
                .Register();
        }
    }
}