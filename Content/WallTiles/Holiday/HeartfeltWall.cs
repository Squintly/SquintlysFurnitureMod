using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.WallTiles.Holiday;

public class HeartfeltWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(219, 0, 44));
    }
}