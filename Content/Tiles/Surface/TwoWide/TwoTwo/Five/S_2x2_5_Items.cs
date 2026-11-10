using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoTwo.Five;

internal class S_2x2_5_Items : ModItem
{
    public class S_2x2_5_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 2; i++)
            {
                mod.AddContent(new S_2x2_5_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_2x2_5_Style
    {
        SpringBasket = 0,
        BasketHandle = 1
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_2x2_5_Style), style);

        throw new Exception("Invalid style");
    }

    public S_2x2_5_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_2x2_5>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //SpringBasket
        {
            Item.value = Item.buyPrice(silver: 7);
        }
        if (placeStyle == 1) //Basket with Handle
        {
            Item.value = Item.buyPrice(silver: 4);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //SpringBasket
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddIngredient(ItemID.Silk, 4)
                .AddRecipeGroup("SquintlyFurnitureMod:FlowerSeeds")
                .AddTile(ModContent.TileType<FloralWorktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 7)
                .AddTile(ModContent.TileType<ShopVernal>())
                .Register();
        }
        if (placeStyle == 0) //Basket with Handle
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddIngredient(ItemID.Silk, 2)
                .AddTile(ModContent.TileType<Worktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 4)
                .AddTile(ModContent.TileType<ShopMisc>())
                .Register();
        }
    }
}