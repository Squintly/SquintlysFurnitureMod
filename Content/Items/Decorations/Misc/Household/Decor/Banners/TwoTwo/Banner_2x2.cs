using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Decor.Banners.TwoThree;
using SquintlysFurnitureMod.Content.Tiles.Multi.All.OneWide.OneThree;
using SquintlysFurnitureMod.Content.Tiles.Multi.All.TwoWide.TwoTwo;
using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Decor.Banners.TwoTwo;

internal class Banner_2x2 : ModItem
{
    public class Banner_2x2Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Banner_2x2(0));
            mod.AddContent(new Banner_2x2(1));
            mod.AddContent(new Banner_2x2(2));
            mod.AddContent(new Banner_2x2(3));
            mod.AddContent(new Banner_2x2(4));
            mod.AddContent(new Banner_2x2(5));
            mod.AddContent(new Banner_2x2(6));
            mod.AddContent(new Banner_2x2(7));
            mod.AddContent(new Banner_2x2(8));
            mod.AddContent(new Banner_2x2(9));
            mod.AddContent(new Banner_2x2(10));
            mod.AddContent(new Banner_2x2(11));
            mod.AddContent(new Banner_2x2(12));
            mod.AddContent(new Banner_2x2(13));
            mod.AddContent(new Banner_2x2(14));
            mod.AddContent(new Banner_2x2(15));
            mod.AddContent(new Banner_2x2(16));
            mod.AddContent(new Banner_2x2(17));
            mod.AddContent(new Banner_2x2(18));
            mod.AddContent(new Banner_2x2(19));
            mod.AddContent(new Banner_2x2(20));
            mod.AddContent(new Banner_2x2(21));
            mod.AddContent(new Banner_2x2(22));
            mod.AddContent(new Banner_2x2(23));
            mod.AddContent(new Banner_2x2(24));
            mod.AddContent(new Banner_2x2(25));
            mod.AddContent(new Banner_2x2(26));
        }
        public void Unload()
        {
        }
    }
    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        if (style == 0)
        {
            return "BannerWhitePointWideShortItem";
        }
        if (style == 1)
        {
            return "BannerWhiteFlatWideShortItem";
        }
        if (style == 2)
        {
            return "BannerWhiteRoundWideShortItem";
        }
        if (style == 3)
        {
            return "BannerGrayPointWideShortItem";
        }
        if (style == 4)
        {
            return "BannerGrayFlatWideShortItem";
        }
        if (style == 5)
        {
            return "BannerGrayRoundWideShortItem";
        }
        if (style == 6)
        {
            return "BannerBlackPointWideShortItem";
        }
        if (style == 7)
        {
            return "BannerBlackFlatWideShortItem";
        }
        if (style == 8)
        {
            return "BannerBlackRoundWideShortItem";
        }
        if (style == 9)
        {
            return "BannerPastelPointWideShortItem";
        }
        if (style == 10)
        {
            return "BannerPastelFlatWideShortItem";
        }
        if (style == 11)
        {
            return "BannerPastelRoundWideShortItem";
        }
        if (style == 12)
        {
            return "BannerBrightPointWideShortItem";
        }
        if (style == 13)
        {
            return "BannerBrightFlatWideShortItem";
        }
        if (style == 14)
        {
            return "BannerBrightRoundWideShortItem";
        }
        if (style == 15)
        {
            return "BannerNavyPointWideShortItem";
        }
        if (style == 16)
        {
            return "BannerNavyFlatWideShortItem";
        }
        if (style == 17)
        {
            return "BannerNavyRoundWideShortItem";
        }
        if (style == 18)
        {
            return "BannerPalePointWideShortItem";
        }
        if (style == 19)
        {
            return "BannerPaleFlatWideShortItem";
        }
        if (style == 20)
        {
            return "BannerPaleRoundWideShortItem";
        }
        if (style == 21)
        {
            return "BannerDullPointWideShortItem";
        }
        if (style == 22)
        {
            return "BannerDullFlatWideShortItem";
        }
        if (style == 23)
        {
            return "BannerDullRoundWideShortItem";
        }
        if (style == 24)
        {
            return "BannerDimPointWideShortItem";
        }
        if (style == 25)
        {
            return "BannerDimFlatWideShortItem";
        }
        if (style == 26)
        {
            return "BannerDimRoundWideShortItem";
        }

        throw new Exception("Invalid style");
    }

    public Banner_2x2(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<MP_A_2x2_12_SS_O>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0 | placeStyle == 1 | placeStyle == 2)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.WhitePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 3 | placeStyle == 4 | placeStyle == 5)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.GrayPaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 6 | placeStyle == 7 | placeStyle == 8)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.BlackPaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 9 | placeStyle == 10 | placeStyle == 11)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 12 | placeStyle == 13 | placeStyle == 14)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.BluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 15 | placeStyle == 16 | placeStyle == 17)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.DeepBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 18 | placeStyle == 19 | placeStyle == 20)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.WhitePaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 21 | placeStyle == 22 | placeStyle == 23)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.GrayPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 24 | placeStyle == 25 | placeStyle == 26)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.BlackPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }
    }
}