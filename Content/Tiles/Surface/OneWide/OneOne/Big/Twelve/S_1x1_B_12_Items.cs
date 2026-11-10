using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Twelve;

internal class S_1x1_B_12_Items : ModItem
{
    public class S_1x1_B_12_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 1; i++)
            {
                mod.AddContent(new S_1x1_B_12_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_B_12_Style
    {
        Cupcake = 0
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_B_12_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_B_12_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_12>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //Cupcakes
        {
            Item.value = Item.buyPrice(copper: 75);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //Cupcakes
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 75)
                .AddTile(ModContent.TileType<ShopBread>())
                .Register();

            CreateRecipe(4)
                .AddRecipeGroup("SquintlyFurnitureMod:Flours", 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Sugars", 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Eggs", 2)
                .AddTile(ModContent.TileType<Stoves>())
                .Register();
        }
    }
}
