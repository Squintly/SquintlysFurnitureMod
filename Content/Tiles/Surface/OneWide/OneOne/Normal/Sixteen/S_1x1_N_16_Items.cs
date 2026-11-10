using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Normal.Sixteen;

internal class S_1x1_N_16_Items : ModItem
{
    public class S_1x1_N_16_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 1; i++)
            {
                mod.AddContent(new S_1x1_N_16_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_N_16_Style
    {
        Battery = 0
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_N_16_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_N_16_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_N_16>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //battery
        {
            Item.value = Item.buyPrice(silver: 10);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //battery
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 10)
                .AddTile(ModContent.TileType<ShopAppliances>())
                .Register();
        }
    }
}