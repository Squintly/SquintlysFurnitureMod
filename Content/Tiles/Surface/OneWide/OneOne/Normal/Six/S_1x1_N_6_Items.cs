using SquintlysFurnitureMod.Content.Items.Blocks.Holiday;
using SquintlysFurnitureMod.Content.Items.Materials;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Normal.Six;

internal class S_1x1_N_6_Items : ModItem
{
    public class S_1x1_N_6_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 4; i++)
            {
                mod.AddContent(new S_1x1_N_6_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_N_6_Style
    {
        ToyBall = 0,
        HeartfeltCard = 1,
        SnackBowl = 2,
        Toaster = 3
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_N_6_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_N_6_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_N_6>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //toy balls
        {
            Item.value = Item.buyPrice(copper: 5);
        }
        if (placeStyle == 1) //valentines card
        {
            Item.value = Item.buyPrice(copper: 7);
        }
        if (placeStyle == 2) //snack bowl
        {
            Item.value = Item.buyPrice(copper: 50);
        }
        if (placeStyle == 3) // toaster
        {
            Item.value = Item.buyPrice(silver: 9);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //toy balls
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 5)
                .AddTile(ModContent.TileType<ShopToys>())
                .Register();

            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 8)
                .AddRecipeGroup("SquintlyFurnitureMod:Paint")
                .AddTile(ModContent.TileType<PaintJars>())
                .Register();
        }
        if (placeStyle == 1) //Valentines Cards
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 7)
                .AddTile(ModContent.TileType<ShopHeartfelt>())
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Paper>(), 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Paint")
                .AddTile(ModContent.TileType<PrintingPressTile>())
                .Register();
        }
        if (placeStyle == 2) //snack bowl
        {
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 4)
                .AddIngredient(ModContent.ItemType<ChocolateBlockItem>())
                .AddTile(ModContent.TileType<Smelter>())
                .Register();

            CreateRecipe()
                 .AddIngredient(ItemID.CopperCoin, 50)
                 .AddTile(ModContent.TileType<ShopGoods>())
                 .Register();
        }
        if (placeStyle == 3) //toasters
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 9)
                .AddTile(ModContent.TileType<ShopAppliances>())
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Plastic>(), 2)
                .AddRecipeGroup(RecipeGroupID.IronBar, 2)
                .AddRecipeGroup("SquintlyFurnitureMod:CopperBar", 2)
                .AddTile(ModContent.TileType<Worktable>())
                .Register();
        }
    }
}
