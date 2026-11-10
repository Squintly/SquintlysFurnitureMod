using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Six;

internal class S_1x1_B_6_Items : ModItem
{
    public class S_1x1_B_6_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 6; i++)
            {
                mod.AddContent(new S_1x1_B_6_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_B_6_Style
    {
        MilkJug = 0,
        Grapes = 1,
        SpringChick = 2,
        BellPepper = 3,
        PaintCups = 4,
        Pots = 5
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_B_6_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_B_6_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_6>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //Milk
        {
            Item.value = Item.buyPrice(copper: 50);
        }
        if (placeStyle == 1 | placeStyle == 3) //Grapes, Bell Pepper
        {
            Item.value = Item.buyPrice(silver: 20);
        }
        if (placeStyle == 2) //Spring Chick
        {
            Item.value = Item.buyPrice(silver: 10);
        }
        if (placeStyle == 4) //PaintCups
        {
            Item.value = Item.buyPrice(copper: 5);
        }
        if (placeStyle == 5) //Pots
        {
            Item.value = Item.buyPrice(silver: 12);
        }
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //Milk
        {
            CreateRecipe(4)
                .AddIngredient(ItemID.MilkCarton)
                .AddTile(ModContent.TileType<Fridges>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 50)
                .AddTile(ModContent.TileType<ShopGoods>())
                .Register();
        }
        if (placeStyle == 1 | placeStyle == 3) //Grapes, Bell Pepper
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
        if (placeStyle == 2) //spring chick plush
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 4)
                .AddIngredient(ModContent.ItemType<ThreadItem>(), 4)
                .AddIngredient(ItemID.Hay, 2)
                .AddTile(ModContent.TileType<SewingBox>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 10)
                .AddTile(ModContent.TileType<ShopToys>())
                .Register();
        }
        if (placeStyle == 4) //paint cups
        {
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Paint")
                .AddTile(ModContent.TileType<PaintJars>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 5)
                .AddTile(ModContent.TileType<ShopPaint>())
                .Register();
        }
        if (placeStyle == 5) //pots
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 4)
                .AddTile(ModContent.TileType<Smelter>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 12)
                .AddTile(ModContent.TileType<ShopAppliances>())
                .Register();
        }
    }
}