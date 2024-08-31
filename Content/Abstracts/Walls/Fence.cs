using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Abstracts.Walls;

public abstract class Fence : ModWall
{
    public sealed override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        Main.wallLight[Type] = true;
        WallID.Sets.AllowsPlantsToGrow[Type] = true;
        WallID.Sets.AllowsWind[Type] = true;
        WallID.Sets.Transparent[Type] = true;
        SafeSetStaticDefaults();
    }
    public virtual void SafeSetStaticDefaults()
    {
    }
}