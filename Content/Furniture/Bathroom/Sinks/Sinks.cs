//using Microsoft.Xna.Framework;
//using Terraria;
//using Terraria.DataStructures;
//using Terraria.Enums;
//using Terraria.ID;
//using Terraria.Localization;
//using Terraria.ModLoader;
//using Terraria.ObjectData;

//namespace SquintlysFurnitureMod.Content.Furniture.Bathroom.Sinks
//{
//    public class Sinks : ModTile
//    {
//        public override void SetStaticDefaults()
//        {
//            Main.tileFrameImportant[Type] = true;

//            Main.tileNoAttach[Type] = true;
//            Main.tileNoFail[Type] = false;

//            Main.tileLavaDeath[Type] = true;

//            TileID.Sets.DisableSmartCursor[Type] = true;

//            TileID.Sets.CountsAsWaterSource[Type] = true;

//            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
//            AdjTiles = new int[] { TileID.Sinks };

//            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
//            TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
//            TileObjectData.newTile.Origin = new Point16(0, 0);

//            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
//            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

//            TileObjectData.addTile(Type);
//        }
//    }
//}
///*STYLES
// 0- Tattered
//1- Repaired
//*/