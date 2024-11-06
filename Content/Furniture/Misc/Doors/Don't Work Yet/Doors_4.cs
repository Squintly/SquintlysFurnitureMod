//using Microsoft.Xna.Framework;
//using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Holiday.Vernal;
//using Terraria;
//using Terraria.DataStructures;
//using Terraria.Enums;
//using Terraria.GameContent.ObjectInteractions;
//using Terraria.ID;
//using Terraria.Localization;
//using Terraria.ModLoader;
//using Terraria.ObjectData;

//namespace SquintlysFurnitureMod.Content.Furniture.Misc.Doors
//{
//    public class Doors_4_Open : ModTile
//    {
//        public override void SetStaticDefaults()
//        {
//            Main.tileFrameImportant[Type] = true;

//            Main.tileNoFail[Type] = false;
//            Main.tileNoAttach[Type] = true;

//            Main.tileLavaDeath[Type] = true;

//            TileID.Sets.HasOutlines[Type] = true;
//            TileID.Sets.DisableSmartCursor[Type] = true;

//            Main.tileBlockLight[Type] = true;
//            Main.tileSolid[Type] = false;
//            TileID.Sets.HousingWalls[Type] = true;
//            TileID.Sets.DrawsWalls[Type] = true;

//            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
//            AdjTiles = new int[] { TileID.OpenDoor };

//            TileID.Sets.CloseDoorID[Type] = ModContent.TileType<Doors_4_Closed>();

//            TileObjectData.newTile.Width = 2;
//            TileObjectData.newTile.Height = 3;
//            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
//            TileObjectData.newTile.CoordinateWidth = 16;
//            TileObjectData.newTile.CoordinatePadding = 2;
//            TileObjectData.newTile.Origin = new Point16(0, 0);

//            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 0);
//            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 0);

//            TileObjectData.newTile.LavaDeath = true;

//            TileObjectData.newTile.StyleMultiplier = 8;
//            TileObjectData.newTile.RandomStyleRange = 4;
//            TileObjectData.newTile.StyleWrapLimit = 8;
            

//            TileObjectData.newTile.UsesCustomCanPlace = true;

//            TileObjectData.newTile.Direction = TileObjectDirection.PlaceRight;

//            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
//            TileObjectData.newAlternate.Origin = new Point16(0, 1);
//            TileObjectData.addAlternate(0);

//            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
//            TileObjectData.newAlternate.Origin = new Point16(0, 2);
//            TileObjectData.addAlternate(0);

//            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
//            TileObjectData.newAlternate.Origin = new Point16(1, 0);
//            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
//            TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
//            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
//            TileObjectData.addAlternate(4);

//            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
//            TileObjectData.newAlternate.Origin = new Point16(1, 1);
//            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
//            TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
//            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
//            TileObjectData.addAlternate(4);

//            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
//            TileObjectData.newAlternate.Origin = new Point16(1, 2);
//            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
//            TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
//            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
//            TileObjectData.addAlternate(4);

//            TileObjectData.addTile(Type);
//        }

//        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
//        {
//            return true;
//        }

//        public override void MouseOver(int i, int j)
//        {
//            Player player = Main.LocalPlayer;
//            player.noThrow = 2;
//            player.cursorItemIconEnabled = true;
//            int style = TileObjectData.GetTileStyle(Main.tile[i, j]);
//            player.cursorItemIconID = TileLoader.GetItemDropFromTypeAndStyle(Type, style);

//        }
//    }
//    public class Doors_4_Closed : ModTile
//    {
//        public override void SetStaticDefaults()
//        {
//            Main.tileFrameImportant[Type] = true;

//            Main.tileNoFail[Type] = false;
//            Main.tileNoAttach[Type] = true;

//            Main.tileLavaDeath[Type] = true;

//            TileID.Sets.HasOutlines[Type] = true;
//            TileID.Sets.DisableSmartCursor[Type] = true;

//            Main.tileBlockLight[Type] = true;
//            Main.tileSolid[Type] = true;
//            TileID.Sets.NotReallySolid[Type] = true;
//            TileID.Sets.DrawsWalls[Type] = true;


//            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
//            AdjTiles = new int[] { TileID.ClosedDoor };

//            TileID.Sets.OpenDoorID[Type] = ModContent.TileType<Doors_4_Open>();

//            TileObjectData.newTile.Width = 1;
//            TileObjectData.newTile.Height = 3;

//            TileObjectData.newTile.Origin = new Point16(0, 0);
//            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
//            TileObjectData.newTile.CoordinateWidth = 16;
//            TileObjectData.newTile.CoordinatePadding = 2;

//            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
//            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            
//            TileObjectData.newTile.UsesCustomCanPlace = true;
//            TileObjectData.newTile.LavaDeath = true;
            
//            TileObjectData.newTile.StyleHorizontal = false;
//            TileObjectData.newTile.StyleMultiplier = 12;
//            TileObjectData.newTile.StyleWrapLimit = 12;
//            TileObjectData.newTile.RandomStyleRange = 4;
//            TileObjectData.newTile.StyleLineSkip = 12; // When a door closes, each tile randomize between 3 different options. StyleLineSkip ensures that those tiles are interpreted as the correct style.

//            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
//            TileObjectData.newAlternate.Origin = new Point16(0, 1);
//            TileObjectData.addAlternate(0);

//            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
//            TileObjectData.newAlternate.Origin = new Point16(0, 2);
//            TileObjectData.addAlternate(0);

//            TileObjectData.addTile(Type);
//        }

//        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
//        {
//            return true;
//        }

//        public override void MouseOver(int i, int j)
//        {
//            Player player = Main.LocalPlayer;
//            player.noThrow = 2;
//            int style = TileObjectData.GetTileStyle(Main.tile[i, j]);
//            player.cursorItemIconID = TileLoader.GetItemDropFromTypeAndStyle(Type, style);
//        }
//    }
//}
///*STYLES
//0- Imperial
//*/