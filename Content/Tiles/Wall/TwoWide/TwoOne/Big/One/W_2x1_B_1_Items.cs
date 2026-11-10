using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Wall.TwoWide.TwoOne.Big.One;

internal class W_2x1_B_1_Items : ModItem
{
    public W_2x1_B_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public class W_2x1_B_1_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 1; i++)
            {
                mod.AddContent(new W_2x1_B_1_Items(i));
            }
        }

        public void Unload()
        {
        }
    }
    public enum W_2x1_B_1_Style
    {
        KnifeRack = 0
    }
    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(W_2x1_B_1_Style), style);

        throw new Exception("Invalid style");
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<W_2x1_B_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;
        if (placeStyle == 0) //KnifeRack
        {
            Item.value = Item.buyPrice(silver: 15);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //KnifeRack
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddRecipeGroup(RecipeGroupID.IronBar, 5)
                .AddTile(ModContent.TileType<Smelter>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 15)
                .AddTile(ModContent.TileType<ShopMeat>())
                .Register();
        }
    }
}