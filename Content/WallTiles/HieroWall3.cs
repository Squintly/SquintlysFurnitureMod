using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.WallItems;
using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.WallTiles;

public class HieroWall3 : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(230, 215, 177));
    }
}