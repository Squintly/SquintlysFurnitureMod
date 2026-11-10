using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoTwo.Seven;

internal class S_2x2_7_Items : ModItem
{
    public class S_2x2_7_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 1; i++)
            {
                mod.AddContent(new S_2x2_7_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_2x2_7_Style
    {
        DecoReedBasket = 0
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_2x2_7_Style), style);

        throw new Exception("Invalid style");
    }

    public S_2x2_7_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_2x2_7>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //DecoReedBasket
        {
            Item.value = Item.buyPrice(silver: 6);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //DecoReedBasket
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