using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Four;

internal class S_1x1_B_4_Items : ModItem
{
    public class S_1x1_B_4_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 14; i++)
            {
                mod.AddContent(new S_1x1_B_4_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_B_4_Style
    {
        Orange = 0,
        Coconut = 1,
        Lemon = 2,
        Lime = 3,
        Banana = 4,
        CakeSlice = 5,
        SugarSmall = 6,
        FlourSmall = 7,
        WoodenBucket = 8,
        GrenadeGreen = 9,
        GrenadeBrown = 10,
        GrenadeBlack = 11,
        GrenadeRed = 12,
        GrenadeFuture = 13
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_B_4_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_B_4_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_4>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0 | placeStyle == 1 | placeStyle == 2 | placeStyle == 3 | placeStyle == 4) //orange, coconut, lemon, lime, banana
        {
            Item.value = Item.buyPrice(silver: 20);
        }
        if (placeStyle == 5) //Cake slice
        {
            Item.value = Item.buyPrice(copper: 75);
        }
        if (placeStyle == 6 | placeStyle == 7) //sugar, flour
        {
            Item.value = Item.buyPrice(copper: 50);
        }
        if (placeStyle == 8) //wooden bucket
        {
            Item.value = Item.buyPrice(copper: 5);
        }
        if (placeStyle == 9 | placeStyle == 10 | placeStyle == 11 | placeStyle == 12 | placeStyle == 13) //Grenades 
        {
            Item.value = Item.buyPrice(copper: 60);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0 | placeStyle == 1 | placeStyle == 2 | placeStyle == 3 | placeStyle == 4) //orange, coconut, lemon, lime, banana
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 20)
                .AddTile(ModContent.TileType<ShopFruit>())
                .Register();

            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:AllFruit")
                .AddTile(ModContent.TileType<CuttingBoard>())
                .Register();
        }
        if (placeStyle == 5) //CakeSlice
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 75)
                .AddTile(ModContent.TileType<ShopBread>())
                .Register();

            CreateRecipe(4)
                .AddRecipeGroup("SquintlyFurnitureMod:Flours", 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Sugars", 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Eggs", 2)
                .AddTile(ModContent.TileType<Stoves>())
                .Register();

            CreateRecipe(4)
                .AddIngredient(Mod.Find<ModItem>("Cake").Type)
                .AddTile(ModContent.TileType<CuttingBoard>())
                .Register();
        }
        if (placeStyle == 6) //Sugar Small
        {
            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:Sugars")
                .AddTile(ModContent.TileType<Worktable>())
                .Register();
        }
        if (placeStyle == 6 | placeStyle == 7) //Sugar & flour
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 50)
                .AddTile(ModContent.TileType<ShopGoods>())
                .Register();
        }
        if (placeStyle == 7) //Flour Small
        {
            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:Flours")
                .AddTile(ModContent.TileType<Worktable>())
                .Register();
        }
        if (placeStyle == 8) //Wooden Bucket
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 5)
                .AddTile(ModContent.TileType<ChoppingBlock>())
                .Register();
        }
        if (placeStyle == 9 | placeStyle == 10 | placeStyle == 11 | placeStyle == 12 | placeStyle == 13) //Grenades 
        {
            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:Explosives")
                .AddTile(ModContent.TileType<Worktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 60)
                .AddTile(ModContent.TileType<ShopWeapons>())
                .Register();
        }
    }
}