using SquintlysFurnitureMod.Content.Items.Blocks.Holiday;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Three;

internal class S_1x1_B_3_Items : ModItem
{
    public S_1x1_B_3_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public class S_1x1_B_3_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 12; i++)
            {
                mod.AddContent(new S_1x1_B_3_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_B_3_Style
    {
        Peach = 0,
        Apricot = 1,
        Butter = 2,
        Pineapple = 3,
        ChocolateEgg = 4,
        Egg = 5,
        CarrotBig = 6,
        Plum = 7,
        BloodOrange = 8,
        BreadPanSmall = 9,
        EggBrown = 10,
        Blender = 11
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_B_3_Style), style);

        throw new Exception("Invalid style");
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_3>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;
        if (placeStyle == 0 | placeStyle == 1 | placeStyle == 3 | placeStyle == 7 | placeStyle == 8) //Peach, apricot, pineapple, plum, blood orange
        {
            Item.value = Item.buyPrice(silver: 20);
        }
        if (placeStyle == 2 | placeStyle == 5 | placeStyle == 6 | placeStyle == 10) // eggs & carrot
        {
            Item.value = Item.buyPrice(silver: 5);
        }
        if (placeStyle == 4) // Choco eggs
        {
            Item.value = Item.buyPrice(copper: 50);
        }
        if (placeStyle == 9 | placeStyle == 11) // breadpan, blender
        {
            Item.value = Item.buyPrice(silver: 6);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0 | placeStyle == 1 | placeStyle == 3 | placeStyle == 7 | placeStyle == 8) //Peach, apricot, pineapple, plum, blood orange
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
        if (placeStyle == 2) //Butter
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 5)
                .AddTile(ModContent.TileType<ShopGoods>())
                .Register();

            CreateRecipe(4)
                .AddRecipeGroup("SquintlyFurnitureMod:Milks")
                .AddTile(ModContent.TileType<Fridges>())
                .Register();
        }
        if (placeStyle == 4) //Chocolate eggs
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 50)
                .AddTile(ModContent.TileType<ShopVernal>())
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ChocolateBlockItem>(), 1)
                .AddTile(ModContent.TileType<CuttingBoard>())
                .Register();
        }
        if (placeStyle == 5 | placeStyle == 10) //eggs, brown eggs
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 5)
                .AddTile(ModContent.TileType<ShopGoods>())
                .Register();
        }
        if (placeStyle == 6) //big carrots
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
        if (placeStyle == 9) //bread pan
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Flours")
                .AddTile(ModContent.TileType<Stoves>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 6)
                .AddTile(ModContent.TileType<ShopBread>())
                .Register();
        }
        if (placeStyle == 11) //blender
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 2)
                .AddIngredient(ItemID.Glass, 4)
                .AddTile(ModContent.TileType<Smelter>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 6)
                .AddTile(ModContent.TileType<ShopAppliances>())
                .Register();
        }
    }
}