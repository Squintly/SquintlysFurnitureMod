using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.WallTiles.Other;

public class FrostedGlass : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        Main.wallLight[Type] = true;
        WallID.Sets.Transparent[Type] |= true;
        AddMapEntry(new Color(187, 248, 252));
    }
}