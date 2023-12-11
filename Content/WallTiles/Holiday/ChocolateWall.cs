using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.WallTiles.Holiday;

public class ChocolateWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(97, 50, 24));
    }
}