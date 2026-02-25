//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using Terraria;
//using Terraria.Audio;
//using Terraria.DataStructures;
//using Terraria.Enums;
//using Terraria.GameContent;
//using Terraria.GameContent.Biomes.CaveHouse;
//using Terraria.GameContent.ObjectInteractions;
//using Terraria.ID;
//using Terraria.Localization;
//using Terraria.ModLoader;
//using Terraria.ModLoader.Core;
//using Terraria.ModLoader.IO;
//using Terraria.ObjectData;
//using Terraria.WorldBuilding;

//namespace SquintlysFurnitureMod.Content.Abstracts.Blocks;

//public static class TallDoorsOpen
//{
//    private static int nextTile = TileID.Count;
//    public static int TileCount => nextTile;
//    internal static readonly IList<ModTile> tiles = new List<ModTile>();
//    internal static readonly IList<GlobalTile> globalTiles = new List<GlobalTile>();
//    public static ModTile GetTile(int type)
//    {
//        return type >= TileID.Count && type < TileCount ? tiles[type - TileID.Count] : null;
//    }
//    public static int TallOpenDoorID(Tile tile)
//    {
//        ModTile modTile = GetTile(tile.type);
//        if (modTile != null)
//        {
//            return TileID.Sets.TallOpenDoorID[modTile.Type];
//        }
//        if (tile.type == TileID.TallClosedDoor && (tile.frameY < 594 || tile.frameY > 646 || tile.frameX >= 54))
//        {
//            return TileID.TallOpenDoor;
//        }
//        return -1;
//    }
//    public static int TallCloseDoorID(Tile tile)
//    {
//        ModTile modTile = GetTile(tile.type);

//        if (modTile != null)
//        {
//            return TileID.Sets.TallCloseDoorID[modTile.Type];
//        }

//        if (tile.type == TileID.OpenDoor)
//        {
//            return TileID.ClosedDoor;
//        }

//        return -1;
//    }
//    public static bool IsTallClosedDoor(Tile tile) => IsTallClosedDoor(tile.type);

//    public static bool IsTallClosedDoor(int type)
//    {
//        ModTile modTile = GetTile(type);

//        if (modTile != null)
//        {
//            return TileID.Sets.OpenTallDoorID[type] > -1;
//        }

//        return type == TileID.TallClosedDoor;
//    }

//}

////public static class TallDoors
////{
////    private static int nextTile = TileID.Count;
////    internal static readonly IList<ModTile> tiles = new List<ModTile>();
////    internal static readonly IList<GlobalTile> globalTiles = new List<GlobalTile>();
////    internal static readonly Dictionary<(int, int), int> tileTypeAndTileStyleToItemType = new();
////    private static bool loaded = false;
////    private static readonly int vanillaDoorCount = TileID.Sets.RoomNeeds.CountsAsDoor.Length;

////    public static int TileCount => nextTile;

