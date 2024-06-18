//using Microsoft.Xna.Framework;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace SquintlysFurnitureMod.Content.Tiles.Blocks.Holiday.Spring;

//public class ColumnDoric : ModTile
//{
//    public override void SetStaticDefaults()
//    {
//        Main.tileSolid[Type] = false;
//        Main.tileBrick[Type] = false;
//        Main.tileNoAttach[Type] = false;
//        Main.tileBlockLight[Type] = false;

//        TileID.Sets.IsBeam[Type] = true;

//        Main.tileMerge[Type][ModContent.TileType<ColumnDoric>()] = true;
//        Main.tileMerge[Type][ModContent.TileType<ColumnIonic>()] = true;
//        Main.tileMerge[ModContent.TileType<ColumnDoric>()][Type] = true;
//        Main.tileMerge[ModContent.TileType<ColumnIonic>()][Type] = true;

//        TileID.Sets.GemsparkFramingTypes[Type] = Type;

//        AddMapEntry(new Color(232, 236, 238));
//    }
//    public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
//    {
//        Framing.SelfFrame8Way(i, j, Main.tile[i, j], resetFrame);
//        return false;
//    }
//}