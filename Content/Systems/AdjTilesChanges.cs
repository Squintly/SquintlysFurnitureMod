//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using ReLogic.Content;
//using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
//using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
//using Terraria;
//using Terraria.Audio;
//using Terraria.DataStructures;
//using Terraria.Enums;
//using Terraria.GameContent.Drawing;
//using Terraria.GameContent.ObjectInteractions;
//using Terraria.ID;
//using Terraria.Localization;
//using Terraria.ModLoader;
//using Terraria.ObjectData;

//namespace SquintlysFurnitureMod.Content.Systems
//{
//    public class AdjTilesChanges : GlobalTile
//    {
//        public override int[] AdjTiles(int type)
//        {
//            int[] result = base.AdjTiles(type);

//            if (type == ModContent.TileType<Shops>() && (tile.TileFrameX / 74))
//            {
//                int i = Main.tile.Width;
//                int j = Main.tile.Height;
//                Tile tile = Main.tile[i, j];

//                switch (tile.TileFrameX / 74)
//                {
//                    case 0:
//                        result = [ModContent.TileType<DecoBoxTile>()];
//                        break;
//                }
//            }
//            return result;
//        }
//    }
//}