////    public static ModTile GetTile(int type)
////    {
////        return type >= TileID.Count && type < TileCount ? tiles[type - TileID.Count] : null;
////    }
////    public static void CheckModTile(int i, int j, int type)
////    {
////        if (type <= TileID.Count)
////        {
////            return;
////        }
////        if (WorldGen.destroyObject)
////        {
////            return;
////        }
////        TileObjectData tileData = TileObjectData.GetTileData(type, 0, 0);
////        if (tileData == null)
////        {
////            return;
////        }
////        int frameX = Main.tile[i, j].frameX;
////        int frameY = Main.tile[i, j].frameY;
////        int subX = frameX / tileData.CoordinateFullWidth;
////        int subY = frameY / tileData.CoordinateFullHeight;
////        int wrap = tileData.StyleWrapLimit;
////        if (wrap == 0)
////        {
////            wrap = 1;
////        }
////        int styleLineSkip = tileData.StyleLineSkip;
////        int subTile = tileData.StyleHorizontal ? subY / styleLineSkip * wrap + subX : subX / styleLineSkip * wrap + subY;
////        int style = subTile / tileData.StyleMultiplier;
////        /*
////		int alternate = subTile % tileData.StyleMultiplier;
////		for (int k = 0; k < tileData.AlternatesCount; k++) {
////			if (alternate >= tileData.Alternates[k].Style && alternate <= tileData.Alternates[k].Style + tileData.RandomStyleRange) {
////				alternate = k;
////				break;
////			}
////		}
////		*/
////        tileData = TileObjectData.GetTileData(Main.tile[i, j]);
////        int partFrameX = frameX % tileData.CoordinateFullWidth;
////        int partFrameY = frameY % tileData.CoordinateFullHeight;
////        int partX = partFrameX / (tileData.CoordinateWidth + tileData.CoordinatePadding);
////        int partY = 0;
////        for (int remainingFrameY = partFrameY; partY + 1 < tileData.Height && remainingFrameY - tileData.CoordinateHeights[partY] - tileData.CoordinatePadding >= 0; partY++)
////        {
////            remainingFrameY -= tileData.CoordinateHeights[partY] + tileData.CoordinatePadding;
////        }
////        // We need to use the tile that trigger this, since it still has the tile type instead of air
////        int originalI = i;
////        int originalJ = j;
////        i -= partX;
////        j -= partY;
////        int originX = i + tileData.Origin.X;
////        int originY = j + tileData.Origin.Y;
////        bool partiallyDestroyed = false;
////        for (int x = i; x < i + tileData.Width; x++)
////        {
////            for (int y = j; y < j + tileData.Height; y++)
////            {
////                if (!Main.tile[x, y].active() || Main.tile[x, y].type != type)
////                {
////                    partiallyDestroyed = true;
////                    break;
////                }
////            }
////            if (partiallyDestroyed)
////            {
////                break;
////            }
////        }
////        // TODO: Placed modded tiles can't automatically reorient themselves to an alternate placement, like Torch and Sign do.
////        if (partiallyDestroyed || !TileObject.CanPlace(originX, originY, type, style, 0, out TileObject objectData, onlyCheck: true, checkStay: true))
////        {
////            WorldGen.destroyObject = true;
////            // First the Items to drop are tallied and spawned, then Kill each tile, then KillMultiTile can clean up TileEntities or Chests
////            // KillTile will handle calling DropItems for 1x1 tiles.
////            if (tileData.Width != 1 || tileData.Height != 1)
////                WorldGen.KillTile_DropItems(originalI, originalJ, Main.tile[originalI, originalJ], includeLargeObjectDrops: true, includeAllModdedLargeObjectDrops: true); // include all drops.
////            for (int x = i; x < i + tileData.Width; x++)
////            {
////                for (int y = j; y < j + tileData.Height; y++)
////                {
////                    if (Main.tile[x, y].type == type && Main.tile[x, y].active())
////                    {
////                        WorldGen.KillTile(x, y, false, false, false);
////                    }
////                }
////            }
////            KillMultiTile(i, j, frameX - partFrameX, frameY - partFrameY, type);
////            WorldGen.destroyObject = false;
////            for (int x = i - 1; x < i + tileData.Width + 2; x++)
////            {
////                for (int y = j - 1; y < j + tileData.Height + 2; y++)
////                {
////                    WorldGen.TileFrame(x, y, false, false);
////                }
////            }
////        }
////        TileObject.objectPreview.Active = false;
////    }
////    public static int OpenDoorID(Tile tile)
////    {
////        ModTile modTile = GetTile(tile.type);
////        if (modTile != null)
////        {
////            return TileID.Sets.OpenDoorID[modTile.Type];
////        }
////        if (tile.type == TileID.ClosedDoor && (tile.frameY < 594 || tile.frameY > 646 || tile.frameX >= 54))
////        {
////            return TileID.OpenDoor;
////        }
////        return -1;
////    }
////    public static int CloseDoorID(Tile tile)
////    {
////        ModTile modTile = GetTile(tile.type);

////        if (modTile != null)
////        {
////            return TileID.Sets.CloseDoorID[modTile.Type];
////        }

////        if (tile.type == TileID.OpenDoor)
////        {
////            return TileID.ClosedDoor;
////        }

////        return -1;
////    }

////    /// <inheritdoc cref="IsClosedDoor(int)"/>
////    public static bool IsClosedDoor(Tile tile) => IsClosedDoor(tile.type);

////    /// <summary>
////    /// Returns true if the tile is a vanilla or modded closed door.
////    /// </summary>
////    public static bool IsClosedDoor(int type)
////    {
////        ModTile modTile = GetTile(type);

////        if (modTile != null)
////        {
////            return TileID.Sets.OpenDoorID[type] > -1;
////        }

////        return type == TileID.ClosedDoor;
////    }
////}