using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Wall.ThreeWide.ThreeOne.Normal.One;

internal class W_3x1_N_1_Items : ModItem
{
    public W_3x1_N_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public class W_3x1_N_1_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 1; i++)
            {
                mod.AddContent(new W_3x1_N_1_Items(i));
            }
        }

        public void Unload()
        {
        }
    }
    public enum W_3x1_N_1_Style
    {
        ToolBoard = 0
    }
    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(W_3x1_N_1_Style), style);

        throw new Exception("Invalid style");
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<W_3x1_N_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;
        if (placeStyle == 0) //ToolBoard
        {
            Item.value = Item.buyPrice(silver: 30);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //ToolBoard
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 10)
                .AddTile(ModContent.TileType<Smelter>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 30)
                .AddTile(ModContent.TileType<ShopMisc>())
                .Register();
        }
    }
}