using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.MultiCraft;
    public class ToolCupboard : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            TileID.Sets.DisableSmartCursor[Type] = true;

            Main.tileSolidTop[Type] = true;
            Main.tileTable[Type] = true;

            TileID.Sets.AvoidedByNPCs[Type] = true;
            TileID.Sets.InteractibleByNPCs[Type] = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };

            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 4;
            TileObjectData.newTile.RandomStyleRange = 4;

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.addTile(Type);

            AddMapEntry(new Color(167, 52, 52), Language.GetText("Tool Chest"));

            AdjTiles = new int[] { TileID.Dressers, ModContent.TileType<ToolChest>() };
        }

        public override bool RightClick(int i, int j)
        {
            SoundEngine.PlaySound(SoundID.Mech);
            ToggleTile(i, j);
            return true;
        }

        public void ToggleTile(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int topX = i - tile.TileFrameX % 54 / 18; //change first number depending on size
            int topY = j - tile.TileFrameY % 18 / 18;

            bool shiftPressed = Main.keyState.PressingShift();
            if (shiftPressed)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 162 ? 162 : -54); //change first two by total size, last by style size

                for (int x = topX; x < topX + 3; x++) // change depending on width
                {
                    for (int y = topY; y < topY + 1; y++) // change height
                    {
                        Main.tile[x, y].TileFrameX += frameAdjustment;

                        if (Wiring.running)
                        {
                            Wiring.SkipWire(x, y);
                        }
                    }
                }
                if (Main.netMode != NetmodeID.SinglePlayer)
                {
                    NetMessage.SendTileSquare(-1, topX, topY, 3, 1); //change for width, height
                }
            }
        }
    }

public class ToolCupboardItem : ModItem
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

        Item.DefaultToPlaceableTile(ModContent.TileType<ToolChestWide>());
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