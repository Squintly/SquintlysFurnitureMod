using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoOne.Normal.Four;

internal class S_2x1_N_4_Items : ModItem
{
    public S_2x1_N_4_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public class S_2x1_N_4_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 7; i++)
            {
                mod.AddContent(new S_2x1_N_4_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_2x1_N_4_Style
    {
        Bread = 0,
        SmallBaguette = 1,
        Loaf = 2,
        CheeseWheel = 3,
        RolledTowel = 4,
        Bolster = 5,
        Spices = 6
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_2x1_N_4_Style), style);

        throw new Exception("Invalid style");
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_2x1_N_4>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;
        if (placeStyle == 0 | placeStyle == 1 | placeStyle == 2 | placeStyle == 6) //breads, spices
        {
            Item.value = Item.buyPrice(silver: 2);
        }
        if (placeStyle == 3) //cheese wheel
        {
            Item.value = Item.buyPrice(silver: 20);
        }
        if (placeStyle == 4 | placeStyle == 5) //towel, bolster
        {
            Item.value = Item.buyPrice(silver: 8);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0 | placeStyle == 1 | placeStyle == 2) //breads
        {
            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:Flours", 2)
                .AddIngredient(Mod.Find<ModItem>("Yeast").Type)
                .AddRecipeGroup("SquintlyFurnitureMod:Eggs")
                .AddTile(ModContent.TileType<Stoves>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 2)
                .AddTile(ModContent.TileType<ShopBread>())
                .Register();
        }
        if (placeStyle == 3) //cheese wheel
        {
            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:Cheeses", 4)
                .AddTile(ModContent.TileType<CuttingBoard>())
                .Register();

            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:Milks")
                .AddTile(ModContent.TileType<Stoves>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 20)
                .AddTile(ModContent.TileType<ShopGoods>())
                .Register();
        }
        if (placeStyle == 4) //rolled towels
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 4)
                .AddTile(ModContent.TileType<SewingBox>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 8)
                .AddTile(ModContent.TileType<ShopHeartfelt>())
                .Register();
        }
        if (placeStyle == 5) //bolster
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 4)
                .AddIngredient(ItemID.Hay, 4)
                .AddTile(ModContent.TileType<SewingBox>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 8)
                .AddTile(ModContent.TileType<ShopHeartfelt>())
                .Register();
        }
        if (placeStyle == 6) //spices
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 2)
                .AddTile(ModContent.TileType<ShopGoods>())
                .Register();
        }
    }
}