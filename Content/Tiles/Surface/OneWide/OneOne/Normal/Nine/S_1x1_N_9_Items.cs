using SquintlysFurnitureMod.Content.Items.Materials;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Normal.Nine;

internal class S_1x1_N_9_Items : ModItem
{
    public class S_1x1_N_9_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 2; i++)
            {
                mod.AddContent(new S_1x1_N_9_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_N_9_Style
    {
        Cracker = 0,
        ToyDino = 1
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_N_9_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_N_9_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_N_9>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //cracker
        {
            Item.value = Item.buyPrice(copper: 12);
        }
        if (placeStyle == 1) //toy dino
        {
            Item.value = Item.buyPrice(copper: 20);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //cracker
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 12)
                .AddTile(ModContent.TileType<ShopCrimbo>())
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Paper>(), 4)
                .AddIngredient(ModContent.ItemType<Plastic>(), 2)
                .AddTile(ModContent.TileType<DecoBoxTile>())
                .Register();
        }
        if (placeStyle == 1) //toy dino
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 20)
                .AddTile(ModContent.TileType<ShopToys>())
                .Register();
        }
    }
}