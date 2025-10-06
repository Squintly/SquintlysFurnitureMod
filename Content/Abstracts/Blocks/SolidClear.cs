using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Abstracts.Blocks;

public abstract class SolidClear : ModTile
{   //Acts as a solid surface for collision detection, but doesn't block like; use for glass/shingles
    public override sealed void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = false;
        Main.tileNoAttach[Type] = false;
        Main.tileMergeDirt[Type] = false;
        Main.tileBlockLight[Type] = false;

        TileID.Sets.IsBeam[Type] = true;

        SafeSetStaticDefaults();
    }

    public virtual void SafeSetStaticDefaults()
    {
    }
}