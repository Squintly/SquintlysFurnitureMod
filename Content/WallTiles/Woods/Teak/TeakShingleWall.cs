using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.WallTiles.Woods.Teak;

public class TeakShingleWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        Main.wallLight[Type] = true;
        WallID.Sets.Transparent[Type] |= true;
        AddMapEntry(new Color(52, 34, 0));
    }
}