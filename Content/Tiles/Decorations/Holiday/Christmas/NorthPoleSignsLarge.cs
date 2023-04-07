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

//public class NorthPoleSignsLarge : ModTile
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


//        Main.tileSign[Type] = true;

//        TileObjectData.addTile(base.Type);

//        base.AddMapEntry(new Color(12, 69, 6), base.CreateMapEntryName("North Pole Sign"));


//    }

//    public override void KillMultiTile(int x, int y, int frameX, int frameY)
//    {
//        int item = 0;
//        switch (frameX / 18)
//        {
//            case 0:
//                item = ModContent.ItemType<GoldNorthPoleSignLargeItem>();
//                break;
//            case 1:
//                item = ModContent.ItemType<NorthPoleSignLargeItem>();
//                break;
//        }
//        if (item > 0)
//        {
//            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 16, 16, item);
//        }
//    }
//}