//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using ReLogic.Content;
//using SquintlysFurnitureMod.Content.Furniture.Kitchen.Appliances.Dishwashers;
//using SquintlysFurnitureMod.Content.Furniture.Kitchen.Appliances.KitchenSinks;
//using SquintlysFurnitureMod.Content.Furniture.Kitchen.Appliances.OvenHoods;
//using SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Counters.CountersNarrow;
//using SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Cupboards;
//using SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Cupboards.CupboardsNarrow;
//using System;
//using System.Collections.Generic;
//using Terraria;
//using Terraria.Audio;
//using Terraria.DataStructures;
//using Terraria.Enums;
//using Terraria.GameContent;
//using Terraria.GameContent.Drawing;
//using Terraria.GameContent.ObjectInteractions;
//using Terraria.ID;
//using Terraria.Localization;
//using Terraria.ModLoader;
//using Terraria.ObjectData;

//namespace SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Counters
//{
//    internal class Counters_9 : ModTile
//    {
//        private Asset<Texture2D> inBetween;

//        public enum StyleID
//        {
//            CountersModern, //0
//            CountersVintage, //1
//            CountersAntique, //2
//            CountersRetro //3
//        }

//        public override void SetStaticDefaults()
//        {
//            Main.tileFrameImportant[Type] = true;

//            Main.tileNoAttach[Type] = true;
//            Main.tileNoFail[Type] = false;

//            TileID.Sets.HasOutlines[Type] = true;
//            TileID.Sets.DisableSmartCursor[Type] = true;

//            Main.tileSpelunker[Type] = true;
//            Main.tileOreFinderPriority[Type] = 500;

//            Main.tileSolidTop[Type] = true;
//            Main.tileTable[Type] = true;

//            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

//            Main.tileContainer[Type] = true;
//            TileID.Sets.BasicChest[Type] = true;

//            TileID.Sets.IsAContainer[Type] = true;
//            TileID.Sets.FriendlyFairyCanLureTo[Type] = true;
//            TileID.Sets.GeneralPlacementTiles[Type] = false;

//            TileID.Sets.AvoidedByNPCs[Type] = true;
//            TileID.Sets.AvoidedByMeteorLanding[Type] = true;
//            TileID.Sets.InteractibleByNPCs[Type] = true;

//            TileID.Sets.DoesntGetReplacedWithTileReplacement[Type] = true; //Cludge to avoid figuring out custom replace logic

//            AdjTiles = new int[] { TileID.Containers };

//            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
//            TileObjectData.newTile.Origin = new Point16(0, 1);
//            TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };

//            TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
//            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);

//            TileObjectData.newTile.AnchorInvalidTiles = new int[]
//            {
//                    TileID.MagicalIceBlock,
//                    TileID.Boulder,
//                    TileID.BouncyBoulder,
//                    TileID.LifeCrystalBoulder,
//                    TileID.RollingCactus
//            };

//            TileObjectData.newTile.AnchorAlternateTiles = new int[]
//            {
//                ModContent.TileType<Counters_9>()
//            };

//            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);

//            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
//            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
//            TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
//            TileObjectData.addAlternate(0);

//            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
//            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
//            TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
//            TileObjectData.addAlternate(0);

//            TileObjectData.newTile.StyleHorizontal = true;
//            TileObjectData.newTile.RandomStyleRange = 9;
//            TileObjectData.newTile.StyleMultiplier = 9;

//            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

//            TileObjectData.addTile(Type);

//            AddMapEntry(new Color(200, 200, 200), this.GetLocalization("MapEntry0"), MapChestName);
//            AddMapEntry(new Color(200, 200, 200), this.GetLocalization("MapEntry1"), MapChestName);
//            AddMapEntry(new Color(200, 200, 200), this.GetLocalization("MapEntry2"), MapChestName);
//            AddMapEntry(new Color(200, 200, 200), this.GetLocalization("MapEntry3"), MapChestName);

//            AnimationFrameHeight = 36;
//            inBetween = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Furniture/Kitchen/Storage/Counters/Counters_InBetween");
//        }

//        public override ushort GetMapOption(int i, int j)
//        {
//            return (ushort)(Main.tile[i, j].TileFrameX / 324);
//        }

//        public override LocalizedText DefaultContainerName(int frameX, int frameY)
//        {
//            int option = frameX / 324;
//            return this.GetLocalization("MapEntry" + option);
//        }

