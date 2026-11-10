using SquintlysFurnitureMod.Content.Items.Blocks.Holiday;
using SquintlysFurnitureMod.Content.Items.Materials;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Normal.Four;

internal class S_1x1_N_4_Items : ModItem
{
    public class S_1x1_N_4_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 6; i++)
            {
                mod.AddContent(new S_1x1_N_4_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_N_4_Style
    {
        CreamandSugar = 0,
        ChristmasCard = 1,
        Binder = 2,
        RolledTowels = 3,
        Rose = 4,
        Chocolates = 5
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_N_4_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_N_4_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_N_4>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        if (placeStyle == 0) //CreamandSugar
        {
            Item.value = Item.buyPrice(silver: 5, copper: 50);
        }
        if (placeStyle == 1) //ChristmasCard
        {
            Item.value = Item.buyPrice(copper: 7);
        }
        if (placeStyle == 2) //Binder
        {
            Item.value = Item.buyPrice(copper: 12);
        }
        if (placeStyle == 3) // rolled towels
        {
            Item.value = Item.buyPrice(silver: 5);
        }
        if (placeStyle == 4) // roses
        {
            Item.value = Item.buyPrice(silver: 1);
        }
        if (placeStyle == 5) // chocolates
        {
            Item.value = Item.buyPrice(silver: 52);
        }
    }
    public override void AddRecipes()
    {
        if (placeStyle == 0) //cream and sugar
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 5)
                .AddIngredient(ItemID.CopperCoin, 50)
                .AddTile(ModContent.TileType<ShopGoods>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.ClayBlock)
                .AddRecipeGroup("SquintlyFurnitureMod:Sugars")
                .AddRecipeGroup("SquintlyFurnitureMod:Milks")
                .AddTile(ModContent.TileType<PotteryWheel>())
                .Register();
        }
        if (placeStyle == 1) //christmas cards
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 7)
                .AddTile(ModContent.TileType<ShopCrimbo>())
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Paper>(), 2)
                .AddRecipeGroup("SquintlyFurnitureMod:Paint")
                .AddTile(ModContent.TileType<PrintingPressTile>())
                .Register();
        }
        if (placeStyle == 2) //Binder
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 12)
                .AddTile(ModContent.TileType<ShopBooks>())
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Plastic>(), 2)
                .AddIngredient(ModContent.ItemType<Paper>(), 4)
                .AddTile(ModContent.TileType<PrintingPressTile>())
                .Register();
        }
        if (placeStyle == 3) //rolled towels
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 2)
                .AddIngredient(ModContent.ItemType<ThreadItem>(), 2)
                .AddTile(ModContent.TileType<SewingBox>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 5)
                .AddTile(ModContent.TileType<ShopHeartfelt>())
                .Register();
        }
        if (placeStyle == 4) //roses
        {
            CreateRecipe()
                .AddIngredient(ItemID.FlowerPacketRed)
                .AddTile(ModContent.TileType<FloralWorktable>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.SilverCoin, 1)
                .AddTile(ModContent.TileType<ShopHeartfelt>())
                .Register();
        }
        if (placeStyle == 5) //chocolates
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ChocolateBlockItem>(), 2)
                .AddIngredient(ModContent.ItemType<Paper>(), 2)
                .AddTile(ModContent.TileType<Stoves>())
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CopperCoin, 52)
                .AddTile(ModContent.TileType<ShopHeartfelt>())
                .Register();
        }
    }
}
