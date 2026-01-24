using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Abstracts.Blocks;

public abstract class UnsolidLazure : ModTile
{   // Doesn't have collision or block light, like beams
    public override sealed void SetStaticDefaults()
    {
        Main.tileSolid[Type] = false;
        Main.tileBrick[Type] = false;
        Main.tileNoAttach[Type] = false;
        Main.tileBlockLight[Type] = false;
        Main.tileLargeFrames[Type] = 2;

        TileID.Sets.IsBeam[Type] = true;

        SafeSetStaticDefaults();
    }

    public virtual void SafeSetStaticDefaults()
    {
    }
}