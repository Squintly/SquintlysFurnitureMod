using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Abstracts.Walls;

public abstract class WallLargeLazure : ModWall
{   // Blocks light, wind and plant growth
    public override sealed void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        Main.wallLargeFrames[Type] = 2;
        SafeSetStaticDefaults();
    }

    public virtual void SafeSetStaticDefaults()
    {
    }
}