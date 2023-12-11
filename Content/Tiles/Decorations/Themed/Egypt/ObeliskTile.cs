using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Themed.Egypt;

public class ObeliskTile : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
        TileObjectData.newTile.Height = 7;
        TileObjectData.newTile.Width = 2;
        TileObjectData.newTile.Origin = new Point16(1, 4);
        TileObjectData.newTile.CoordinateHeights = new int[7] { 16, 16, 16, 16, 16, 16, 18 };
        TileObjectData.newTile.DrawYOffset = 2;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);
    }
}