//        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
//        {
//            return true;
//        }

//        public static string MapChestName(string name, int i, int j)
//        {
//            int left = i;
//            int top = j;
//            Tile tile = Main.tile[i, j];
//            if (tile.TileFrameX % 36 != 0)
//            {
//                left--;
//            }

//            if (tile.TileFrameY != 0)
//            {
//                top--;
//            }

//            int chest = Chest.FindChest(left, top);
//            if (chest < 0)
//            {
//                return Language.GetTextValue("LegacyChestType.0");
//            }

//            if (Main.chest[chest].name == "")
//            {
//                return name;
//            }

//            return name + ": " + Main.chest[chest].name;
//        }

//        public override void KillMultiTile(int i, int j, int frameX, int frameY)
//        {
//            Chest.DestroyChest(i, j);
//        }

//        public override bool RightClick(int i, int j)
//        {
//            Player player = Main.LocalPlayer;
//            Tile tile = Main.tile[i, j];

//            bool ctlPressed = Main.keyState.PressingControl();

//            if (ctlPressed)
//            {
//                SoundEngine.PlaySound(SoundID.Mech);
//                ToggleTile(i, j);
//                return true;
//            }

//            bool shiftPressed = Main.keyState.PressingShift();

//            if (shiftPressed)
//            {
//                SoundEngine.PlaySound(SoundID.Mech);
//                ToggleTile(i, j);
//                return true;
//            }
//            else
//            {
//                Main.mouseRightRelease = false;
//                int left = i;
//                int top = j;
//                if (tile.TileFrameX % 36 != 0)
//                {
//                    left--;
//                }

//                if (tile.TileFrameY != 0)
//                {
//                    top--;
//                }

//                player.CloseSign();
//                player.SetTalkNPC(-1);
//                Main.npcChatCornerItem = 0;
//                Main.npcChatText = "";
//                if (Main.editChest)
//                {
//                    SoundEngine.PlaySound(SoundID.MenuTick);
//                    Main.editChest = false;
//                    Main.npcChatText = string.Empty;
//                }

//                if (player.editedChestName)
//                {
//                    NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
//                    player.editedChestName = false;
//                }

//                int chest = Chest.FindChest(left, top);
//                if (chest != -1)
//                {
//                    Main.stackSplit = 600;
//                    if (chest == player.chest)
//                    {
//                        player.chest = -1;
//                        SoundEngine.PlaySound(SoundID.MenuClose);
//                    }
//                    else
//                    {
//                        SoundEngine.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);
//                        player.OpenChest(left, top, chest);
//                    }

//                    Recipe.FindRecipes();
//                }
//                return true;
//            }
//        }

//        public void ToggleTile(int i, int j)
//        {
//            Tile tile = Main.tile[i, j];
//            int topX = i - tile.TileFrameX % 36 / 16; //change first number depending on size
//            int topY = j - tile.TileFrameY % 36 / 16;

//            bool shiftPressed = Main.keyState.PressingShift();

//            if (shiftPressed)
//            {
//                if (tile.TileFrameX <= 322)
//                {
//                    short frameAdjustment = (short)(tile.TileFrameX >= 288 ? -288 : 36); //change first two by total size, last by style size

//                    for (int x = topX; x < topX + 2; x++) // change depending on width
//                    {
//                        for (int y = topY; y < topY + 2; y++) // change height
//                        {
//                            Main.tile[x, y].TileFrameX += frameAdjustment;

//                            if (Wiring.running)
//                            {
//                                Wiring.SkipWire(x, y);
//                            }
//                        }
//                    }
//                }
//                if (tile.TileFrameX >= 324 && tile.TileFrameX <= 646)
//                {
//                    short frameAdjustment = (short)(tile.TileFrameX >= 612 ? -288 : 36); //change first two by total size, last by style size

//                    for (int x = topX; x < topX + 2; x++) // change depending on width
//                    {
//                        for (int y = topY; y < topY + 2; y++) // change height
//                        {
//                            Main.tile[x, y].TileFrameX += frameAdjustment;

//                            if (Wiring.running)
//                            {
//                                Wiring.SkipWire(x, y);
//                            }
//                        }
//                    }
//                }
//                if (tile.TileFrameX >= 648 && tile.TileFrameX <= 970)
//                {
//                    short frameAdjustment = (short)(tile.TileFrameX >= 936 ? -288 : 36); //change first two by total size, last by style size

