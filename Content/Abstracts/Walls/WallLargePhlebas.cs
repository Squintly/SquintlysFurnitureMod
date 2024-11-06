using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Abstracts.Walls;

public abstract class WallLargePhlebas : ModWall
{   // Blocks light, wind and plant growth, uses the staggered large frame
    public override sealed void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        Main.wallLargeFrames[Type] = 1; //Phlebas = 1, Lazure = 2
        SafeSetStaticDefaults();
    }
    public virtual void SafeSetStaticDefaults()
    {
    }
}