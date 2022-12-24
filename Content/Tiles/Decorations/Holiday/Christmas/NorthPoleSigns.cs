//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Christmas;
//using Terraria;
//using Terraria.ID;
//using Terraria.DataStructures;
//using Terraria.Enums;
//using Terraria.ModLoader;
//using Terraria.ObjectData;
//using Terraria.GameContent.ObjectInteractions;

//namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;

//public class NorthPoleSigns : ModTile
//{
//	public override void SetStaticDefaults()
//	{
//        Main.tileSign[Type] = true;

//		Main.tileFrameImportant[base.Type] = true;
//        TileID.Sets.DisableSmartCursor[base.Type] = true;

//        Main.tileLavaDeath[base.Type] = false;
//        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

//		Main.tileNoFail[base.Type] = false;
//        Main.tileNoAttach[base.Type] = true;

//		TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
//		TileObjectData.newTile.Height = 3;
//		TileObjectData.newTile.Width = 1;
//		TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 18 };

//        TileObjectData.addTile(base.Type);

//        base.AddMapEntry(new Color(12, 69, 6), base.CreateMapEntryName("Festive Decoration"));
//    }
//    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
//    {
//        return true;
//    }
//    public override void KillMultiTile(int i, int j, int frameX, int frameY)
//    {
//        Item.NewItem(i * 16, j * 16, 32, 32, mod.ItemType("NorthPoleSign"));
//        Sign.KillSign(i, j);
//    }
//}
