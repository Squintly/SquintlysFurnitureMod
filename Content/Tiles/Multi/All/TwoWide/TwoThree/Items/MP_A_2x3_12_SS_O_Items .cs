using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Multi.All.TwoWide.TwoThree.Items;

internal class MP_A_2x3_12_SS_O_Items : ModItem
{
    public class MP_A_2x3_12_SS_O_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 27; i++)
            {
                mod.AddContent(new MP_A_2x3_12_SS_O_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum MP_A_2x3_12_SS_O_Items_Style
    {
        BannerWhiteFlatWideItem = 0,
        BannerWhitePointWideItem = 1,
        BannerWhiteRoundWideItem = 2, 
        BannerGrayFlatWideItem = 3,
        BannerGrayPointWideItem = 4,
        BannerGrayRoundWideItem = 5,
        BannerBlackFlatWideItem = 6,
        BannerBlackPointWideItem = 7,
        BannerBlackRoundWideItem = 8,
        BannerPastelFlatWideItem = 9,
        BannerPastelPointWideItem = 10,
        BannerPastelRoundWideItem = 11,
        BannerBrightFlatWideItem = 12,
        BannerBrightPointWideItem = 13,
        BannerBrightRoundWideItem = 14,
        BannerNavyFlatWideItem = 15,
        BannerNavyPointWideItem = 16,
        BannerNavyRoundWideItem = 17,
        BannerPaleFlatWideItem = 18,
        BannerPalePointWideItem = 19,
        BannerPaleRoundWideItem = 20,
        BannerDullFlatWideItem = 21,
        BannerDullPointWideItem = 22,
        BannerDullRoundWideItem = 23,
        BannerDimFlatWideItem = 24,
        BannerDimPointWideItem = 25,
        BannerDimRoundWideItem = 26
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(MP_A_2x3_12_SS_O_Items_Style), style);

        throw new Exception("Invalid style");
    }

    public MP_A_2x3_12_SS_O_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<MP_A_2x3_12_SS_O>(), placeStyle);

        Item.width = 16;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 16);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.SilverCoin, 16)
        .AddTile(ModContent.TileType<ShopFabric>())
        .Register();

        if (placeStyle == 0 | placeStyle == 1)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.WhitePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 2 | placeStyle == 3)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.GrayPaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 4 | placeStyle == 5)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.BlackPaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 6 | placeStyle == 7)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 8 | placeStyle == 9)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.BluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 10 | placeStyle == 11)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.DeepBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 12 | placeStyle == 13)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.WhitePaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 14 | placeStyle == 15)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.GrayPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 16 | placeStyle == 17)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.BlackPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }
    }
}