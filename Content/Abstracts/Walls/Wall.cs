using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Abstracts.Walls;

public abstract class Wall : ModWall
{   // Blocks light, wind and plant growth
    public override sealed void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        SafeSetStaticDefaults();
    }

    public virtual void SafeSetStaticDefaults()
    {
    }
}