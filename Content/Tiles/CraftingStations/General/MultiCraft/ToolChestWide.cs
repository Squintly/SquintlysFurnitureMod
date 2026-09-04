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
    public class ToolChestWide : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;

            Main.tileSolidTop[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileContainer[Type] = true;

            TileID.Sets.BasicDresser[Type] = true;
            TileID.Sets.AvoidedByNPCs[Type] = true;
            TileID.Sets.AvoidedByMeteorLanding[Type] = true;
            TileID.Sets.InteractibleByNPCs[Type] = true;
            TileID.Sets.IsAContainer[Type] = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
            TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, processedCoordinates: true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, processedCoordinates: false);

            TileObjectData.newTile.AnchorInvalidTiles = new int[] {
                TileID.MagicalIceBlock,
                TileID.Boulder,
                TileID.BouncyBoulder,
                TileID.LifeCrystalBoulder,
                TileID.RollingCactus
            };

            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 4;
            TileObjectData.newTile.RandomStyleRange = 4;

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.addTile(Type);

            AddMapEntry(new Color(200, 200, 200), this.GetLocalization("MapEntry0"), MapChestName);

            AdjTiles = new int[] { TileID.Dressers, ModContent.TileType<ToolChest>() };
        }

        public override LocalizedText DefaultContainerName(int frameX, int frameY)
        {
            int option = frameX / 216;
            return this.GetLocalization("MapEntry" + option);
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return true;
        }

        public override void ModifySmartInteractCoords(ref int width, ref int height, ref int frameWidth, ref int frameHeight, ref int extraY)
        {
            width = 3;
            height = 1;
            extraY = 0;
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            int left = Main.tile[i, j].TileFrameX / 18;
            left %= 3;
            left = i - left;
            int top = j - Main.tile[i, j].TileFrameY / 18;

            bool shiftPressed = Main.keyState.PressingShift();

            if (shiftPressed)
            {
                SoundEngine.PlaySound(SoundID.Mech);
                ToggleTile(i, j);
                return true;
            }


            if (Main.tile[i, j].TileFrameY == 0)
            {
                Main.CancelClothesWindow(true);
                Main.mouseRightRelease = false;
                player.CloseSign();
                player.SetTalkNPC(-1);
                Main.npcChatCornerItem = 0;
                Main.npcChatText = "";

                if (Main.editChest)
                {
                    SoundEngine.PlaySound(SoundID.MenuTick);
                    Main.editChest = false;
                    Main.npcChatText = string.Empty;
                }
                if (player.editedChestName)
                {
                    NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
                    player.editedChestName = false;
                }
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    if (left == player.chestX && top == player.chestY && player.chest != -1)
                    {
                        player.chest = -1;
                        Recipe.FindRecipes();
                        SoundEngine.PlaySound(SoundID.MenuClose);
                    }
                    else
                    {
                        NetMessage.SendData(MessageID.RequestChestOpen, -1, -1, null, left, top);
                        Main.stackSplit = 600;
                    }
                }
                else
                {
                    player.piggyBankProjTracker.Clear();
                    player.voidLensChest.Clear();
                    int chestIndex = Chest.FindChest(left, top);
                    if (chestIndex != -1)
                    {
                        Main.stackSplit = 600;
                        if (chestIndex == player.chest)
                        {
                            player.chest = -1;
                            Recipe.FindRecipes();
                            SoundEngine.PlaySound(SoundID.MenuClose);
                        }
                        else if (chestIndex != player.chest && player.chest == -1)
                        {
                            player.OpenChest(left, top, chestIndex);
                            SoundEngine.PlaySound(SoundID.MenuOpen);
                        }
                        else
                        {
                            player.OpenChest(left, top, chestIndex);
                            SoundEngine.PlaySound(SoundID.MenuTick);
                        }
                        Recipe.FindRecipes();
                    }
                }
            }
            else
            {
                Main.playerInventory = false;
                player.chest = -1;
                Recipe.FindRecipes();
                player.SetTalkNPC(-1);
                Main.npcChatCornerItem = 0;
                Main.npcChatText = "";
                Main.interactedDresserTopLeftX = left;
                Main.interactedDresserTopLeftY = top;
                Main.OpenClothesWindow();
            }
            return true;
        }
        public void ToggleTile(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int topX = i - tile.TileFrameX % 54 / 16; //change first number depending on size
            int topY = j - tile.TileFrameY % 36 / 16;

            short frameAdjustment = (short)(tile.TileFrameX >= 162 ? 162 : -54); //change first two by total size, last by style size

            for (int x = topX; x < topX + 3; x++) // change depending on width
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
            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendTileSquare(-1, topX, topY, 3, 2); //change for width, height
            }
        }
        public void MouseOverNearAndFarSharedLogic(Player player, int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int left = i;
            int top = j;
            left -= tile.TileFrameX % 54 / 18;
            if (tile.TileFrameY % 36 != 0)
            {
                top--;
            }
            int chestIndex = Chest.FindChest(left, top);
            player.cursorItemIconID = -1;
            if (chestIndex < 0)
            {
                player.cursorItemIconText = Language.GetTextValue("LegacyDresserType.0");
            }
            else
            {
                string defaultName = TileLoader.DefaultContainerName(tile.TileType, tile.TileFrameX, tile.TileFrameY); // This gets the ContainerName text for the currently selected language

                if (Main.chest[chestIndex].name != "")
                {
                    player.cursorItemIconText = Main.chest[chestIndex].name;
                }
                else
                {
                    player.cursorItemIconText = defaultName;
                }
                if (player.cursorItemIconText == defaultName)
                {
                    int style = TileObjectData.GetTileStyle(Main.tile[i, j]);
                    player.cursorItemIconID = TileLoader.GetItemDropFromTypeAndStyle(Type, style);
                    player.cursorItemIconText = "";
                }
            }
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
        }

        public override void MouseOverFar(int i, int j)
        {
            Player player = Main.LocalPlayer;
            MouseOverNearAndFarSharedLogic(player, i, j);
            if (player.cursorItemIconText == "")
            {
                player.cursorItemIconEnabled = false;
                player.cursorItemIconID = 0;
            }
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            MouseOverNearAndFarSharedLogic(player, i, j);
            if (Main.tile[i, j].TileFrameY > 0)
            {
                player.cursorItemIconID = ItemID.FamiliarShirt;
                player.cursorItemIconText = "";
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Chest.DestroyChest(i, j);
        }

        public static string MapChestName(string name, int i, int j)
        {
            int left = i;
            int top = j;
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX % 36 != 0)
            {
                left--;
            }

            if (tile.TileFrameY != 0)
            {
                top--;
            }

            int chest = Chest.FindChest(left, top);
            if (chest < 0)
            {
                return Language.GetTextValue("LegacyDresserType.0");
            }

            if (Main.chest[chest].name == "")
            {
                return name;
            }

            return name + ": " + Main.chest[chest].name;
        }
    }

public class ToolChestWideItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(gold: 2, silver: 50);

        Item.DefaultToPlaceableTile(ModContent.TileType<ToolChestWide>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.IronBar, 10)
            .AddRecipeGroup("SquintlyFurnitureMod:ToolChests")
            .AddIngredient(ModContent.ItemType<ButcherTableItem>())
            .AddIngredient(ModContent.ItemType<FisherTableItem>())
            .AddIngredient(ModContent.ItemType<ArchivistDeskItem>())
            .AddIngredient(ModContent.ItemType<PrintingPress>())
            .AddIngredient(ModContent.ItemType<FloralWorktableItem>())
            .AddTile(ModContent.TileType<Worktable>())
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.SilverCoin, 50)
            .AddIngredient(ItemID.GoldCoin, 2)
            .AddTile(ModContent.TileType<ShopMisc>())
            .Register();
    }
}