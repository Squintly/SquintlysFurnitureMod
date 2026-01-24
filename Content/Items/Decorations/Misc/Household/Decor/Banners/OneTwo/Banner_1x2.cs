using SquintlysFurnitureMod.Content.Tiles.Multi.All.OneWide.OneTwo;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Decor.Banners.OneTwo;

internal class Banner_1x2 : ModItem
{
    public class Banner_1x2Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Banner_1x2(0));
            mod.AddContent(new Banner_1x2(1));
            mod.AddContent(new Banner_1x2(2));
            mod.AddContent(new Banner_1x2(3));
            mod.AddContent(new Banner_1x2(4));
            mod.AddContent(new Banner_1x2(5));
            mod.AddContent(new Banner_1x2(6));
            mod.AddContent(new Banner_1x2(7));
            mod.AddContent(new Banner_1x2(8));
            mod.AddContent(new Banner_1x2(9));
            mod.AddContent(new Banner_1x2(10));
            mod.AddContent(new Banner_1x2(11));
            mod.AddContent(new Banner_1x2(12));
            mod.AddContent(new Banner_1x2(13));
            mod.AddContent(new Banner_1x2(14));
            mod.AddContent(new Banner_1x2(15));
            mod.AddContent(new Banner_1x2(16));
            mod.AddContent(new Banner_1x2(17));
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
            return "BannerWhiteFlatShortItem";
        }
        if (style == 1)
        {
            return "BannerWhitePointShortItem";
        }
        if (style == 2)
        {
            return "BannerGrayFlatShortItem";
        }
        if (style == 3)
        {
            return "BannerGrayPointShortItem";
        }
        if (style == 4)
        {
            return "BannerBlackFlatShortItem";
        }
        if (style == 5)
        {
            return "BannerBlackPointShortItem";
        }
        if (style == 6)
        {
            return "BannerPastelFlatShortItem";
        }
        if (style == 7)
        {
            return "BannerPastelPointShortItem";
        }
        if (style == 8)
        {
            return "BannerBrightFlatShortItem";
        }
        if (style == 9)
        {
            return "BannerBrightPointShortItem";
        }
        if (style == 10)
        {
            return "BannerNavyFlatShortItem";
        }
        if (style == 11)
        {
            return "BannerNavyPointShortItem";
        }
        if (style == 12)
        {
            return "BannerPaleFlatShortItem";
        }
        if (style == 13)
        {
            return "BannerPalePointShortItem";
        }
        if (style == 14)
        {
            return "BannerDullFlatShortItem";
        }
        if (style == 15)
        {
            return "BannerDullPointShortItem";
        }
        if (style == 16)
        {
            return "BannerDimFlatShortItem";
        }
        if (style == 17)
        {
            return "BannerDimPointShortItem";
        }

        throw new Exception("Invalid style");
    }

    public Banner_1x2(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<MP_A_1x2_12_SS_O>(), placeStyle);

        Item.width = 16;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0 | placeStyle == 1)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.WhitePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 2 | placeStyle == 3)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.GrayPaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 4 | placeStyle == 5)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.BlackPaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 6 | placeStyle == 7)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 8 | placeStyle == 9)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.BluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 10 | placeStyle == 11)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.DeepBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 12 | placeStyle == 13)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.WhitePaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 14 | placeStyle == 15)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.GrayPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 16 | placeStyle == 17)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 2)
            .AddIngredient(ItemID.BlackPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }
    }
}