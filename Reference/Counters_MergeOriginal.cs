//using Microsoft.CodeAnalysis;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using ReLogic.Content;
//using SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Counters;
//using SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Counters.Items;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.IO;
//using System.Linq;
//using Terraria;
//using Terraria.Audio;
//using Terraria.DataStructures;
//using Terraria.Enums;
//using Terraria.GameContent.Drawing;
//using Terraria.GameContent.ObjectInteractions;
//using Terraria.ID;
//using Terraria.Localization;
//using Terraria.ModLoader;
//using Terraria.ModLoader.IO;
//using Terraria.ObjectData;
//using static SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Counters.Counters_Merge;
//using static Terraria.ModLoader.PlayerDrawLayer;

//namespace SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Counters
//#nullable enable
//{

//public class Counters_9_Entity : ModTileEntity
//    {
//        public override bool IsTileValidForEntity(int x, int y)
//        {
//            Tile tile = Main.tile[x, y];
//            return tile.HasTile && tile.TileType == ModContent.TileType<Counters_9>();
//        }
//        private static void GetAnchors(int i, int j, out bool left, out bool right)
//        {
//            Tile tile = Main.tile[i - 1, j];
//            left = ValidAnchor(tile);

//            tile = Main.tile[i + 2, j];
//            right = ValidAnchor(tile);

//            static bool ValidAnchor(Tile tile)
//            {
//                const AnchorType Anchors = AnchorType.SolidTile | AnchorType.SolidSide;
//                return WorldGen.AnchorValid(tile, Anchors) || ModContent.GetModTile(tile.TileType) is Counters_9;
//            }
//        }
//        private int mergeState;
//        public int MergeState
//        {
//            get { return mergeState; }
//            set
//            {
//                GetAnchors(i, j, out bool left, out bool right);

//                if (left && right)
//                {
//                    mergeState = 3;
//                }
//                else if (left && !right)
//                {
//                    mergeState = 2;
//                }
//                else if (!left && right)
//                {
//                    mergeState = 1;
//                }
//                else
//                    mergeState = 0;

//                if (Main.netMode == NetmodeID.Server)
//                {
//                    NetMessage.SendData(MessageID.TileEntitySharing, number: ID);
//                }
//            }
//        }

//        public override void SaveData(TagCompound tag) => tag[nameof(MergeState)] = MergeState;
//        public override void LoadData(TagCompound tag) => MergeState = tag.GetInt(nameof(MergeState));
//        public override void NetSend(BinaryWriter writer) => writer.Write(MergeState);
//        public override void NetReceive(BinaryReader reader) => MergeState = reader.ReadInt32();
//    }

//    internal abstract class Counters_Merge : ModTile
//    {
//        internal class CountersMergeSetup : ModSystem
//        {
//            public override void PostSetupContent()
//            {
//                var counters = ModContent.GetContent<Counters_Merge>();
//                int[] types = [.. counters.Select(x => x.Type)];
//                int[] bases = [.. CounterBase.Bases];

//                foreach (var counter in counters)
//                {
//                    TileObjectData.GetTileData(counter.Type, 0).AnchorAlternateTiles = bases;

//                    for (int i = 0; i < 3; ++i)
//                    {
//                        TileObjectData.GetTileData(counter.Type, 0, i + 1).AnchorAlternateTiles = types;
//                    }

//                }
//            }
//        }
//        internal class Counters_Merge_Entity : ModTileEntity
//        {
//            public override bool IsTileValidForEntity(int x, int y)
//            {
//                Tile tile = Main.tile[x, y];
//                return tile.HasTile && tile.TileType == ModContent.TileType<CounterBase>();
//            }

//            public override void SaveData(TagCompound tag)
//            {
//            }

//            public override void LoadData(TagCompound tag)
//            {
//            }

//            public override void NetSend(BinaryWriter writer)
//            {
//            }

//            public override void NetReceive(BinaryReader reader)
//            {
//            }

//            public override void Update()
//            {
//            }
//        }
//        private static bool BlockRecursion = false;
//        private static int KillOrderInvalidX = 0;
//        private static int KillOrderInvalidXMax = 0;
//        public override void SetStaticDefaults()
//        {
//            Main.tileFrameImportant[Type] = true;

//            Main.tileNoAttach[Type] = true;
//            Main.tileNoFail[Type] = false;

