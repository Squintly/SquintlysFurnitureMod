using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Ten;

internal class S_1x1_B_10_Items : ModItem
{
    public class S_1x1_B_10_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 1; i++)
            {
                mod.AddContent(new S_1x1_B_10_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_B_10_Style
    {
        BowlBerry = 0
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_B_10_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_B_10_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_10>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //berry bowl
        {
            Item.value = Item.buyPrice(silver: 20);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //BerryBowl
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 20)
                .AddTile(ModContent.TileType<ShopFruit>())
                .Register();

            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:AllFruit")
                .AddIngredient(ItemID.Glass, 2)
                .AddTile(ModContent.TileType<CuttingBoard>())
                .Register();
        }
    }
}
