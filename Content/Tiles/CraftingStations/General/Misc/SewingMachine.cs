using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;

public class SewingMachine : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;
        Main.tileLavaDeath[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
        TileObjectData.newTile.Origin = new Point16(0, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(211, 211, 211), Language.GetText("Sewing Machine"));
        AdjTiles = new int[] { ModContent.TileType<SewingBox>() };
    }
    public override void HitWire(int i, int j)
    {
        ToggleTile(i, j);
    }

    public void ToggleTile(int i, int j)
    {
        Tile tile = Main.tile[i, j];
        int topX = i - tile.TileFrameX % 36 / 18; //change first number depending on size
        int topY = j - tile.TileFrameY % 36 / 18;

        bool shiftPressed = Main.keyState.PressingShift();
        if (!shiftPressed)
        {
            short frameAdjustment = (short)(tile.TileFrameX >= 108 ? -108 : 36); //change first two by total size, last by style size

            for (int x = topX; x < topX + 2; x++) // change depending on width
            {
                for (int y = topY; y < topY + 2; y++) // change height
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
            short frameAdjustment = (short)(tile.TileFrameX < 36 ? 108 : -36); //change first two by total size, last by style size

            for (int x = topX; x < topX + 2; x++) // change depending on width
            {
                for (int y = topY; y < topY + 2; y++) // change height
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
            NetMessage.SendTileSquare(-1, topX, topY, 2, 2); //change for width, height
        }
    }
}

public class SewingMachineItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 13);

        Item.DefaultToPlaceableTile(ModContent.TileType<SewingMachine>());
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 4)
            .AddIngredient(ModContent.ItemType<ThreadItem>(), 2)
            .AddTile(TileID.Sawmill)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.SilverCoin, 13)
            .AddTile(ModContent.TileType<ShopFabric>())
            .Register();
    }
}