using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoTwo.Four;

internal class S_2x2_4_Items : ModItem
{
    public class S_2x2_4_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 3; i++)
            {
                mod.AddContent(new S_2x2_4_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_2x2_4_Style
    {
        SpringRabbitBig = 0,
        SugarBig = 1,
        FlourBig = 2
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_2x2_4_Style), style);

        throw new Exception("Invalid style");
    }

    public S_2x2_4_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_2x2_4>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //Big rabbit plush
        {
            Item.value = Item.buyPrice(silver: 20);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //Big rabbit plush
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 8)
                .AddIngredient(ModContent.ItemType<ThreadItem>(), 8)
                .AddIngredient(ItemID.Hay, 6)
                .AddTile(ModContent.TileType<SewingBox>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 20)
                .AddTile(ModContent.TileType<ShopMisc>())
                .Register();
        }
        if (placeStyle == 1) //sugar
        {
            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:Sugars")
                .AddTile(ModContent.TileType<Worktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 20)
                .AddTile(ModContent.TileType<ShopGoods>())
                .Register();
        }
        if (placeStyle == 1) //flour
        {
            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:Flours")
                .AddTile(ModContent.TileType<Worktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 20)
                .AddTile(ModContent.TileType<ShopGoods>())
                .Register();
        }
    }
}