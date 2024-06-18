using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks.Holiday.Spring;

public class SpringBeam : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = false;
        Main.tileBrick[Type] = false;
        Main.tileNoAttach[Type] = false;
        Main.tileBlockLight[Type] = false;

        TileID.Sets.IsBeam[Type] = true;

        Main.tileMerge[Type][ModContent.TileType<SpringBeamDecorated>()] = true;
        Main.tileMerge[Type][ModContent.TileType<SpringBeamFloral>()] = true;
        Main.tileMerge[ModContent.TileType<SpringBeamDecorated>()][Type] = true;
        Main.tileMerge[ModContent.TileType<SpringBeamFloral>()][Type] = true;

        AddMapEntry(new Color(230, 255, 251));
    }
}