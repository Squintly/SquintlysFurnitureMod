using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Abstracts.Blocks;

public abstract class SolidBlend : ModTile
{   //Blends with everything like smooth marble
    public override sealed void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileNoAttach[Type] = false;
        Main.tileBlendAll[Type] = true;
        Main.tileBlockLight[Type] = true;

        TileID.Sets.IsBeam[Type] = true;

        SafeSetStaticDefaults();
    }
    public virtual void SafeSetStaticDefaults()
    {
    }
}