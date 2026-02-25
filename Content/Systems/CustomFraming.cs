//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Terraria;
//using Terraria.ID;
//using Terraria.Map;
//using Terraria.ModLoader;
//using Terraria.ObjectData;
//using Terraria.Utilities;
//using Terraria.WorldBuilding;
//using System.Diagnostics;
//using System.Threading;
//using Microsoft.Xna.Framework;
//using ReLogic.Utilities;
//using Terraria.Audio;
//using Terraria.Chat;
//using Terraria.DataStructures;
//using Terraria.Enums;
//using Terraria.GameContent;
//using Terraria.GameContent.Achievements;
//using Terraria.GameContent.Biomes;
//using Terraria.GameContent.Creative;
//using Terraria.GameContent.Events;
//using Terraria.GameContent.Generation;
//using Terraria.GameContent.Tile_Entities;
//using Terraria.GameContent.UI.States;
//using Terraria.Graphics.Capture;
//using Terraria.IO;
//using Terraria.Localization;

//namespace SquintlysFurnitureMod.Content
//{
//    public class CustomFraming
//    {
//        public static bool UpdateMapTile(int i, int j, bool addToList = true)
//        {
//            bool result = false;
//            if (!Main.dedServ && Main.mapEnabled && !noMapUpdate && !gen && !Main.refreshMap && Main.Map[i, j].Light > 0 && Main.Map.UpdateType(i, j) && addToList)
//            {
//                result = true;
//                if (MapHelper.numUpdateTile < MapHelper.maxUpdateTile - 1)
//                {
//                    MapHelper.updateTileX[MapHelper.numUpdateTile] = (short)i;
//                    MapHelper.updateTileY[MapHelper.numUpdateTile] = (short)j;
//                    MapHelper.numUpdateTile++;
//                }
//                else
//                {
//                    Main.refreshMap = true;
//                }
//            }
//            return result;
//        }
//        private static bool mergeUp;

//        private static bool mergeDown;

//        private static bool mergeLeft;

//        private static bool mergeRight;
//        public static void TileMergeAttempt(int myType, bool[] lookfor, bool[] exclude, ref int up, ref int down, ref int left, ref int right, ref int upLeft, ref int upRight, ref int downLeft, ref int downRight)
//        {
//            if (up > -1 && !exclude[up] && lookfor[up])
//            {
//                up = myType;
//            }
//            if (down > -1 && !exclude[down] && lookfor[down])
//            {
//                down = myType;
//            }
//            if (left > -1 && !exclude[left] && lookfor[left])
//            {
//                left = myType;
//            }
//            if (right > -1 && !exclude[right] && lookfor[right])
//            {
//                right = myType;
//            }
//            if (upLeft > -1 && !exclude[upLeft] && lookfor[upLeft])
//            {
//                upLeft = myType;
//            }
//            if (upRight > -1 && !exclude[upRight] && lookfor[upRight])
//            {
//                upRight = myType;
//            }
//            if (downLeft > -1 && !exclude[downLeft] && lookfor[downLeft])
//            {
//                downLeft = myType;
//            }
//            if (downRight > -1 && !exclude[downRight] && lookfor[downRight])
//            {
//                downRight = myType;
//            }
//        }
//        public static void TileFrame(int i, int j, bool resetFrame = false, bool noBreak = false)
//        {
//            bool addToList = false;
//            try
//            {
//                if (i > 5 && j > 5 && i < Main.maxTilesX - 5 && j < Main.maxTilesY - 5 && Main.tile[i, j] != null)
//                {
//                    {
//                        addToList = UpdateMapTile(i, j);
//                        Tile tile = Main.tile[i, j];
//                        int num = tile.type;
//                        int frameX = tile.frameX;
//                        int frameY = tile.frameY;
//                            if (num < 255 || num > 268)
//                            {
//                                Tile tile2 = Main.tile[i, j - 1];
//                                Tile tile3 = Main.tile[i, j + 1];
//                                Tile tile4 = Main.tile[i - 1, j];
//                                Tile tile5 = Main.tile[i + 1, j];
//                                Tile tile6 = Main.tile[i - 1, j + 1];
//                                Tile tile7 = Main.tile[i + 1, j + 1];
//                                Tile tile8 = Main.tile[i - 1, j - 1];
//                                Tile tile9 = Main.tile[i + 1, j - 1];
//                                int upLeft = -1;
//                                int up = -1;
//                                int upRight = -1;
//                                int left = -1;
//                                int right = -1;
//                                int downLeft = -1;
//                                int down = -1;
//                                int downRight = -1;
//                                TileMergeAttempt(num, TileID.Sets.AllTiles, Main.tileNoAttach, ref up, ref down, ref left, ref right, ref upLeft, ref upRight, ref downLeft, ref downRight);
//                            Framing.SelfFrame8Way(i, j, tile, resetFrame);
//                            return;
//                        }
//                    }
//                }
//            }
//        }
//    }
//}