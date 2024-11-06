using SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Uninteractables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Classical.Pillars;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Uninteractables;

public class DecorativeWebTile : ModTile
{
    public override void SetStaticDefaults()
    {
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileSolid[Type] = false;
        TileID.Sets.IsBeam[Type] = true;

        Main.tileNoFail[Type] = true;

        Main.tileBlockLight[Type] = false;

        //TileID.Sets.ChecksForMerge[Type] = true;
        //Main.tileMerge[TileID.GrayBrick][Type] = true;
        //Main.tileMerge[Type][TileID.GrayBrick] = true;

        TileID.Sets.CanPlaceNextToNonSolidTile[Type] = true;

        HitSound = SoundID.Grass;

        RegisterItemDrop(ModContent.ItemType<DecorativeWebItem>());
    }

    //public override void ModifyFrameMerge(int i, int j, ref int up, ref int down, ref int left, ref int right, ref int upLeft, ref int upRight, ref int downLeft, ref int downRight)
    //{
    //    //We use this method to set the merge values of the adjacent tiles to -2 if the tile nearby is a snow block
    //    //-2 is what terraria uses to designate the tiles that will merge with ours using the custom frames
    //    WorldGen.TileMergeAttempt(-2, TileID.GrayBrick, ref up, ref down, ref left, ref right, ref upLeft, ref upRight, ref downLeft, ref downRight);
    //}

    //public override void PostTileFrame(int i, int j, int up, int down, int left, int right, int upLeft, int upRight, int downLeft, int downRight)
    //{

    //}
}