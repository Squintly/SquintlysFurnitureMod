using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Blocks.Unsolids.Pillars.Classical;

public class ColumnCorinthian : BigUnsolid
{
    public override void SafeSetStaticDefaults()
    {
        Main.tileMerge[Type][ModContent.TileType<ColumnDoric>()] = true;
        Main.tileMerge[Type][ModContent.TileType<ColumnIonic>()] = true;
        Main.tileMerge[ModContent.TileType<ColumnDoric>()][Type] = true;
        Main.tileMerge[ModContent.TileType<ColumnIonic>()][Type] = true;

        AddMapEntry(new Color(232, 236, 238));
    }
}