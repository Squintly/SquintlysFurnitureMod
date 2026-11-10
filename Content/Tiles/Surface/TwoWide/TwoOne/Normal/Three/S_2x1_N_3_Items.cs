using SquintlysFurnitureMod.Content.Items.Materials;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoOne.Normal.Three;

internal class S_2x1_N_3_Items : ModItem
{
    public S_2x1_N_3_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public class S_2x1_N_3_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 3; i++)
            {
                mod.AddContent(new S_2x1_N_3_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_2x1_N_3_Style
    {
        EggCarton = 0,
        CasseroleDish = 1,
        BreadPan = 2
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_2x1_N_3_Style), style);

        throw new Exception("Invalid style");
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_2x1_N_3>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;
        if (placeStyle == 0) //Egg carton
        {
            Item.value = Item.buyPrice(silver: 6);
        }
        if (placeStyle == 1) //Casserole dish
        {
            Item.value = Item.buyPrice(copper: 50);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //egg carton
        {
            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:Eggs", 12)
                .AddIngredient(ModContent.ItemType<Paper>(), 8)
                .AddTile(ModContent.TileType<Worktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 6)
                .AddTile(ModContent.TileType<ShopGoods>())
                .Register();
        }
        if (placeStyle == 1) //Casserole dish
        {
            CreateRecipe()
                .AddIngredient(ItemID.ClayBlock, 6)
                .AddRecipeGroup("SquintlyFurnitureMod:Flours")
                .AddRecipeGroup("SquintlyFurnitureMod:Cheeses")
                .AddTile(ModContent.TileType<Stoves>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 50)
                .AddTile(ModContent.TileType<ShopBread>())
                .Register();
        }
        if (placeStyle == 2) //breadpan
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 6)
                .AddRecipeGroup("SquintlyFurnitureMod:Flours")
                .AddIngredient(Mod.Find<ModItem>("Yeast").Type)
                .AddTile(ModContent.TileType<Stoves>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 50)
                .AddTile(ModContent.TileType<ShopBread>())
                .Register();
        }
    }
}