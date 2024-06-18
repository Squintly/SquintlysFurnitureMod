using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.WallTiles.Holiday.Spring;

public class SpringyWoodGreenWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;

        AddMapEntry(new Color(118, 207, 123));

    }
}