//                    for (int x = topX; x < topX + 2; x++) // change depending on width
//                    {
//                        for (int y = topY; y < topY + 2; y++) // change height
//                        {
//                            Main.tile[x, y].TileFrameX += frameAdjustment;

//                            if (Wiring.running)
//                            {
//                                Wiring.SkipWire(x, y);
//                            }
//                        }
//                    }
//                }
//                if (tile.TileFrameX >= 972)
//                {
//                    short frameAdjustment = (short)(tile.TileFrameX >= 1260 ? -288 : 36); //change first two by total size, last by style size

//                    for (int x = topX; x < topX + 2; x++) // change depending on width
//                    {
//                        for (int y = topY; y < topY + 2; y++) // change height
//                        {
//                            Main.tile[x, y].TileFrameX += frameAdjustment;

//                            if (Wiring.running)
//                            {
//                                Wiring.SkipWire(x, y);
//                            }
//                        }
//                    }
//                }
//            }

//            bool ctlPressed = Main.keyState.PressingControl();
//            if (ctlPressed)
//            {
//                short frameAdjustment = (short)(tile.TileFrameY >= 288 ? -288 : 36); //change first two by total size, last by style size

//                    for (int x = topX; x < topX + 2; x++) // change depending on width
//                    {
//                        for (int y = topY; y < topY + 2; y++) // change height
//                        {
//                            Main.tile[x, y].TileFrameX += frameAdjustment;

//                            if (Wiring.running)
//                            {
//                                Wiring.SkipWire(x, y);
//                            }
//                        }
//                    }
//            }
//        }
//        public override void MouseOver(int i, int j)
//        {
//            Player player = Main.LocalPlayer;
//            Tile tile = Main.tile[i, j];
//            int left = i;
//            int top = j;
//            if (tile.TileFrameX % 36 != 0)
//            {
//                left--;
//            }

//            if (tile.TileFrameY != 0)
//            {
//                top--;
//            }

//            int chest = Chest.FindChest(left, top);
//            player.cursorItemIconID = -1;
//            if (chest < 0)
//            {
//                player.cursorItemIconText = Language.GetTextValue("LegacyChestType.0");
//            }
//            else
//            {
//                string defaultName = TileLoader.DefaultContainerName(tile.TileType, tile.TileFrameX, tile.TileFrameY); // This gets the ContainerName text for the currently selected language
//                player.cursorItemIconText = Main.chest[chest].name.Length > 0 ? Main.chest[chest].name : defaultName;
//                if (player.cursorItemIconText == defaultName)
//                {
//                    int style = TileObjectData.GetTileStyle(Main.tile[i, j]);
//                    player.cursorItemIconID = TileLoader.GetItemDropFromTypeAndStyle(Type, style);

//                    player.cursorItemIconText = "";
//                }
//            }

//            player.noThrow = 2;
//            player.cursorItemIconEnabled = true;
//        }

//        public override void MouseOverFar(int i, int j)
//        {
//            MouseOver(i, j);
//            Player player = Main.LocalPlayer;
//            if (player.cursorItemIconText == "")
//            {
//                player.cursorItemIconEnabled = false;
//                player.cursorItemIconID = 0;
//            }
//        }

////        private static void GetAnchors(int i, int j, out bool left, out bool right)
////        {
////            Tile tile = Main.tile[i - 1, j];
////            left = ValidAnchor(tile);

////            tile = Main.tile[i + 2, j];
////            right = ValidAnchor(tile);

////            static bool ValidAnchor(Tile tile)
////            {
////                const AnchorType Anchors = AnchorType.SolidTile | AnchorType.SolidSide;
////                return WorldGen.AnchorValid(tile, Anchors) || ModContent.GetModTile(tile.TileType) is Counters_9;
////            }
////        }

////        // Solution 3 -- not paintable
////        //public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
////        //{
////        //    Tile tile = Main.tile[i, j];
////        //    GetAnchors(i, j, out bool left, out bool right);

////        //    Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

////        //    int height = tile.TileFrameY % AnimationFrameHeight == 36 ? 18 : 16;
////        //    int frameYOffset = 0;

////        //    if (left && right)
////        //        frameYOffset = 190;

////        //    else if (left && !right)
////        //        frameYOffset = 152;

