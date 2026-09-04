using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Content;
using SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Counters.Counters_9;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using System.Collections.Generic;
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

namespace SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Cupboards.Cupboards_6
{
    public class Cupboards_6_Retro : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;

            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 500;

            Main.tileSolidTop[Type] = true;
            Main.tileTable[Type] = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            Main.tileContainer[Type] = true;
            TileID.Sets.BasicChest[Type] = true;

            TileID.Sets.IsAContainer[Type] = true;
            TileID.Sets.FriendlyFairyCanLureTo[Type] = true;
            TileID.Sets.GeneralPlacementTiles[Type] = false;
            TileID.Sets.PreventsTileRemovalIfOnTopOfIt[Type] = true;
			TileID.Sets.PreventsTileHammeringIfOnTopOfIt[Type] = true;

            TileID.Sets.AvoidedByNPCs[Type] = true;
            TileID.Sets.AvoidedByMeteorLanding[Type] = true;
            TileID.Sets.InteractibleByNPCs[Type] = true;

            TileID.Sets.DoesntGetReplacedWithTileReplacement[Type] = true; //Cludge to avoid figuring out custom replace logic

            AdjTiles = new int[] { TileID.Containers };

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16 };

            TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);

            TileObjectData.newTile.AnchorInvalidTiles = new int[]
            {
                TileID.MagicalIceBlock,
                TileID.Boulder,
                TileID.BouncyBoulder,
                TileID.LifeCrystalBoulder,
                TileID.RollingCactus
            };

            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.AnchorWall = true;

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.SpecificRandomStyles = [0, 7, 14, 21, 28, 35];
            TileObjectData.newTile.StyleMultiplier = 42;

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.addTile(Type);

            AddMapEntry(new Color(200, 200, 200), this.GetLocalization("MapEntry0"), MapChestName);

            AnimationFrameHeight = 36;
        }
        public override ushort GetMapOption(int i, int j)
        {
            return (ushort)(Main.tile[i, j].TileFrameX / 1512);
        }

        public override LocalizedText DefaultContainerName(int frameX, int frameY)
        {
            int option = frameX / 1512;
            return this.GetLocalization("MapEntry" + option);
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return true;
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
                return Language.GetTextValue("LegacyChestType.0");
            }

            if (Main.chest[chest].name == "")
            {
                return name;
            }

            return name + ": " + Main.chest[chest].name;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Chest.DestroyChest(i, j);
        }
        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];

            bool shiftPressed = Main.keyState.PressingShift();

            if (shiftPressed)
            {
                SoundEngine.PlaySound(SoundID.Mech);
                ToggleTile(i, j);
                return true;
            }
            else
            {
                Main.mouseRightRelease = false;
                int left = i;
                int top = j;
                if (tile.TileFrameX % 36 != 0)
                {
                    left--;
                }

                if (tile.TileFrameY != 0)
                {
                    top--;
                }

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

                int chest = Chest.FindChest(left, top);
                if (chest != -1)
                {
                    Main.stackSplit = 600;
                    if (chest == player.chest)
                    {
                        player.chest = -1;
                        SoundEngine.PlaySound(SoundID.MenuClose);
                    }
                    else
                    {
                        SoundEngine.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);
                        player.OpenChest(left, top, chest);
                    }

                    Recipe.FindRecipes();
                }
                return true;
            }
        }
        public void ToggleTile(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int topX = i - tile.TileFrameX % 36 / 16; //change first number depending on size
            int topY = j - tile.TileFrameY % 36 / 16;

            bool shiftPressed = Main.keyState.PressingShift();
            bool altPressed = Main.keyState.IsKeyDown(Keys.LeftAlt);

            if (shiftPressed)
            {
                short frameAdjustment = (short)(tile.TileFrameX >= 1260 ? -1260 : 252); //change first two by total size, last by style size

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
            if (altPressed)
            {
                if (tile.TileFrameX < 250)
                {
                    short frameAdjustment = (short)(tile.TileFrameX >= 216 ? -216 : 36); //change first two by total size, last by style size

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
                if (tile.TileFrameX > 250 && tile.TileFrameX <= 502)
                {
                    short frameAdjustment = (short)(tile.TileFrameX >= 468 ? -216 : 36); //change first two by total size, last by style size

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
                if (tile.TileFrameX > 502 && tile.TileFrameX <= 754)
                {
                    short frameAdjustment = (short)(tile.TileFrameX >= 720 ? -216 : 36); //change first two by total size, last by style size

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
                if (tile.TileFrameX > 754 && tile.TileFrameX <= 1006)
                {
                    short frameAdjustment = (short)(tile.TileFrameX >= 972 ? -216 : 36); //change first two by total size, last by style size

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
                if (tile.TileFrameX > 1006 && tile.TileFrameX <= 1258)
                {
                    short frameAdjustment = (short)(tile.TileFrameX >= 1224 ? -216 : 36); //change first two by total size, last by style size

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
                if (tile.TileFrameX > 1258)
                {
                    short frameAdjustment = (short)(tile.TileFrameX >= 1476 ? -216 : 36); //change first two by total size, last by style size

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
            }
        }
        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            int left = i;
            int top = j;
            if (tile.TileFrameX % 36 != 0)
            {
                left--;
            }

            if (tile.TileFrameY != 0)
            {
                top--;
            }

            int chest = Chest.FindChest(left, top);
            player.cursorItemIconID = -1;
            if (chest < 0)
            {
                player.cursorItemIconText = Language.GetTextValue("LegacyChestType.0");
            }
            else
            {
                string defaultName = TileLoader.DefaultContainerName(tile.TileType, tile.TileFrameX, tile.TileFrameY); // This gets the ContainerName text for the currently selected language
                player.cursorItemIconText = Main.chest[chest].name.Length > 0 ? Main.chest[chest].name : defaultName;
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
            MouseOver(i, j);
            Player player = Main.LocalPlayer;
            if (player.cursorItemIconText == "")
            {
                player.cursorItemIconEnabled = false;
                player.cursorItemIconID = 0;
            }
        }
    }
    public class Cupboards_Retro_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 6);
            Item.maxStack = Item.CommonMaxStack;

            Item.DefaultToPlaceableTile(ModContent.TileType<Counters_9_Retro>());
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 20)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }
}