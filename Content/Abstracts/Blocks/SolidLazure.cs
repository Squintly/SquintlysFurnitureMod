using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Abstracts.Blocks;

public abstract class SolidLazure : ModTile
{   // Normal block; merges with bricks
    public override sealed void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileNoAttach[Type] = false;
        Main.tileMergeDirt[Type] = false;
        Main.tileBlockLight[Type] = true;
        Main.tileLargeFrames[Type] = 2;

        SafeSetStaticDefaults();
    }

    public virtual void SafeSetStaticDefaults()
    {
    }
}