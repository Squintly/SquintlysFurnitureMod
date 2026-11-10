using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Four;

internal class S_1x1_B_4_Lighted_Items : ModItem
{
    public class S_1x1_B_4_Lighted_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 1; i++)
            {
                mod.AddContent(new S_1x1_B_4_Lighted_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_B_4_Lighted_Style
    {
        BirthdayCakeSlice = 0
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_B_4_Lighted_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_B_4_Lighted_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_4_Lighted>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;
        if (placeStyle == 0) //Birthday cakes/cupcake
        {
            Item.value = Item.buyPrice(copper: 75);
        }
    }

    public override void AddRecipes()
    {
        //Shops
        if (placeStyle == 0) //Birthday cakes/cupcakes
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 75)
                .AddTile(ModContent.TileType<ShopBread>())
                .Register();

            CreateRecipe(4)
                .AddRecipeGroup("SquintlyFurnitureMod:Flours", 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Sugars", 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Eggs", 2)
                .AddIngredient(ItemID.Torch)
                .AddTile(ModContent.TileType<Stoves>())
                .Register();

            CreateRecipe(4)
                .AddIngredient(Mod.Find<ModItem>("BirthdayCake").Type)
                .AddTile(ModContent.TileType<CuttingBoard>())
                .Register();
        }
    }
}