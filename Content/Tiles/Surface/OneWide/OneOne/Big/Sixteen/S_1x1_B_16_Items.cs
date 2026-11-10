using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Sixteen;

internal class S_1x1_B_16_Items : ModItem
{
    public class S_1x1_B_16_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 1; i++)
            {
                mod.AddContent(new S_1x1_B_16_Items(i));
            }
        }
        public void Unload()
        {
        }
    }

    public enum S_1x1_B_16_Style
    {
        TowelFolded = 0
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_B_16_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_B_16_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_16>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //Towels
        {
            Item.value = Item.buyPrice(silver: 8);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //Towels
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 8)
                .AddTile(ModContent.TileType<ShopBread>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.Silk, 4)
                .AddIngredient(ModContent.ItemType<ThreadItem>(), 2)
                .AddTile(ModContent.TileType<SewingBox>())
                .Register();
        }
    }
}
