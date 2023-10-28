using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Abstracts;

/// <summary>
/// use this class to make crystal like tiles that will change its anchor point depending on the placement
/// </summary>
public abstract class OmnidirectionalAnchorTileMulti : ModTile
{
    /// <summary>
    /// this determines how many styles should this tile have
    /// the tilesheet needs to be in this order:
    /// horizontal: rotations (needs to rotate 4 times)
    /// vertical: styles
    /// </summary>
    protected virtual int StyleRange => 1;

    public override sealed void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileObsidianKill[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.UsesCustomCanPlace = true;
        TileObjectData.newTile.AnchorBottom = Terraria.DataStructures.AnchorData.Empty;
        TileObjectData.newTile.AnchorWall = true;
        TileObjectData.addTile(Type);

        StaticDefaults();
    }

    protected virtual void StaticDefaults()
    { }

    public override bool CanPlace(int i, int j) => AnyValidDirection(i, j);

    public override sealed bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
    {
        Tile tile = Main.tile[i, j];

        if (!HasValidTop(i, j, out bool topleft, out bool topright))
        {
            for (int x = i; x < i + 1; x++)
            {
                for (int y = j; y < j + 2; y++)
                {
                    WorldGen.KillTile(x, y);
                }
            }
            return false;
        }
        return false;
    }

    private static bool HasValidTop(int i, int j, out bool topleft, out bool topright)
    {
        topright = WorldGen.SolidTile(i + 1, j - 1);
        topleft = WorldGen.SolidTile(i, j - 1);

        return topright && topleft;
    }

    private static bool AnyValidDirection(int i, int j) => HasValidTop(i, j, out bool _, out bool _);
}