using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks.Themed.Egypt;

public class FadedHieroBlock3 : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileNoAttach[Type] = false;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;

        AddMapEntry(new Color(230, 215, 177));
    }
}