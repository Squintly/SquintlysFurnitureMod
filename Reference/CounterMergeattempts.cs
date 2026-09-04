//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.CodeAnalysis;
//using SquintlysFurnitureMod.Content.Furniture.Kitchen.Appliances.Dishwashers;
//using SquintlysFurnitureMod.Content.Furniture.Kitchen.Appliances.KitchenSinks;
//using SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Counters.CountersNarrow;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Terraria;
//using Terraria.DataStructures;
//using Terraria.Enums;
//using Terraria.ID;
//using Terraria.Localization;
//using Terraria.ModLoader;
//using Terraria.ModLoader.IO;
//using Terraria.ObjectData;

//namespace SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Counters
//{
//    //#nullable enable
//    public abstract class CounterMerge2x2 : ModTile
//    {
//        public override sealed void SetStaticDefaults()
//        {
//            Main.tileFrameImportant[Type] = true;
//            TileID.Sets.DisableSmartCursor[Type] = true;

//            Main.tileLavaDeath[Type] = false;

//            Main.tileNoFail[Type] = false;
//            Main.tileNoAttach[Type] = true;

//            AdjTiles = new int[] { TileID.Tables };
//            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

//            Main.tileSolidTop[Type] = true;
//            Main.tileTable[Type] = true;
//            TileID.Sets.IgnoredByNpcStepUp[Type] = true;

//            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
//            TileObjectData.newTile.Origin = new Point16(0, 0);
//            TileObjectData.newTile.Height = 2;
//            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
//            TileObjectData.newTile.Width = 2;

//            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
//            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

//            TileObjectData.newTile.StyleHorizontal = true;
//            TileObjectData.newTile.StyleMultiplier = 4;

//            TileObjectData.newTile.AnchorAlternateTiles = new int[]
//            {
//                ModContent.TileType<Counters_9>()
//            };

//            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
//            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
//            TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
//            TileObjectData.addAlternate(1);

//            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
//            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
//            TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
//            TileObjectData.addAlternate(2);

//            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
//            TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
//            TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
//            TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
//            TileObjectData.addAlternate(3);

//            TileObjectData.addTile(Type);
//            SafeSetStaticDefaults();
        

//        }
//        public virtual void SafeSetStaticDefaults()
//        {
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
//                return WorldGen.AnchorValid(tile, Anchors) || ModContent.GetModTile(tile.TileType) is CounterMerge2x2;
//            }
//        }
//		public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset) 
//        {
//            GetAnchors(i, j, out bool left, out bool right);
//            Tile tile = Main.tile[i, j];
//            int offsetX = tile.TileFrameX % 36 / 18;

//            if (left && right)
//                frameXOffset = 108;

//            else if (left && !right)
//                frameXOffset = 72;

