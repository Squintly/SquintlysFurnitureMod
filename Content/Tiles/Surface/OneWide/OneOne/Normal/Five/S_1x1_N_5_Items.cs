using SquintlysFurnitureMod.Content.Items.Materials;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Normal.Five;

internal class S_1x1_N_5_Items : ModItem
{
    public class S_1x1_N_5_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 4; i++)
            {
                mod.AddContent(new S_1x1_N_5_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_N_5_Style
    {
        Cheese = 0,
        DrinkingGlass = 1,
        StickyNote = 2,
        Berry = 3
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_N_5_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_N_5_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_N_5>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //small cheese
        {
            Item.value = Item.buyPrice(silver: 5);
        }
        if (placeStyle == 1) //drinking glass
        {
            Item.value = Item.buyPrice(copper: 1);
        }
        if (placeStyle == 2) //sticky notes
        {
            Item.value = Item.buyPrice(copper: 4);
        }
        if (placeStyle == 3) // berries
        {
            Item.value = Item.buyPrice(silver: 20);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //small cheese 
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 5)
                .AddTile(ModContent.TileType<ShopGoods>())
                .Register();

            CreateRecipe(4)
                .AddRecipeGroup("SquintlyFurnitureMod:Milks")
                .AddTile(ModContent.TileType<Fridges>())
                .Register();
        }
        if (placeStyle == 1) //drinking glass
        {
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 2)
                .AddTile(ModContent.TileType<Smelter>())
                .Register();
        }
        if (placeStyle == 2) //Sticky note
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 4)
                .AddTile(ModContent.TileType<ShopBooks>())
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Paper>(), 4)
                .AddTile(ModContent.TileType<PrintingPressTile>())
                .Register();
        }
        if (placeStyle == 3) //berries
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 20)
                .AddTile(ModContent.TileType<ShopFruit>())
                .Register();

            CreateRecipe()
                .AddRecipeGroup("SquintlyFurnitureMod:AllFruit")
                .AddTile(ModContent.TileType<CuttingBoard>())
                .Register();
        }
    }
}
