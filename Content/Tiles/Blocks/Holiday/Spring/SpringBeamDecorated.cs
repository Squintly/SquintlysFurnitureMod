using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks.Holiday.Spring;

public class SpringBeamDecorated : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = false;
        Main.tileBrick[Type] = false;
        Main.tileNoAttach[Type] = false;
        Main.tileBlockLight[Type] = false;

        TileID.Sets.IsBeam[Type] = true;

        Main.tileMerge[Type][ModContent.TileType<SpringBeam>()] = true;
        Main.tileMerge[Type][ModContent.TileType<SpringBeamFloral>()] = true;
        Main.tileMerge[ModContent.TileType<SpringBeam>()][Type] = true;
        Main.tileMerge[ModContent.TileType<SpringBeamFloral>()][Type] = true;

        AddMapEntry(new Color(230, 255, 251));
    }
}