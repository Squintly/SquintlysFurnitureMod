using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
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

namespace SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.MultiCraft;

public class ToolChestTall : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        Main.tileSolidTop[Type] = true;
        Main.tileTable[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.Width = 2;
        TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.RandomStyleRange = 4;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(167, 52, 52), Language.GetText("Tool Chest"));

        AdjTiles = new int[] { ModContent.TileType<ToolChest>() };
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
        int topX = i - tile.TileFrameX % 36 / 16; //change first number depending on size
        int topY = j - tile.TileFrameY % 54 / 16;
       
        bool shiftPressed = Main.keyState.PressingShift();
        if (shiftPressed)
        {
            short frameAdjustment = (short)(tile.TileFrameX >= 108 ? -108 : 36); //change first two by total size, last by style size

            for (int x = topX; x < topX + 2; x++) // change depending on width
            {
                for (int y = topY; y < topY + 3; y++) // change height
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
            NetMessage.SendTileSquare(-1, topX, topY, 1, 1); //change for width, height
        }
    }
}

public class ToolChestTallItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 55);

        Item.DefaultToPlaceableTile(ModContent.TileType<ToolChestTall>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.IronBar, 5)
            .AddIngredient(ModContent.ItemType<ToolBoxItem>())
            .AddIngredient(ModContent.ItemType<WorktableItem>())
            .AddIngredient(ModContent.ItemType<ChoppingBlockItem>())
            .AddIngredient(ModContent.ItemType<DecoBoxItem>())
            .AddIngredient(ModContent.ItemType<EaselItem>())
            .AddTile(ModContent.TileType<Worktable>())
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.SilverCoin, 55)
            .AddTile(ModContent.TileType<ShopMisc>())
            .Register();
    }
}