//            TileID.Sets.HasOutlines[Type] = true;
//            TileID.Sets.DisableSmartCursor[Type] = true;

//            Main.tileSolidTop[Type] = true;
//            Main.tileTable[Type] = true;

//            ref TileObjectData tile = ref TileObjectData.newTile;

//            tile.CopyFrom(TileObjectData.Style2x2);
//            tile.Origin = new Point16(0, 1);
//            tile.CoordinateHeights = new[] { 16, 18 };

//            tile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.AlternateTile, 2, 1);

//            tile.StyleHorizontal = true;
//            //TileObjectData.newTile.RandomStyleRange = 9;
//            //TileObjectData.newTile.StyleMultiplier = 9;

//            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

//            ref TileObjectData alternate = ref TileObjectData.newAlternate;

//            alternate.CopyFrom(TileObjectData.newTile);
//            alternate.AnchorBottom = AnchorData.Empty;
//            alternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.AlternateTile, 2, 0);
//            TileObjectData.addAlternate(0);

//            alternate.CopyFrom(TileObjectData.newTile);
//            alternate.AnchorBottom = AnchorData.Empty;
//            alternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.AlternateTile, 2, 0);
//            TileObjectData.addAlternate(0);

//            TileObjectData.addTile(Type);

//        }

//        private static void GetAnchors(int i, int j, out bool left, out bool right, out bool leftbottom, out bool rightbottom /*out bool bottom*/)
//        {
//            Tile tile = Main.tile[i - 1, j];
//            left = ValidAnchor(tile);

//            tile = Main.tile[i + 2, j];
//            right = ValidAnchor(tile) && (i < KillOrderInvalidX || i >= KillOrderInvalidXMax);

//            tile = Main.tile[i - 1, j + 1];
//            leftbottom = ValidAnchor(tile);

//            tile = Main.tile[i + 2, j + 1];
//            rightbottom = ValidAnchor(tile) && (i < KillOrderInvalidX || i >= KillOrderInvalidXMax);

//            //tile = Main.tile[i + 2, j + 2];
//            //bottom = WorldGen.AnchorValid(tile, AnchorType.SolidTile | AnchorType.SolidWithTop) || ModContent.GetModTile(tile.TileType) is CounterBase;

//            static bool ValidAnchor(Tile tile)
//            {
//                const AnchorType Anchors = AnchorType.SolidTile | AnchorType.SolidSide;
//                return WorldGen.AnchorValid(tile, Anchors) || ModContent.GetModTile(tile.TileType) is CounterBase;
//            }
//        }
//        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
//        {
//            TileID.Sets.Platforms[Type] = true;
//            Tile tile = Main.tile[i, j];
//            int offsetX = tile.TileFrameX % 36 / 18;
//            int offsetY = tile.TileFrameY % 36 / 18;

//            int topX = i - tile.TileFrameX % 36 / 18;
//            int topY = j - tile.TileFrameY % 36 / 18;

//            if (!fail && !BlockRecursion)
//            {
//                BlockRecursion = true;

//                for (int x = 0; x < 3; ++x)
//                {
//                    int curX = x + i - offsetX;

//                    if (curX != i && Main.tile[curX, j].HasTile)
//                        WorldGen.KillTile(i, j);
//                }

//                BlockRecursion = false;
//            }

//            if (offsetX == 0)
//            {
//                bool oldRecur = BlockRecursion;
//                BlockRecursion = false;
//                KillOrderInvalidX = i - 2;
//                KillOrderInvalidXMax = i;

//                ReframeAdjacent(i - 2, j);
//                ReframeAdjacent(i - 2, j + 1);
//                ReframeAdjacent(i + 2, j);
//                ReframeAdjacent(i + 2, j + 1);

//                KillOrderInvalidX = 0;
//                KillOrderInvalidXMax = 0;
//                BlockRecursion = oldRecur;
//            }

//            if (!BlockRecursion)
//                Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, Mod.Find<ModItem>("CounterModern").Type);
//        }

//        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
//        {
//            GetAnchors(i, j, out bool left, out bool right, out bool leftbottom, out bool rightbottom);
//            Tile tile = Main.tile[i, j];
//            int offsetX = tile.TileFrameX % 36 / 18;

//            if (offsetX != 0)
//                return false;

//            int frame = 0;

//            if (left && right && leftbottom && rightbottom)
//                frame = 2;
//            else if (left && !right && leftbottom && !rightbottom)
//                frame = 3;
//            else if (right && !left && rightbottom && !leftbottom)
//                frame = 1;

