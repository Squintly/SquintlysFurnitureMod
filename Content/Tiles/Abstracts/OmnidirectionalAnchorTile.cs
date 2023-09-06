﻿using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Abstracts;

/// <summary>
/// use this class to make crystal like tiles that will change its anchor point depending on the placement
/// </summary>
public abstract class OmnidirectionalAnchorTile : ModTile
{
    /// <summary>
    /// this determines how many styles should this tile have
    /// the tilesheet needs to be in this order:
    /// horizontal: rotations (needs to rotate 4 times) 
    /// vertical: styles
    /// </summary>
    protected virtual int StyleRange => 1;

    public sealed override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileObsidianKill[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileObjectData.newTile.UsesCustomCanPlace = true;
        TileObjectData.newTile.AnchorBottom = Terraria.DataStructures.AnchorData.Empty;
        TileObjectData.newTile.AnchorWall = false;
        TileObjectData.addTile(Type);

        StaticDefaults();
    }

    protected virtual void StaticDefaults() { }
    public override bool CanPlace(int i, int j) => AnyValidDirection(i, j);

    public sealed override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
    {
        Tile tile = Main.tile[i, j];

        if (!AnyValidDirection(i, j, out bool left, out bool right, out bool top, out bool bottom))
        {
            WorldGen.KillTile(i, j);
            return false;
        }
        else
        {
            const int SquareSize = 18;

            if (bottom)
                tile.TileFrameX = 0;
            else if (top)
                tile.TileFrameX = SquareSize * 3;
            else if (left)
                tile.TileFrameX = SquareSize;
            else if (right)
                tile.TileFrameX = SquareSize * 2;

            tile.TileFrameY = (short)(SquareSize * Main.rand.Next(StyleRange));
        }

        return false;
    }

    private static bool AnyValidDirection(int i, int j, out bool left, out bool right, out bool top, out bool bottom)
    {
        left = WorldGen.SolidTile(i - 1, j, true);
        right = WorldGen.SolidTile(i + 1, j, true);
        top = WorldGen.SolidTile(i, j - 1);
        bottom = WorldGen.SolidTile(i, j + 1);

        return left || right || top || bottom;
    }

    private static bool AnyValidDirection(int i, int j) => AnyValidDirection(i, j, out bool _, out bool _, out bool _, out bool _);
}