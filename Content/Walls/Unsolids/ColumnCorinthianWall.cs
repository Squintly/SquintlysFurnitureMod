using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Walls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Walls.Unsolids;

public class ColumnCorinthianWall : Fence
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(195, 204, 206));
    }
}