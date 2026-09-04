using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using SquintlysFurnitureMod.Content.Tiles.Multi.All.OneWide.OneThree;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Multi.All.OneWide.OneTwo.Items;

internal class MP_A_1x2_12_SS_O_Items : ModItem
{
    public class MP_A_1x2_12_SS_O_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 18; i++)
            {
                mod.AddContent(new MP_A_1x2_12_SS_O_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum MP_A_1x2_12_SS_O_Items_Style
    {
        BannerWhiteFlatShortItem = 0,
        BannerWhitePointShortItem = 1,
        BannerGrayFlatShortItem = 2,
        BannerGrayPointShortItem = 3,
        BannerBlackFlatShortItem = 4,
        BannerBlackPointShortItem = 5,
        BannerPastelFlatShortItem = 6,
        BannerPastelPointShortItem = 7,
        BannerBrightFlatShortItem = 8,
        BannerBrightPointShortItem = 9,
        BannerNavyFlatShortItem = 10,
        BannerNavyPointShortItem = 11,
        BannerPaleFlatShortItem = 12,
        BannerPalePointShortItem = 13,
        BannerDullFlatShortItem = 14,
        BannerDullPointShortItem = 15,
        BannerDimFlatShortItem = 16,
        BannerDimPointShortItem = 17
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(MP_A_1x2_12_SS_O_Items_Style), style);

        throw new Exception("Invalid style");
    }

    public MP_A_1x2_12_SS_O_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<MP_A_1x2_12_SS_O>(), placeStyle);

        Item.width = 16;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 4);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.SilverCoin, 4)
        .AddTile(ModContent.TileType<ShopFabric>())
        .Register();

        if (placeStyle == 0 | placeStyle == 1)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.WhitePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 2 | placeStyle == 3)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.GrayPaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 4 | placeStyle == 5)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.BlackPaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 6 | placeStyle == 7)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 8 | placeStyle == 9)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.BluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 10 | placeStyle == 11)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.DeepBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 12 | placeStyle == 13)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.WhitePaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 14 | placeStyle == 15)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.GrayPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }

        if (placeStyle == 16 | placeStyle == 17)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.BlackPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .AddTile(TileID.DyeVat)
            .Register();
        }
    }
}