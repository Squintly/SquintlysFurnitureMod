using SquintlysFurnitureMod.Content.Items.Materials;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Normal.Three;

internal class S_1x1_N_3_Items : ModItem
{
    public class S_1x1_N_3_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 3; i++)
            {
                mod.AddContent(new S_1x1_N_3_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_N_3_Style
    {
        Kiwi = 0,
        Spraybottle = 1,
        RiceCooker = 2
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_N_3_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_N_3_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_N_3>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //Kiwi
        {
            Item.value = Item.buyPrice(silver: 20);
        }
        if (placeStyle == 1) //spraybottle
        {
            Item.value = Item.buyPrice(copper: 10);
        }
        if (placeStyle == 2) //rice cooker
        {
            Item.value = Item.buyPrice(silver: 9);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //Kiwi
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
        if (placeStyle == 1) //Spray Bottle
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
        if (placeStyle == 2) //rice cooker
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