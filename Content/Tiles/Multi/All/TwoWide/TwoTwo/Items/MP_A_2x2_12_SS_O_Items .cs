using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using SquintlysFurnitureMod.Content.Tiles.Multi.All.TwoWide.TwoThree;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Multi.All.TwoWide.TwoTwo.Items;

internal class MP_A_2x2_12_SS_O_Items : ModItem
{
    public class MP_A_2x2_12_SS_O_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 27; i++)
            {
                mod.AddContent(new MP_A_2x2_12_SS_O_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum MP_A_2x2_12_SS_O_Items_Style
    {
        BannerWhiteFlatWideShortItem = 0,
        BannerWhitePointWideShortItem = 1,
        BannerWhiteRoundWideShortItem = 2, 
        BannerGrayFlatWideShortItem = 3,
        BannerGrayPointWideShortItem = 4,
        BannerGrayRoundWideShortItem = 5,
        BannerBlackFlatWideShortItem = 6,
        BannerBlackPointWideShortItem = 7,
        BannerBlackRoundWideShortItem = 8,
        BannerPastelFlatWideShortItem = 9,
        BannerPastelPointWideShortItem = 10,
        BannerPastelRoundWideShortItem = 11,
        BannerBrightFlatWideShortItem = 12,
        BannerBrightPointWideShortItem = 13,
        BannerBrightRoundWideShortItem = 14,
        BannerNavyFlatWideShortItem = 15,
        BannerNavyPointWideShortItem = 16,
        BannerNavyRoundWideShortItem = 17,
        BannerPaleFlatWideShortItem = 18,
        BannerPalePointWideShortItem = 19,
        BannerPaleRoundWideShortItem = 20,
        BannerDullFlatWideShortItem = 21,
        BannerDullPointWideShortItem = 22,
        BannerDullRoundWideShortItem = 23,
        BannerDimFlatWideShortItem = 24,
        BannerDimPointWideShortItem = 25,
        BannerDimRoundWideShortItem = 26
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(MP_A_2x2_12_SS_O_Items_Style), style);

        throw new Exception("Invalid style");
    }

    public MP_A_2x2_12_SS_O_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<MP_A_2x2_12_SS_O>(), placeStyle);

        Item.width = 16;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 12);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.SilverCoin, 12)
        .AddTile(ModContent.TileType<ShopFabric>())
        .Register();

        if (placeStyle == 0 | placeStyle == 1)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 6)
            .AddIngredient(ItemID.WhitePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 2 | placeStyle == 3)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 6)
            .AddIngredient(ItemID.GrayPaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 4 | placeStyle == 5)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 6)
            .AddIngredient(ItemID.BlackPaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 6 | placeStyle == 7)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 6)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 8 | placeStyle == 9)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 6)
            .AddIngredient(ItemID.BluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 10 | placeStyle == 11)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 6)
            .AddIngredient(ItemID.DeepBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 12 | placeStyle == 13)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 6)
            .AddIngredient(ItemID.WhitePaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 14 | placeStyle == 15)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 6)
            .AddIngredient(ItemID.GrayPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 16 | placeStyle == 17)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 6)
            .AddIngredient(ItemID.BlackPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }
    }
}