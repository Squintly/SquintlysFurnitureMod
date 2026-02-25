using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Abstracts.Walls;

public abstract class Cavern : ModWall
{   //Allows wind and plant growth, but blocks light; good for caves!
    public override sealed void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        WallID.Sets.AllowsPlantsToGrow[Type] = true;
        WallID.Sets.AllowsWind[Type] = true;
        SafeSetStaticDefaults();
    }

    public virtual void SafeSetStaticDefaults()
    {
    }
}