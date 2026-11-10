using SquintlysFurnitureMod.Content.Items.Materials;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Normal.One;

internal class S_1x1_N_1_Items : ModItem
{
    public class S_1x1_N_1_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 10; i++)
            {
                mod.AddContent(new S_1x1_N_1_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_N_1_Style
    {
        SaltandPepperOld = 0,
        SantaHat = 1,
        GingerbreadHouse = 2,
        Snowglobe = 3,
        ToyBlocks = 4,
        SmallTeddy = 5,
        HeartBear = 6,
        Sponge = 7,
        Detergent = 8,
        WaterBottleSmall = 9
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_N_1_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_N_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_N_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 1) //santa hat
        {
            Item.value = Item.buyPrice(silver: 2);
        }
        if (placeStyle == 2) //gingerbread house
        {
            Item.value = Item.buyPrice(silver: 1);
        }
        if (placeStyle == 3 | placeStyle == 7 | placeStyle == 8 | placeStyle == 9) //snowglobe
        {
            Item.value = Item.buyPrice(copper: 8);
        }
        if (placeStyle == 4) //blocks
        {
            Item.value = Item.buyPrice(copper: 5);
        }
        if (placeStyle == 5 | placeStyle == 6) //gingerbread house
        {
            Item.value = Item.buyPrice(silver: 10);
        }
        if (placeStyle == 8) //detergent
        {
            Item.value = Item.buyPrice(copper: 10);
        }
    }

    public override void AddRecipes()
    {
        if (placeStyle == 1) //Santa Hat
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 2)
                .AddTile(ModContent.TileType<ShopCrimbo>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.Silk, 1)
                .AddTile(ModContent.TileType<FestiveWorktable>())
                .Register();
        }
        if (placeStyle == 2) //Gingerbread House
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 1)
                .AddTile(ModContent.TileType<ShopCrimbo>())
                .Register();

            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood)
                .AddRecipeGroup("SquintlyFurnitureMod:Festive")
                .AddRecipeGroup("SquintlyFurnitureMod:Sugars")
                .AddRecipeGroup("SquintlyFurnitureMod:Flours")
                .AddTile(ModContent.TileType<FestiveWorktable>())
                .Register();
        }
        if (placeStyle == 3) //Snowglobe
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 8)
                .AddTile(ModContent.TileType<ShopCrimbo>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SnowBlock, 1)
                .AddIngredient(ItemID.Glass, 2)
                .AddIngredient(ModContent.ItemType<Plastic>(), 2)
                .AddTile(ModContent.TileType<FestiveWorktable>())
                .Register();
        }
        if (placeStyle == 4) //ToyBlocks
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
        if (placeStyle == 5 | placeStyle == 6) //Bears
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 10)
                .AddTile(ModContent.TileType<ShopToys>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.Silk, 4)
                .AddIngredient(ItemID.Hay, 2)
                .AddIngredient(ModContent.ItemType<ThreadItem>(), 4)
                .AddTile(ModContent.TileType<SewingBox>())
                .Register();
        }
        if (placeStyle == 7) //Sponge
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 8)
                .AddTile(ModContent.TileType<ShopMisc>())
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Plastic>(), 2)
                .AddTile(ModContent.TileType<Smelter>())
                .Register();
        }
        if (placeStyle == 8) //Detergent
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 8)
                .AddTile(ModContent.TileType<ShopMisc>())
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Plastic>(), 2)
                .AddIngredient(ItemID.Gel, 2)
                .AddTile(ModContent.TileType<Smelter>())
                .Register();
        }
        if (placeStyle == 9) //Waterbottle
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 8)
                .AddTile(ModContent.TileType<ShopMisc>())
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Plastic>(), 2)
                .AddTile(ModContent.TileType<Smelter>())
                .Register();
        }
    }
}