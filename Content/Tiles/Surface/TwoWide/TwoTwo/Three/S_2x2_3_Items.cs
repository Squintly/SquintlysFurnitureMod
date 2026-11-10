using SquintlysFurnitureMod.Content.Items.Materials;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoTwo.Three;

internal class S_2x2_3_Items : ModItem
{
    public class S_2x2_3_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 5; i++)
            {
                mod.AddContent(new S_2x2_3_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_2x2_3_Style
    {
        FestiveDecor = 0,
        Poinsetta = 1,
        Basket = 2,
        Cauldron = 3,
        DecoThornBasket = 4,
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_2x2_3_Style), style);

        throw new Exception("Invalid style");
    }

    public S_2x2_3_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_2x2_3>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //FestiveDecor
        {
            Item.value = Item.buyPrice(copper: 32);
        }
        if (placeStyle == 1 | placeStyle == 2) //Poinsettas, Baskets
        {
            Item.value = Item.buyPrice(silver: 2);
        }
        if (placeStyle == 3) //Cauldrons
        {
            Item.value = Item.buyPrice(silver: 18);
        }
        if (placeStyle == 4) //Poinsettas, Baskets
        {
            Item.value = Item.buyPrice(silver: 6);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //FestiveDecor
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Plastic>(), 8)
                .AddTile(ModContent.TileType<FestiveWorktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 32)
                .AddTile(ModContent.TileType<ShopCrimbo>())
                .Register();
        }
        if (placeStyle == 1) //Poinsettas
        {
            CreateRecipe()
                .AddIngredient(ItemID.DirtBlock, 1)
                .AddIngredient(ItemID.FlowerPacketRed, 2)
                .AddRecipeGroup(RecipeGroupID.Wood, 6)
                .AddTile(ModContent.TileType<FestiveWorktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 2)
                .AddTile(ModContent.TileType<ShopCrimbo>())
                .Register();
        }
        if (placeStyle == 2) //Baskets
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddIngredient(ItemID.Silk, 2)
                .AddTile(ModContent.TileType<Worktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 2)
                .AddTile(ModContent.TileType<ShopMisc>())
                .Register();
        }
        if (placeStyle == 3) //cauldrons
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 6)
                .AddTile(ModContent.TileType<Smelter>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 18)
                .AddTile(ModContent.TileType<ShopSpooky>())
                .Register();
        }
        if (placeStyle == 4) //DecoThornBasket
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddIngredient(ItemID.GrassSeeds, 2)
                .AddIngredient(ItemID.Silk, 2)
                .AddTile(ModContent.TileType<SewingBox>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 6)
                .AddTile(ModContent.TileType<ShopFlowers>())
                .Register();
        }
    }
}