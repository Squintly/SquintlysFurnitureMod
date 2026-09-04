using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Multi.All.OneWide.OneThree.Items;

internal class MP_A_1x3_12_SS_O_Items : ModItem
{
    public class MP_A_1x3_12_SS_O_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 18; i++)
            {
                mod.AddContent(new MP_A_1x3_12_SS_O_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum MP_A_1x3_12_SS_O_Items_Style
    {
        BannerWhiteFlatItem = 0,
        BannerWhitePointItem = 1,
        BannerGrayFlatItem = 2,
        BannerGrayPointItem = 3,
        BannerBlackFlatItem = 4,
        BannerBlackPointItem = 5,
        BannerPastelFlatItem = 6,
        BannerPastelPointItem = 7,
        BannerBrightFlatItem = 8,
        BannerBrightPointItem = 9,
        BannerNavyFlatItem = 10,
        BannerNavyPointItem = 11,
        BannerPaleFlatItem = 12,
        BannerPalePointItem = 13,
        BannerDullFlatItem = 14,
        BannerDullPointItem = 15,
        BannerDimFlatItem = 16,
        BannerDimPointItem = 17
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(MP_A_1x3_12_SS_O_Items_Style), style);

        throw new Exception("Invalid style");
    }

    public MP_A_1x3_12_SS_O_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<MP_A_1x3_12_SS_O>(), placeStyle);

        Item.width = 16;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 8);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.SilverCoin, 8)
        .AddTile(ModContent.TileType<ShopFabric>())
        .Register();

        if (placeStyle == 0 | placeStyle == 1)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.WhitePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 2 | placeStyle == 3)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.GrayPaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 4 | placeStyle == 5)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.BlackPaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 6 | placeStyle == 7)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 8 | placeStyle == 9)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.BluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 10 | placeStyle == 11)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.DeepBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 12 | placeStyle == 13)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.WhitePaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 14 | placeStyle == 15)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.GrayPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 16 | placeStyle == 17)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.BlackPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }
    }
}