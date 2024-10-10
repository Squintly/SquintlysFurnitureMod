using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Abstracts.Blocks;

public abstract class Unsolid : ModTile
{   // Doesn't have collision or block light, like beams
    public override sealed void SetStaticDefaults()
    {
        Main.tileSolid[Type] = false;
        Main.tileBrick[Type] = false;
        Main.tileNoAttach[Type] = false;
        Main.tileBlockLight[Type] = false;

        TileID.Sets.IsBeam[Type] = true;

        SafeSetStaticDefaults();
    }
    public virtual void SafeSetStaticDefaults()
    {
    }
}