using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Seven;

internal class S_1x1_B_7_Items : ModItem
{
    public class S_1x1_B_7_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 4; i++)
            {
                mod.AddContent(new S_1x1_B_7_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_B_7_Style
    {
        AppleGreen = 0,
        AppleRed = 1,
        Muffin = 2,
        KnifeBlock = 3,
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_B_7_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_B_7_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_7>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;
        if (placeStyle == 0 | placeStyle == 1) //Apples
        {
            Item.value = Item.buyPrice(silver: 20);
        }
        if (placeStyle == 2) //Muffins
        {
            Item.value = Item.buyPrice(silver: 1, copper: 50);
        }
        if (placeStyle == 3) //Knife Block
        {
            Item.value = Item.buyPrice(silver: 6);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0 | placeStyle == 1) //Apples
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
        if (placeStyle == 2) //Muffins
        {
            CreateRecipe(4)
                .AddRecipeGroup("SquintlyFurnitureMod:Flours")
                .AddRecipeGroup("SquintlyFurnitureMod:Sugars")
                .AddRecipeGroup("SquintlyFurnitureMod:Eggs")
                .AddTile(ModContent.TileType<Stoves>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 1)
                .AddIngredient(ItemID.CopperCoin, 50)
                .AddTile(ModContent.TileType<ShopBread>())
                .Register();
        }
        if (placeStyle == 3) //Knife Block
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 2)
                .AddRecipeGroup(RecipeGroupID.Wood, 4)
                .AddTile(ModContent.TileType<Worktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 6)
                .AddTile(ModContent.TileType<ShopAppliances>())
                .Register();
        }
    }
}