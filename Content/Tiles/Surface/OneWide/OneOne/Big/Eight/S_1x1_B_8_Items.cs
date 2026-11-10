using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Eight;

internal class S_1x1_B_8_Items : ModItem
{
    public class S_1x1_B_8_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 5; i++)
            {
                mod.AddContent(new S_1x1_B_8_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_B_8_Style
    {
        VaseFloral = 0,
        CrateSmall = 1,
        BasketSmallPot = 2,
        BasketSmall = 3,
        BasketSmallStraight = 4
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_B_8_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_B_8_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_8>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;
        if (placeStyle == 0) //Floral Vases
        {
            Item.value = Item.buyPrice(silver: 2);
        }
        if (placeStyle == 1) // small crate
        {
            Item.value = Item.buyPrice(silver: 6);
        }
        if (placeStyle == 2 | placeStyle == 3 | placeStyle == 4) // small baskets
        {
            Item.value = Item.buyPrice(copper: 6);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //Floral Vase
        {
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 2)
                .AddRecipeGroup("SquintlyFurnitureMod:FlowerSeeds", 2)
                .AddTile(ModContent.TileType<FloralWorktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 2)
                .AddTile(ModContent.TileType<ShopFlowers>())
                .Register();
        }
        if (placeStyle == 1) //Small crates
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddRecipeGroup(RecipeGroupID.IronBar, 2)
                .AddTile(ModContent.TileType<Worktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 6)
                .AddTile(ModContent.TileType<ShopMisc>())
                .Register();
        }
        if (placeStyle == 2 | placeStyle == 3 | placeStyle == 4) //Small baskets
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddTile(ModContent.TileType<Worktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 6)
                .AddTile(ModContent.TileType<ShopMisc>())
                .Register();
        }
    }
}