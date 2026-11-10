using SquintlysFurnitureMod.Content.Items.Materials;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Normal.Two;

internal class S_1x1_N_2_Items : ModItem
{
    public class S_1x1_N_2_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 13; i++)
            {
                mod.AddContent(new S_1x1_N_2_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_N_2_Style
    {
        Top = 0,
        Carrot = 1,
        MortarOld = 2,
        ChampagneFlute = 3,
        BrightRoseOld = 4,
        DarkRoseOld = 5,
        RedChocolatesOld = 6,
        BlackChocolatesOld = 7,
        Persimmon = 8,
        Guava = 9,
        Bucket = 10,
        CandyCane = 11,
        SaltandPepper = 12
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_N_2_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_N_2_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_N_2>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;
        if (placeStyle == 0 | placeStyle == 3) //tops, champagne flutes
        {
            Item.value = Item.buyPrice(copper: 5);
        }
        if (placeStyle == 1) //carrots
        {
            Item.value = Item.buyPrice(silver: 5);
        }
        if (placeStyle == 8 | placeStyle == 9) //Persimmon, guava
        {
            Item.value = Item.buyPrice(silver: 20);
        }
        if (placeStyle == 10 | placeStyle == 11) //Bucket, candycanes
        {
            Item.value = Item.buyPrice(copper: 40);
        }
        if (placeStyle == 12) //salt and pepper
        {
            Item.value = Item.buyPrice(silver: 20, copper: 50);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0)
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 10)
                .AddTile(ModContent.TileType<ShopToys>())
                .Register();

            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 8)
                .AddRecipeGroup("SquintlyFurnitureMod:Paint")
                .AddTile(ModContent.TileType<Worktable>())
                .Register();
        }
        if (placeStyle == 1) //carrots
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 5)
                .AddTile(ModContent.TileType<ShopVeggies>())
                .Register();

            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:Veggies")
                .AddTile(ModContent.TileType<CuttingBoard>())
                .Register();
        }
        if (placeStyle == 3) //champagne flutes
        {
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 2)
                .AddTile(ModContent.TileType<Smelter>())
                .Register();
        }
        if (placeStyle == 8 | placeStyle == 9) //Persimmon, guava
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
        if (placeStyle == 10) //bucket
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 40)
                .AddTile(ModContent.TileType<ShopMisc>())
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Plastic>(), 10)
                .AddTile(ModContent.TileType<Smelter>())
                .Register();
        }
        if (placeStyle == 11) //Candycane
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 40)
                .AddTile(ModContent.TileType<ShopCrimbo>())
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Plastic>(), 10)
                .AddRecipeGroup("SquintlyFurnitureMod:Festive")
                .AddTile(ModContent.TileType<Smelter>())
                .Register();
        }
        if (placeStyle == 12) // salt and pepper
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 50)
                .AddIngredient(ItemID.SilverCoin, 20)
                .AddTile(ModContent.TileType<ShopGoods>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.ClayBlock, 4)
                .AddIngredient(Mod.Find<ModItem>("Salt").Type)
                .AddRecipeGroup("SquintlyFurnitureMod:Peppers")
                .AddTile(ModContent.TileType<PotteryWheel>())
                .Register();
        }
    }
}