//            for (int x = 0; x < 2; ++x)
//            {
//                Tile subTile = Main.tile[i - offsetX + x, j];
//                subTile.TileFrameX = (short)(frame * 36 + x * 18);
//            }

//            ReframeAdjacent(i - 2, j);
//            ReframeAdjacent(i - 2, j);
//            ReframeAdjacent(i + 2, j);
//            ReframeAdjacent(i - 2, j + 1);
//            ReframeAdjacent(i + 2, j + 1);

//            return false;
//        }
//        static void ReframeAdjacent(int x, int y)
//        {
//            if (BlockRecursion)
//                return;

//            Tile tile = Main.tile[x, y];

//            if (ModContent.GetModTile(tile.TileType) is CounterBase)
//            {
//                BlockRecursion = true;
//                WorldGen.Reframe(x, y);
//                BlockRecursion = false;
//            }
//        }
//        //public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
//        //{
//        //    if (GetCounterAtPosition(i, j, out _))
//        //        Main.instance.TilesRenderer.AddSpecialPoint(i, j, Terraria.GameContent.Drawing.TileDrawing.TileCounterType.CustomNonSolid);
//        //}
//        //public override void SpecialDraw(int i, int j, SpriteBatch spriteBatch)
//        //{
//        //    if (GetCounterAtPosition(i, j, out Counters_9_Merge_Entity? table))
//        //    {
//        //        bool left = GetCounterAtPosition(i - 2, j, out _);
//        //        bool right = GetCounterAtPosition(i + 2, j, out _);
//        //        int frame = 0;

//        //        if (left && right)
//        //            frame = 2;
//        //        else if (left)
//        //            frame = 3;
//        //        else if (right)
//        //            frame = 1;

//        //        Texture2D tex = Tablecloth.PlacedTexturesByType[type].Value;
//        //        Main.spriteBatch.Draw(tex, new Vector2(i - 1, j) * 16 - Main.screenPosition, new Rectangle(frame * 50, 0, 48, 30), Lighting.GetColor(i, j));
//        //    }
//        //}
//        public static bool GetCounterAtPosition(int i, int j, [NotNullWhen(true)] out Counters_Merge_Entity? counter)
//        {
//            counter = null;
//            bool found = false;

//            if (TileEntity.ByPosition.TryGetValue(new Point16(i, j), out TileEntity? ent) && ent is Counters_Merge_Entity tb)
//            {
//                counter = tb;
//                found = true;
//            }

//            return found;
//        }
//    }
//}
//internal abstract class CounterBase : ModTile
//{
//    internal class CounterBaseSetup : ModSystem
//    {
//        public override void PostSetupContent()
//        {
//            var counters = ModContent.GetContent<Counters_Merge>();
//            int[] types = [.. counters.Select(x => x.Type)];
//            int[] bases = [.. Bases];

//            foreach (int @base in Bases)
//            {
//                int[] alts = TileObjectData.GetTileData(@base, 0).AnchorAlternateTiles ?? [];
//                TileObjectData.GetTileData(@base, 0).AnchorAlternateTiles = [.. alts, .. bases, .. types];
//            }
//        }
//    }
//    internal static List<int> Bases = [];

//    public override void SetStaticDefaults()
//    {
//        Main.tileFrameImportant[Type] = true;

//        Main.tileNoAttach[Type] = true;
//        Main.tileNoFail[Type] = false;

//        TileID.Sets.HasOutlines[Type] = true;
//        TileID.Sets.DisableSmartCursor[Type] = true;

//        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
//        TileObjectData.newTile.Origin = new Point16(0, 1);
//        TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };

//        TileObjectData.newTile.HookPostPlaceMyPlayer = ModContent.GetInstance<Counters_Merge_Entity>().Generic_HookPostPlaceMyPlayer;

//        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);

//        TileObjectData.newTile.StyleHorizontal = true;
//        //TileObjectData.newTile.RandomStyleRange = 9;
//        //TileObjectData.newTile.StyleMultiplier = 9;

//        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

//        TileObjectData.addTile(Type);
//    }
//    public override void KillMultiTile(int i, int j, int frameX, int frameY)
//    {
//        // When the tile is removed, we need to remove the Tile Entity as well.
//        ModContent.GetInstance<Counters_Merge_Entity>().Kill(i, j);
//    }
//}