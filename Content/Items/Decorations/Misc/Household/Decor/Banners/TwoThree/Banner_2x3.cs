using SquintlysFurnitureMod.Content.Tiles.Multi.All.TwoWide.TwoThree;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Decor.Banners.TwoThree;

internal class Banner_2x3 : ModItem
{
    public class Banner_2x3Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Banner_2x3(0));
            mod.AddContent(new Banner_2x3(1));
            mod.AddContent(new Banner_2x3(2));
            mod.AddContent(new Banner_2x3(3));
            mod.AddContent(new Banner_2x3(4));
            mod.AddContent(new Banner_2x3(5));
            mod.AddContent(new Banner_2x3(6));
            mod.AddContent(new Banner_2x3(7));
            mod.AddContent(new Banner_2x3(8));
            mod.AddContent(new Banner_2x3(9));
            mod.AddContent(new Banner_2x3(10));
            mod.AddContent(new Banner_2x3(11));
            mod.AddContent(new Banner_2x3(12));
            mod.AddContent(new Banner_2x3(13));
            mod.AddContent(new Banner_2x3(14));
            mod.AddContent(new Banner_2x3(15));
            mod.AddContent(new Banner_2x3(16));
            mod.AddContent(new Banner_2x3(17));
            mod.AddContent(new Banner_2x3(18));
            mod.AddContent(new Banner_2x3(19));
            mod.AddContent(new Banner_2x3(20));
            mod.AddContent(new Banner_2x3(21));
            mod.AddContent(new Banner_2x3(22));
            mod.AddContent(new Banner_2x3(23));
            mod.AddContent(new Banner_2x3(24));
            mod.AddContent(new Banner_2x3(25));
            mod.AddContent(new Banner_2x3(26));
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
            return "BannerWhitePointWideItem";
        }
        if (style == 1)
        {
            return "BannerWhiteFlatWideItem";
        }
        if (style == 2)
        {
            return "BannerWhiteRoundWideItem";
        }
        if (style == 3)
        {
            return "BannerGrayPointWideItem";
        }
        if (style == 4)
        {
            return "BannerGrayFlatWideItem";
        }
        if (style == 5)
        {
            return "BannerGrayRoundWideItem";
        }
        if (style == 6)
        {
            return "BannerBlackPointWideItem";
        }
        if (style == 7)
        {
            return "BannerBlackFlatWideItem";
        }
        if (style == 8)
        {
            return "BannerBlackRoundWideItem";
        }
        if (style == 9)
        {
            return "BannerPastelPointWideItem";
        }
        if (style == 10)
        {
            return "BannerPastelFlatWideItem";
        }
        if (style == 11)
        {
            return "BannerPastelRoundWideItem";
        }
        if (style == 12)
        {
            return "BannerBrightPointWideItem";
        }
        if (style == 13)
        {
            return "BannerBrightFlatWideItem";
        }
        if (style == 14)
        {
            return "BannerBrightRoundWideItem";
        }
        if (style == 15)
        {
            return "BannerNavyPointWideItem";
        }
        if (style == 16)
        {
            return "BannerNavyFlatWideItem";
        }
        if (style == 17)
        {
            return "BannerNavyRoundWideItem";
        }
        if (style == 18)
        {
            return "BannerPalePointWideItem";
        }
        if (style == 19)
        {
            return "BannerPaleFlatWideItem";
        }
        if (style == 20)
        {
            return "BannerPaleRoundWideItem";
        }
        if (style == 21)
        {
            return "BannerDullPointWideItem";
        }
        if (style == 22)
        {
            return "BannerDullFlatWideItem";
        }
        if (style == 23)
        {
            return "BannerDullRoundWideItem";
        }
        if (style == 24)
        {
            return "BannerDimPointWideItem";
        }
        if (style == 25)
        {
            return "BannerDimFlatWideItem";
        }
        if (style == 26)
        {
            return "BannerDimRoundWideItem";
        }

        throw new Exception("Invalid style");
    }

    public Banner_2x3(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<MP_A_2x3_12_SS_O>(), placeStyle);

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
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.WhitePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 3 | placeStyle == 4 | placeStyle == 5)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.GrayPaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 6 | placeStyle == 7 | placeStyle == 8)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.BlackPaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 9 | placeStyle == 10 | placeStyle == 11)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 12 | placeStyle == 13 | placeStyle == 14)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.BluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 15 | placeStyle == 16 | placeStyle == 17)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.DeepBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 18 | placeStyle == 19 | placeStyle == 20)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.WhitePaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 21 | placeStyle == 22 | placeStyle == 23)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.GrayPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 24 | placeStyle == 25 | placeStyle == 26)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 8)
            .AddIngredient(ItemID.BlackPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }
    }
}