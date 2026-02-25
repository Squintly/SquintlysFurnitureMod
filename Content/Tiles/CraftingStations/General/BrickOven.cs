using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using SquintlysFurnitureMod.Content.Tiles.Wall.ThreeWide.ThreeTwo;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;

public class BrickOven : ModTile
{
    public enum StyleID
    {
        BrickOven, //0
    }

    private Asset<Texture2D> flameTexture;

    public override void Load()
    {
        flameTexture = ModContent.Request<Texture2D>(Texture + "_Flame");
    }

    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;
        Main.tileLavaDeath[Type] = false;
        Main.tileNoAttach[Type] = true;

        Main.tileLighted[Type] = true;
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        AdjTiles = new int[] { TileID.Torches };

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.Width = 2;
        TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 18 };
        TileObjectData.newTile.Origin = new Point16(0, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(195, 112, 87), Language.GetText("Brick Oven"));
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        if (Main.tile[i, j].TileFrameX / 68 != 0)
        {
            return;
        }

        StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);
        switch (style)
        {
            default:
                r = 1f;
                g = 0.95f;
                b = 0.8f;
                break;
        }
    }

    public override void GetTileFlameData(int i, int j, ref TileDrawing.TileFlameData tileFlameData)
    {
        ulong flameSeed = Main.TileFrameSeed ^ (ulong)(((long)i << 32) | (uint)j);

        tileFlameData.flameTexture = flameTexture.Value;
        tileFlameData.flameSeed = flameSeed;

        StyleID style = (StyleID)TileObjectData.GetTileStyle(Main.tile[i, j]);
        switch (style)
        {
            default:
                tileFlameData.flameCount = 7;
                tileFlameData.flameColor = new Color(100, 100, 100, 0);
                tileFlameData.flameRangeXMin = -10;
                tileFlameData.flameRangeXMax = 11;
                tileFlameData.flameRangeYMin = -10;
                tileFlameData.flameRangeYMax = 1;
                tileFlameData.flameRangeMultX = 0.15f;
                tileFlameData.flameRangeMultY = 0.35f;
                break;
        }
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        if (++frameCounter >= 4)
        {
            frameCounter = 0;
            // We animate through the 1st 8 frames. The 9th frame is manually drawn if in the "off" state so it is not included in the animation logic here.
            frame = ++frame % 8;
        }
    }

    public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
    {
        var tile = Main.tile[i, j];
        if (tile.TileFrameY < 36)
        {
            frameYOffset = Main.tileFrame[type] * 36;
        }
    }
}

public class BrickOvenItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);

        Item.DefaultToPlaceableTile(ModContent.TileType<BrickOven>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.GrayBrick, 20)
            .AddRecipeGroup(RecipeGroupID.Wood, 5)
            .AddIngredient(ItemID.Torch, 5)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}