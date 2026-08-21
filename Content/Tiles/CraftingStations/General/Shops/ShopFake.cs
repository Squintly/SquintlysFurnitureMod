using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops
{

public class ShopFake : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.Height = 4;
        TileObjectData.newTile.CoordinateHeights = new int[4] { 16, 16, 16, 18 };
        TileObjectData.newTile.Width = 5;
        TileObjectData.newTile.CoordinatePadding = 2;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(200, 200, 200), Language.GetText("Shop"));
        AnimationFrameHeight = 74;

        AdjTiles = new int[] { ModContent.TileType<ShopBooks>(), ModContent.TileType<ShopBread>(), ModContent.TileType<ShopFabric>(), ModContent.TileType<ShopFish>(), ModContent.TileType<ShopFlowers>(), ModContent.TileType<ShopFruit>(), ModContent.TileType<ShopGoods>(), ModContent.TileType<ShopMisc>(), ModContent.TileType<ShopPaint>(), ModContent.TileType<ShopSmith>(), ModContent.TileType<ShopVeggies>(), ModContent.TileType<ShopWeapons>() };
    }
    public override bool RightClick(int i, int j)
    {
        SoundEngine.PlaySound(SoundID.Mech);
        ToggleTile(i, j);
        return true;
    }
    public override void HitWire(int i, int j)
    {
        ToggleTile(i, j);
    }
    public void ToggleTile(int i, int j)
    {
        Tile tile = Main.tile[i, j];
        int topX = i - tile.TileFrameX % 90 / 16; //change first number depending on size
        int topY = j - tile.TileFrameY % 72 / 16;

        bool shiftPressed = Main.keyState.PressingShift();
        if (!shiftPressed)
        {
            short frameAdjustment = (short)(tile.TileFrameX >= 1080 ? -1080 : 90); //change first two by total size, last by style size

            for (int x = topX; x < topX + 5; x++) // change depending on width
            {
                for (int y = topY; y < topY + 4; y++) // change height
                {
                    Main.tile[x, y].TileFrameX += frameAdjustment;

                    if (Wiring.running)
                    {
                        Wiring.SkipWire(x, y);
                    }
                }
            }
        }
        if (shiftPressed)
        {
            short frameAdjustment = (short)(tile.TileFrameX <= 90 ? 1080 : -90); //change first two by total size, last by style size

            for (int x = topX; x < topX + 5; x++) // change depending on width
            {
                for (int y = topY; y < topY + 4; y++) // change height
                {
                    Main.tile[x, y].TileFrameX += frameAdjustment;

                    if (Wiring.running)
                    {
                        Wiring.SkipWire(x, y);
                    }
                }
            }
        }
        if (Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendTileSquare(-1, topX, topY, 5, 4); //change for width, height
        }
    }
}
public class ShopFakeItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 30);

        Item.DefaultToPlaceableTile(ModContent.TileType<ShopFake>());
    }

    public override void AddRecipes()
    {
            CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<ShopRealItem>())
            .AddTile(TileID.Sawmill)
            .Register();
    }
}
}
