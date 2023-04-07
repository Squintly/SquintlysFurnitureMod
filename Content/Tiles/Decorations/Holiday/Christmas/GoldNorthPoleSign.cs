//using Microsoft.Xna.Framework;
//using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Christmas;
//using Terraria;
//using Terraria.ID;
//using Terraria.DataStructures;
//using Terraria.Enums;
//using Terraria.ModLoader;
//using Terraria.ObjectData;
//using Terraria.GameContent.ObjectInteractions;

//namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;

//public class GoldNorthPoleSign : ModTile
//{
//    public override void SetStaticDefaults()
//    {
//        Main.tileFrameImportant[base.Type] = true;

//        TileID.Sets.DisableSmartCursor[base.Type] = true;

//        Main.tileLavaDeath[base.Type] = false;
//        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

//        Main.tileNoFail[base.Type] = false;
//        Main.tileNoAttach[base.Type] = true;

//        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
//        TileObjectData.newTile.Height = 3;
//        TileObjectData.newTile.Width = 1;
//        TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 18 };

//        TileObjectData.newTile.StyleHorizontal = true;
//        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
//        TileObjectData.newTile.Direction = TileObjectDirection.PlaceRight;

//        TileObjectData.newTile.StyleWrapLimit = 2;
//        TileObjectData.newTile.StyleMultiplier = 2;
//        TileObjectData.newTile.StyleHorizontal = true;

//        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
//        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
//        TileObjectData.addAlternate(1);

//        Main.tileSign[Type] = true;

//        TileObjectData.addTile(base.Type);

//        base.AddMapEntry(new Color(12, 69, 6), base.CreateMapEntryName("North Pole Sign"));


//    }

//    public override void KillMultiTile(int x, int y, int frameX, int frameY)
//    {
//        Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, ModContent.ItemType<GoldNorthPoleSignItem>());
//        Sign.KillSign(x, y);
//    }
//    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
//    {
//        return true;
//    }
//}