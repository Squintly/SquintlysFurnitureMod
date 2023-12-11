using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.WallTiles.Themed.Egypt;

public class HieroWall2 : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(230, 215, 177));
    }
}