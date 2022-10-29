using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Tattered;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered
{
    public class TatteredDresserTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[base.Type] = true;
            Main.tileFrameImportant[base.Type] = true;
            Main.tileNoAttach[base.Type] = true;
            Main.tileTable[base.Type] = true;
            Main.tileContainer[base.Type] = true;
            Main.tileLavaDeath[base.Type] = true;
            TileID.Sets.HasOutlines[base.Type] = true;
            TileID.Sets.DisableSmartCursor[base.Type] = true;
            TileID.Sets.BasicDresser[base.Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
            TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, processedCoordinates: true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, processedCoordinates: false);
            TileObjectData.newTile.AnchorInvalidTiles = new int[1] { 127 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(base.Type);
            base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            ModTranslation name = base.CreateMapEntryName();
            name.SetDefault("Tattered Dresser");
            base.AddMapEntry(new Color(100, 100, 100), name);
            base.ContainerName.SetDefault("Tattered Dresser");
            base.AdjTiles = new int[1] { 88 };
            base.DresserDrop = ModContent.ItemType<TatteredDresserItem>();
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return true;
        }

        public override bool RightClick(int i, int j)
        {
            //IL_00b0: Unknown result type (might be due to invalid IL or missing references)
            //IL_00e9: Unknown result type (might be due to invalid IL or missing references)
            //IL_01a2: Unknown result type (might be due to invalid IL or missing references)
            //IL_0246: Unknown result type (might be due to invalid IL or missing references)
            //IL_0292: Unknown result type (might be due to invalid IL or missing references)
            //IL_02ce: Unknown result type (might be due to invalid IL or missing references)
            Player player = Main.LocalPlayer;
            if (Main.tile[Player.tileTargetX, Player.tileTargetY].TileFrameY == 0)
            {
                Main.CancelClothesWindow(quiet: true);
                Main.mouseRightRelease = false;
                int left = Main.tile[Player.tileTargetX, Player.tileTargetY].TileFrameX / 18;
                left %= 3;
                left = Player.tileTargetX - left;
                int top = Player.tileTargetY - Main.tile[Player.tileTargetX, Player.tileTargetY].TileFrameY / 18;
                if (player.sign > -1)
                {
                    SoundEngine.PlaySound(in SoundID.MenuClose);
                    player.sign = -1;
                    Main.editSign = false;
                    Main.npcChatText = string.Empty;
                }
                if (Main.editChest)
                {
                    SoundEngine.PlaySound(in SoundID.MenuTick);
                    Main.editChest = false;
                    Main.npcChatText = string.Empty;
                }
                if (player.editedChestName)
                {
                    NetMessage.SendData(33, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
                    player.editedChestName = false;
                }
                if (Main.netMode == 1)
                {
                    if (left == player.chestX && top == player.chestY && player.chest != -1)
                    {
                        player.chest = -1;
                        Recipe.FindRecipes();
                        SoundEngine.PlaySound(in SoundID.MenuClose);
                    }
                    else
                    {
                        NetMessage.SendData(31, -1, -1, null, left, top);
                        Main.stackSplit = 600;
                    }
                }
                else
                {
                    player.piggyBankProjTracker.Clear();
                    player.voidLensChest.Clear();
                    int num213 = Chest.FindChest(left, top);
                    if (num213 != -1)
                    {
                        Main.stackSplit = 600;
                        if (num213 == player.chest)
                        {
                            player.chest = -1;
                            Recipe.FindRecipes();
                            SoundEngine.PlaySound(in SoundID.MenuClose);
                        }
                        else if (num213 != player.chest && player.chest == -1)
                        {
                            player.chest = num213;
                            Main.playerInventory = true;
                            Main.recBigList = false;
                            SoundEngine.PlaySound(in SoundID.MenuOpen);
                            player.chestX = left;
                            player.chestY = top;
                        }
                        else
                        {
                            player.chest = num213;
                            Main.playerInventory = true;
                            Main.recBigList = false;
                            SoundEngine.PlaySound(in SoundID.MenuTick);
                            player.chestX = left;
                            player.chestY = top;
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
                Main.interactedDresserTopLeftX = Player.tileTargetX;
                Main.interactedDresserTopLeftY = Player.tileTargetY;
                Main.OpenClothesWindow();
            }
            return true;
        }

        public override void MouseOverFar(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
            int left = Player.tileTargetX;
            int top = Player.tileTargetY;
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
                if (Main.chest[chestIndex].name != "")
                {
                    player.cursorItemIconText = Main.chest[chestIndex].name;
                }
                else
                {
                    player.cursorItemIconText = "Tattered Dresser";
                }
                if (player.cursorItemIconText == "Tattered Dresser")
                {
                    player.cursorItemIconID = ModContent.ItemType<TatteredDresserItem>();
                    player.cursorItemIconText = "";
                }
            }
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            if (player.cursorItemIconText == "")
            {
                player.cursorItemIconEnabled = false;
                player.cursorItemIconID = 0;
            }
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
            int left = Player.tileTargetX;
            int top = Player.tileTargetY;
            left -= tile.TileFrameX % 54 / 18;
            if (tile.TileFrameY % 36 != 0)
            {
                top--;
            }
            int num138 = Chest.FindChest(left, top);
            player.cursorItemIconID = -1;
            if (num138 < 0)
            {
                player.cursorItemIconText = Language.GetTextValue("LegacyDresserType.0");
            }
            else
            {
                if (Main.chest[num138].name != "")
                {
                    player.cursorItemIconText = Main.chest[num138].name;
                }
                else
                {
                    player.cursorItemIconText = "Tattered Dresser";
                }
                if (player.cursorItemIconText == "Tattered Dresser")
                {
                    player.cursorItemIconID = ModContent.ItemType<TatteredDresserItem>();
                    player.cursorItemIconText = "";
                }
            }
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            if (Main.tile[Player.tileTargetX, Player.tileTargetY].TileFrameY > 0)
            {
                player.cursorItemIconID = 269;
            }
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = (fail ? 1 : 3);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, base.DresserDrop);
            Chest.DestroyChest(i, j);
        }

        private readonly int animationFrameWidth = 54;
        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
        {
            // Tweak the frame drawn by x position so tiles next to each other are off-sync and look much more interesting
            int uniqueAnimationFrame = Main.tileFrame[Type] + i;
            if (i % 2 == 0)
                uniqueAnimationFrame += 1;
            if (i % 3 == 0)
                uniqueAnimationFrame += 1;
            if (i % 4 == 0)
                uniqueAnimationFrame += 1;
            uniqueAnimationFrame %= 2;

            // frameYOffset = modTile.animationFrameHeight * Main.tileFrame [type] will already be set before this hook is called
            // But we have a horizontal animated texture, so we use frameXOffset instead of frameYOffset
            frameYOffset = uniqueAnimationFrame * AnimationFrameHeight;
        }
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            // Spend 9 ticks on each of 6 frames, looping
            frameCounter++;
            if (frameCounter >= 3)
            {
                frameCounter = 0;
                if (++frame >= 2)
                {
                    frame = 0;
                }
            }
        }
    }
}