//            else if (right && !left)
//                frameXOffset = 36;
//            else
//                frameXOffset = 0;
//		}
//    }
//}


        //private static void GetAnchors(int i, int j, out bool left, out bool right)
        //{
        //    Tile tile = Main.tile[i - 1, j];
        //    left = ValidAnchor(tile);

        //    tile = Main.tile[i + 2, j];
        //    right = ValidAnchor(tile);

        //    static bool ValidAnchor(Tile tile)
        //    {
        //        const AnchorType Anchors = AnchorType.SolidTile | AnchorType.SolidSide;
        //        return WorldGen.AnchorValid(tile, Anchors) || ModContent.GetModTile(tile.TileType) is Counters_9;
        //    }
        //}

        // Solution 4 

        //public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        //{
        //    if (TileEntity.TryGet(i, j, out Counters_9_Entity tileEntity))
        //    {
        //        tileFrameY = (short)(tileFrameY + (tileEntity.MergeState * 38));
        //    }
        //}
        // Solution 3 -- not paintable
        //public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        //{
        //    Tile tile = Main.tile[i, j];
        //    GetAnchors(i, j, out bool left, out bool right);

        //    Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

        //    int height = tile.TileFrameY % AnimationFrameHeight == 36 ? 18 : 16;
        //    int frameYOffset = 0;

        //    if (left && right)
        //        frameYOffset = 190;

        //    else if (left && !right)
        //        frameYOffset = 152;

        //    else if (right && !left)
        //        frameYOffset = 114;

        //    spriteBatch.Draw(
        //        TextureAssets.Tile[Type].Value,
        //        new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
        //        new Rectangle(tile.TileFrameX, tile.TileFrameY + frameYOffset, 16, height),
        //        Lighting.GetColor(i,j), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

        //    return false;
        //}

        // Solution 2 - doesn't work for chests
        //public override void AnimateTile(ref int frame, ref int frameCounter) {
        //	//if (++frameCounter >= 4) {
        //	//	frameCounter = 0;
        //	//	// We animate through the 1st 8 frames. The 9th frame is manually drawn if in the "off" state so it is not included in the animation logic here.
        //	//	frame = ++frame % 8;
        //	//}
        //}
        //public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset) 
        //      {
        //          GetAnchors(i, j, out bool left, out bool right);
        //          Tile tile = Main.tile[i, j];
        //          int offsetX = tile.TileFrameY % 36 / 18;

        //          if (left && right)
        //              frameYOffset = 190;

        //          else if (left && !right)
        //              frameYOffset = 152;

        //          else if (right && !left)
        //              frameYOffset = 114;
        //          else
        //              frameYOffset = 0;
        //}

        // Solution 1 - works but can't be painted
        //public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        //{
        //    Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
        //    bool draw = false;
        //    int x, offsetX, y, offsetY;
        //    offsetX = offsetY = x = y = 0;
        //    int frameX = (Main.tile[i, j].TileFrameX % 36);
        //    int frameY = (Main.tile[i, j].TileFrameY);

        //    List<int> countersMergeWith = new List<int>(new int[3]
        //    {
        //            ModContent.TileType<Dishwashers_3>(),
        //            ModContent.TileType<KitchenSinks_3>(),
        //            ModContent.TileType<Counters_Narrow_6>(),
        //    });
        //    if (frameX == 0)
        //    {
        //        Tile tile = Main.tile[i - ((frameX == 0) ? 1 : 2), j];
        //        if (!TileDrawing.IsVisible(tile))
        //        {
        //            return;
        //        }
        //        Tile val = ((Tilemap)Main.tile)[i - 1, j];
        //        int type = val.TileType;

        //        //Merge Counters
        //        if (type == Type)
        //        {
        //            //Modern
        //            if ((Main.tile[i, j].TileFrameX < 106) && (val.TileFrameX < 106))
        //            {
        //                draw = true;
        //                x = 0;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 106 && Main.tile[i, j].TileFrameX <= 214) &&
        //            (val.TileFrameX >= 106 && val.TileFrameX <= 214))
        //            {
        //                draw = true;
        //                x = 12;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 216 && Main.tile[i, j].TileFrameX <= 322) &&
        //            (val.TileFrameX >= 216 && val.TileFrameX <= 322))
        //            {
        //                draw = true;
        //                x = 24;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            //Vintage
        //            if ((Main.tile[i, j].TileFrameX >= 324 && Main.tile[i, j].TileFrameX <= 430) &&
        //            (val.TileFrameX >= 324 && val.TileFrameX <= 430))
        //            {
        //                draw = true;
        //                x = 36;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 432 && Main.tile[i, j].TileFrameX <= 538) &&
        //            (val.TileFrameX >= 432 && val.TileFrameX <= 538))
        //            {
        //                draw = true;
        //                x = 48;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 540 && Main.tile[i, j].TileFrameX <= 646) &&
        //            (val.TileFrameX >= 540 && val.TileFrameX <= 646))
        //            {
        //                draw = true;
        //                x = 60;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            // Antique
        //            if ((Main.tile[i, j].TileFrameX >= 648 && Main.tile[i, j].TileFrameX <= 754) &&
        //            (val.TileFrameX >= 648 && val.TileFrameX <= 754))
        //            {
        //                draw = true;
        //                x = 72;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 756 && Main.tile[i, j].TileFrameX <= 862) &&
        //            (val.TileFrameX >= 756 && val.TileFrameX <= 862))
        //            {
        //                draw = true;
        //                x = 84;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 864 && Main.tile[i, j].TileFrameX <= 970) &&
        //            (val.TileFrameX >= 864 && val.TileFrameX <= 970))
        //            {
        //                draw = true;
        //                x = 96;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            // Retro
        //            if ((Main.tile[i, j].TileFrameX >= 972 && Main.tile[i, j].TileFrameX <= 1078) &&
        //            (val.TileFrameX >= 972 && val.TileFrameX <= 1078))
        //            {
        //                draw = true;
        //                x = 108;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 1080 && Main.tile[i, j].TileFrameX <= 1186) &&
        //            (val.TileFrameX >= 1080 && val.TileFrameX <= 1186))
        //            {
        //                draw = true;
        //                x = 120;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 1188) &&
        //            (val.TileFrameX >= 1188))
        //            {
        //                draw = true;
        //                x = 132;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //        }
        //        //Merge Other
        //        if (countersMergeWith.Contains(type))
        //        {
        //            //Modern
        //            if ((Main.tile[i, j].TileFrameX < 106) && (val.TileFrameX < 34))
        //            {
        //                draw = true;
        //                x = 0;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 106 && Main.tile[i, j].TileFrameX <= 214) &&
        //            (val.TileFrameX >= 36 && val.TileFrameX <= 70))
        //            {
        //                draw = true;
        //                x = 12;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 216 && Main.tile[i, j].TileFrameX <= 322) &&
        //            (val.TileFrameX >= 72 && val.TileFrameX <= 106))
        //            {
        //                draw = true;
        //                x = 24;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            //Vintage
        //            if ((Main.tile[i, j].TileFrameX >= 324 && Main.tile[i, j].TileFrameX <= 430) &&
        //            (val.TileFrameX >= 108 && val.TileFrameX <= 142))
        //            {
        //                draw = true;
        //                x = 36;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 432 && Main.tile[i, j].TileFrameX <= 538) &&
        //            (val.TileFrameX >= 144 && val.TileFrameX <= 178))
        //            {
        //                draw = true;
        //                x = 48;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 540 && Main.tile[i, j].TileFrameX <= 646) &&
        //            (val.TileFrameX >= 180 && val.TileFrameX <= 214))
        //            {
        //                draw = true;
        //                x = 60;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            // Antique
        //            if ((Main.tile[i, j].TileFrameX >= 648 && Main.tile[i, j].TileFrameX <= 754) &&
        //            (val.TileFrameX >= 216 && val.TileFrameX <= 250))
        //            {
        //                draw = true;
        //                x = 72;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 756 && Main.tile[i, j].TileFrameX <= 862) &&
        //            (val.TileFrameX >= 252 && val.TileFrameX <= 286))
        //            {
        //                draw = true;
        //                x = 84;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 864 && Main.tile[i, j].TileFrameX <= 970) &&
        //            (val.TileFrameX >= 288 && val.TileFrameX <= 322))
        //            {
        //                draw = true;
        //                x = 96;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            // Retro
        //            if ((Main.tile[i, j].TileFrameX >= 972 && Main.tile[i, j].TileFrameX <= 1078) &&
        //            (val.TileFrameX >= 324 && val.TileFrameX <= 358))
        //            {
        //                draw = true;
        //                x = 108;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 1080 && Main.tile[i, j].TileFrameX <= 1186) &&
        //            (val.TileFrameX >= 360 && val.TileFrameX <= 394))
        //            {
        //                draw = true;
        //                x = 120;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //            if ((Main.tile[i, j].TileFrameX >= 1188) &&
        //            (val.TileFrameX >= 396))
        //            {
        //                draw = true;
        //                x = 132;
        //                offsetX = -6;
        //                y = frameY;
        //                offsetY = 0;
        //            }
        //        }
        //    }

        //    if (draw)
        //    {
        //        spriteBatch.Draw(
        //        inBetween.Value,
        //        new Vector2((i * 16 + offsetX - (int)Main.screenPosition.X), (j * 16f - offsetY - (int)Main.screenPosition.Y)) + zero,
        //        (Rectangle?)new Rectangle(x, y, 12, 34),
        //        Lighting.GetColor(i, j), 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
        //    }
        //}