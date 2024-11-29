//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Terraria;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;
//using ExampleMod.Content.Items;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using ReLogic.Content;
//using Terraria;
//using Terraria.DataStructures;
//using Terraria.GameContent;
//using Terraria.ID;
//using Terraria.ModLoader;
//using Terraria.ObjectData;

//namespace SquintlysFurnitureMod.Content.Abstracts.Walls;

//public abstract class CustomWall : ModWall
//{   // Blocks light, wind and plant growth
//    public override sealed void SetStaticDefaults()
//    {
//        Main.wallHouse[Type] = true;
//        SafeSetStaticDefaults();
//    }
//    public virtual void SafeSetStaticDefaults()
//    {
//    }

//    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
//    {
//        Tile tile = Main.tile[i, j];
//        Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);

//        Tile up = Main.tile[i, j -1 ];
//        Tile upright = Main.tile[i + 1, j - 1];
//        Tile upleft = Main.tile[i - 1, j - 1];
//        Tile right = Main.tile[i + 1, j];
//        Tile left = Main.tile[i - 1, j];
//        Tile downright = Main.tile[i + 1, j + 1];
//        Tile downleft = Main.tile[i - 1, j + 1];
//        Tile down = Main.tile[i, j + 1];


//        //Two-Ways

//        //Top Left Crook
//        if (right.WallType != WallID.None && down.WallType != WallID.None)
//        {
//            tile.TileFrameY = 0;
//            tile.TileFrameX = 468;
//        }

//        //Top Right Crook
//        if (left.WallType != WallID.None && down.WallType != WallID.None)
//        {
//            tile.TileFrameY = 0;
//            tile.TileFrameX = 540;
//        }

//        //Bottom Left Crook
//        if (right.WallType != WallID.None && up.WallType != WallID.None)
//        {
//            tile.TileFrameY = 72;
//            tile.TileFrameX = 468;
//        }

//        //Bottom Right Crook
//        if (left.WallType != WallID.None && up.WallType != WallID.None)
//        {
//            tile.TileFrameY = 72;
//            tile.TileFrameX = 540;
//        }

//        //Three-Ways

//        //Ts

//        //Top Junction
//        if (right.WallType != WallID.None && down.WallType != WallID.None && left.WallType != WallID.None)
//        {
//            tile.TileFrameY = 0;
//            tile.TileFrameX = 504;
//        }
        
//        //Right Junction
//        if (up.WallType != WallID.None && down.WallType != WallID.None && left.WallType != WallID.None)
//        {
//            tile.TileFrameY = 36;
//            tile.TileFrameX = 540;
//        }

//        //Left Junction
//        if (up.WallType != WallID.None && down.WallType != WallID.None && right.WallType != WallID.None)
//        {
//            tile.TileFrameY = 36;
//            tile.TileFrameX = 468;
//        }

//        //Bottom Junction
//        if (right.WallType != WallID.None && up.WallType != WallID.None && left.WallType != WallID.None)
//        {
//            tile.TileFrameY = 72;
//            tile.TileFrameX = 504;
//        }

//        //Inner Crooks
//        //Up/Downs

//        //Left Bottom Up/Down Crook
//        if (up.WallType != WallID.None && down.WallType != WallID.None && right.WallType != WallID.None && upright.WallType != WallID.None)
//        {
//            tile.TileFrameY = 0;
//            tile.TileFrameX = 576;
//        }

//        //Right Bottom Up/Down Crook
//        if (up.WallType != WallID.None && down.WallType != WallID.None && left.WallType != WallID.None && upleft.WallType != WallID.None)
//        {
//            tile.TileFrameY = 0;
//            tile.TileFrameX = 612;
//        }

//        //Left Top Up/Down Crook
//        if (up.WallType != WallID.None && down.WallType != WallID.None && right.WallType != WallID.None && downright.WallType != WallID.None)
//        {
//            tile.TileFrameY = 36;
//            tile.TileFrameX = 576;
//        }

//        //Right Top Up/Down Crook
//        if (up.WallType != WallID.None && down.WallType != WallID.None && left.WallType != WallID.None && downleft.WallType != WallID.None)
//        {
//            tile.TileFrameY = 36;
//            tile.TileFrameX = 612;
//        }

//        //Right/Lefts
//        //Left Bottom Right/Left Crook
//        if (left.WallType != WallID.None && downleft.WallType != WallID.None && right.WallType != WallID.None && down.WallType != WallID.None)
//        {
//            tile.TileFrameY = 72;
//            tile.TileFrameX = 576;
//        }

//        //Right Bottom Right/Left Crook
//        if (left.WallType != WallID.None && downright.WallType != WallID.None && right.WallType != WallID.None && down.WallType != WallID.Non)
//        {
//            tile.TileFrameY = 72;
//            tile.TileFrameX = 612;
//        }

//        //Left Top Up/Down Crook
//        if (up.WallType != WallID.None && upleft.WallType != WallID.None && right.WallType != WallID.None && left.WallType != WallID.None)
//        {
//            tile.TileFrameY = 108;
//            tile.TileFrameX = 576;
//        }

//        //Right Top Up/Down Crook
//        if (up.WallType != WallID.None && upright.WallType != WallID.None && left.WallType != WallID.None && right.WallType != WallID.None)
//        {
//            tile.TileFrameY = 108;
//            tile.TileFrameX = 612;
//        }

//        return base.PreDraw(i, j, spriteBatch);

//    }
//}




////int topX = i - (tile.TileFrameX % 684) % 32;
////int topY = j - (tile.TileFrameY % 180) % 32;

////short frameAdjustment = (short)(tile.TileFrameY % 128 >= 96 ? -96 : 96);
