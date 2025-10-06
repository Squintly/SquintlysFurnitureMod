//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using Terraria.Audio;
//using Terraria.DataStructures;
//using Terraria.Enums;
//using Terraria.GameContent;
//using Terraria.GameContent.Biomes.CaveHouse;
//using Terraria.GameContent.ObjectInteractions;
//using Terraria.ID;
//using Terraria.Localization;
//using Terraria.ModLoader.Core;
//using Terraria.ModLoader.IO;
//using Terraria.ObjectData;
//using static Terraria.GameContent.ItemDropRules.Conditions;
//using Terraria.ID;
//using Terraria.ObjectData;
//using Terraria;
//using Terraria.ModLoader;
//using Terraria.WorldBuilding;

//namespace SquintlysFurnitureMod.Content.Systems;
//public static class XOffset
//{
//    public static void SetXDrawPositions(int i, int j, ref int width, ref int offsetX, ref int height, ref short tileFrameX, ref short tileFrameY)
//    {
//        Tile tile = Main.tile[i, j];
//        if (tile.type >= TileID.Count)
//        {
//            TileObjectData tileData = TileObjectData.GetTileData(tile.type, 0, 0);
//            if (tileData != null)
//            {
//                int partX = 0;
//                for (int remainingFrameX = tile.frameX % tileData.CoordinateFullHeight; partX + 1 < tileData.Height && remainingFrameX - tileData.CoordinateHeights[partX] - tileData.CoordinatePadding >= 0; partX++)
//                {
//                    remainingFrameX -= tileData.CoordinateWidth[partX] + tileData.CoordinatePadding;
//                }
//                width = tileData.CoordinateWidth;
//                offsetX = tileData.DrawXOffset;
//                height = tileData.CoordinateHeights[partX];
//            }
//            GetTile(tile.type).SetDrawPositions(i, j, ref width, ref offsetX, ref height, ref tileFrameX, ref tileFrameY);
//        }
//    }
//}