////        //    else if (right && !left)
////        //        frameYOffset = 114;

////        //    spriteBatch.Draw(
////        //        TextureAssets.Tile[Type].Value,
////        //        new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
////        //        new Rectangle(tile.TileFrameX, tile.TileFrameY + frameYOffset, 16, height),
////        //        Lighting.GetColor(i,j), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

////        //    return false;
////        //}

////        // Solution 2 - doesn't work for chests
////        //public override void AnimateTile(ref int frame, ref int frameCounter) {
////        //	//if (++frameCounter >= 4) {
////        //	//	frameCounter = 0;
////        //	//	// We animate through the 1st 8 frames. The 9th frame is manually drawn if in the "off" state so it is not included in the animation logic here.
////        //	//	frame = ++frame % 8;
////        //	//}
////        //}
////        //public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset) 
////        //      {
////        //          GetAnchors(i, j, out bool left, out bool right);
////        //          Tile tile = Main.tile[i, j];
////        //          int offsetX = tile.TileFrameY % 36 / 18;

////        //          if (left && right)
////        //              frameYOffset = 190;

////        //          else if (left && !right)
////        //              frameYOffset = 152;

////        //          else if (right && !left)
////        //              frameYOffset = 114;
////        //          else
////        //              frameYOffset = 0;
////        //}

////        // Solution 1 - works but can't be painted
////        //public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
////        //{
////        //    Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
////        //    bool draw = false;
////        //    int x, offsetX, y, offsetY;
////        //    offsetX = offsetY = x = y = 0;
////        //    int frameX = (Main.tile[i, j].TileFrameX % 36);
////        //    int frameY = (Main.tile[i, j].TileFrameY);

////        //    List<int> countersMergeWith = new List<int>(new int[3]
////        //    {
////        //            ModContent.TileType<Dishwashers_3>(),
////        //            ModContent.TileType<KitchenSinks_3>(),
////        //            ModContent.TileType<Counters_Narrow_6>(),
////        //    });
////        //    if (frameX == 0)
////        //    {
////        //        Tile tile = Main.tile[i - ((frameX == 0) ? 1 : 2), j];
////        //        if (!TileDrawing.IsVisible(tile))
////        //        {
////        //            return;
////        //        }
////        //        Tile val = ((Tilemap)Main.tile)[i - 1, j];
////        //        int type = val.TileType;

