using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.WallTiles.Themed.Egypt;

public class SandstonePillarWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(222, 184, 135));
    }
}