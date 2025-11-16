using SquintlysFurnitureMod.Content.Tiles.Multi.All.OneWide.OneThree;
using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Decor.Banners.OneThree;

internal class Banner_1x3 : ModItem
{
    public class Banner_1x3Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Banner_1x3(0));
            mod.AddContent(new Banner_1x3(1));
            mod.AddContent(new Banner_1x3(2));
            mod.AddContent(new Banner_1x3(3));
            mod.AddContent(new Banner_1x3(4));
            mod.AddContent(new Banner_1x3(5));
            mod.AddContent(new Banner_1x3(6));
            mod.AddContent(new Banner_1x3(7));
            mod.AddContent(new Banner_1x3(8));
            mod.AddContent(new Banner_1x3(9));
            mod.AddContent(new Banner_1x3(10));
            mod.AddContent(new Banner_1x3(11));
            mod.AddContent(new Banner_1x3(12));
            mod.AddContent(new Banner_1x3(13));
            mod.AddContent(new Banner_1x3(14));
            mod.AddContent(new Banner_1x3(15));
            mod.AddContent(new Banner_1x3(16));
            mod.AddContent(new Banner_1x3(17));
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
            return "BannerWhiteFlatItem";
        }
        if (style == 1)
        {
            return "BannerWhitePointItem";
        }
        if (style == 2)
        {
            return "BannerGrayFlatItem";
        }
        if (style == 3)
        {
            return "BannerGrayPointItem";
        }
        if (style == 4)
        {
            return "BannerBlackFlatItem";
        }
        if (style == 5)
        {
            return "BannerBlackPointItem";
        }
        if (style == 6)
        {
            return "BannerPastelFlatItem";
        }
        if (style == 7)
        {
            return "BannerPastelPointItem";
        }
        if (style == 8)
        {
            return "BannerBrightFlatItem";
        }
        if (style == 9)
        {
            return "BannerBrightPointItem";
        }
        if (style == 10)
        {
            return "BannerNavyFlatItem";
        }
        if (style == 11)
        {
            return "BannerNavyPointItem";
        }
        if (style == 12)
        {
            return "BannerPaleFlatItem";
        }
        if (style == 13)
        {
            return "BannerPalePointItem";
        }
        if (style == 14)
        {
            return "BannerDullFlatItem";
        }
        if (style == 15)
        {
            return "BannerDullPointItem";
        }
        if (style == 16)
        {
            return "BannerDimFlatItem";
        }
        if (style == 17)
        {
            return "BannerDimPointItem";
        }

        throw new Exception("Invalid style");
    }

    public Banner_1x3(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<MP_A_1x3_12_SS_O>(), placeStyle);

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
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.WhitePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 2 | placeStyle == 3)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.GrayPaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 4 | placeStyle == 5)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.BlackPaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 6 | placeStyle == 7)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 8 | placeStyle == 9)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.BluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }
        
        if (placeStyle == 10 | placeStyle == 11)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.DeepBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 12 | placeStyle == 13)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.WhitePaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 14 | placeStyle == 15)
        {
            CreateRecipe()
            .AddIngredient(ItemID.Silk, 4)
            .AddIngredient(ItemID.GrayPaint)
            .AddIngredient(ItemID.SkyBluePaint)
            .AddTile(TileID.Loom)
            .Register();
        }

        if (placeStyle == 16 | placeStyle == 17)
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