////        //        //Merge Counters
////        //        if (type == Type)
////        //        {
////        //            //Modern
////        //            if ((Main.tile[i, j].TileFrameX < 106) && (val.TileFrameX < 106))
////        //            {
////        //                draw = true;
////        //                x = 0;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 106 && Main.tile[i, j].TileFrameX <= 214) &&
////        //            (val.TileFrameX >= 106 && val.TileFrameX <= 214))
////        //            {
////        //                draw = true;
////        //                x = 12;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 216 && Main.tile[i, j].TileFrameX <= 322) &&
////        //            (val.TileFrameX >= 216 && val.TileFrameX <= 322))
////        //            {
////        //                draw = true;
////        //                x = 24;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            //Vintage
////        //            if ((Main.tile[i, j].TileFrameX >= 324 && Main.tile[i, j].TileFrameX <= 430) &&
////        //            (val.TileFrameX >= 324 && val.TileFrameX <= 430))
////        //            {
////        //                draw = true;
////        //                x = 36;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 432 && Main.tile[i, j].TileFrameX <= 538) &&
////        //            (val.TileFrameX >= 432 && val.TileFrameX <= 538))
////        //            {
////        //                draw = true;
////        //                x = 48;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 540 && Main.tile[i, j].TileFrameX <= 646) &&
////        //            (val.TileFrameX >= 540 && val.TileFrameX <= 646))
////        //            {
////        //                draw = true;
////        //                x = 60;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            // Antique
////        //            if ((Main.tile[i, j].TileFrameX >= 648 && Main.tile[i, j].TileFrameX <= 754) &&
////        //            (val.TileFrameX >= 648 && val.TileFrameX <= 754))
////        //            {
////        //                draw = true;
////        //                x = 72;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 756 && Main.tile[i, j].TileFrameX <= 862) &&
////        //            (val.TileFrameX >= 756 && val.TileFrameX <= 862))
////        //            {
////        //                draw = true;
////        //                x = 84;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 864 && Main.tile[i, j].TileFrameX <= 970) &&
////        //            (val.TileFrameX >= 864 && val.TileFrameX <= 970))
////        //            {
////        //                draw = true;
////        //                x = 96;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            // Retro
////        //            if ((Main.tile[i, j].TileFrameX >= 972 && Main.tile[i, j].TileFrameX <= 1078) &&
////        //            (val.TileFrameX >= 972 && val.TileFrameX <= 1078))
////        //            {
////        //                draw = true;
////        //                x = 108;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 1080 && Main.tile[i, j].TileFrameX <= 1186) &&
////        //            (val.TileFrameX >= 1080 && val.TileFrameX <= 1186))
////        //            {
////        //                draw = true;
////        //                x = 120;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 1188) &&
////        //            (val.TileFrameX >= 1188))
////        //            {
////        //                draw = true;
////        //                x = 132;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //        }
////        //        //Merge Other
////        //        if (countersMergeWith.Contains(type))
////        //        {
////        //            //Modern
////        //            if ((Main.tile[i, j].TileFrameX < 106) && (val.TileFrameX < 34))
////        //            {
////        //                draw = true;
////        //                x = 0;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 106 && Main.tile[i, j].TileFrameX <= 214) &&
////        //            (val.TileFrameX >= 36 && val.TileFrameX <= 70))
////        //            {
////        //                draw = true;
////        //                x = 12;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 216 && Main.tile[i, j].TileFrameX <= 322) &&
////        //            (val.TileFrameX >= 72 && val.TileFrameX <= 106))
////        //            {
////        //                draw = true;
////        //                x = 24;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            //Vintage
////        //            if ((Main.tile[i, j].TileFrameX >= 324 && Main.tile[i, j].TileFrameX <= 430) &&
////        //            (val.TileFrameX >= 108 && val.TileFrameX <= 142))
////        //            {
////        //                draw = true;
////        //                x = 36;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 432 && Main.tile[i, j].TileFrameX <= 538) &&
////        //            (val.TileFrameX >= 144 && val.TileFrameX <= 178))
////        //            {
////        //                draw = true;
////        //                x = 48;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 540 && Main.tile[i, j].TileFrameX <= 646) &&
////        //            (val.TileFrameX >= 180 && val.TileFrameX <= 214))
////        //            {
////        //                draw = true;
////        //                x = 60;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            // Antique
////        //            if ((Main.tile[i, j].TileFrameX >= 648 && Main.tile[i, j].TileFrameX <= 754) &&
////        //            (val.TileFrameX >= 216 && val.TileFrameX <= 250))
////        //            {
////        //                draw = true;
////        //                x = 72;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 756 && Main.tile[i, j].TileFrameX <= 862) &&
////        //            (val.TileFrameX >= 252 && val.TileFrameX <= 286))
////        //            {
////        //                draw = true;
////        //                x = 84;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 864 && Main.tile[i, j].TileFrameX <= 970) &&
////        //            (val.TileFrameX >= 288 && val.TileFrameX <= 322))
////        //            {
////        //                draw = true;
////        //                x = 96;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            // Retro
////        //            if ((Main.tile[i, j].TileFrameX >= 972 && Main.tile[i, j].TileFrameX <= 1078) &&
////        //            (val.TileFrameX >= 324 && val.TileFrameX <= 358))
////        //            {
////        //                draw = true;
////        //                x = 108;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 1080 && Main.tile[i, j].TileFrameX <= 1186) &&
////        //            (val.TileFrameX >= 360 && val.TileFrameX <= 394))
////        //            {
////        //                draw = true;
////        //                x = 120;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //            if ((Main.tile[i, j].TileFrameX >= 1188) &&
////        //            (val.TileFrameX >= 396))
////        //            {
////        //                draw = true;
////        //                x = 132;
////        //                offsetX = -6;
////        //                y = frameY;
////        //                offsetY = 0;
////        //            }
////        //        }
////        //    }

////        //    if (draw)
////        //    {
////        //        spriteBatch.Draw(
////        //        inBetween.Value,
////        //        new Vector2((i * 16 + offsetX - (int)Main.screenPosition.X), (j * 16f - offsetY - (int)Main.screenPosition.Y)) + zero,
////        //        (Rectangle?)new Rectangle(x, y, 12, 34),
////        //        Lighting.GetColor(i, j), 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
////        //    }
////        //}
////    }
////}