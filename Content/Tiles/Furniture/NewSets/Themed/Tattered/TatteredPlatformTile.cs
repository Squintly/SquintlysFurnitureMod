using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Themed.Tattered;

public class TatteredPlatformTile : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoAttach[Type] = true;
        Main.tileNoFail[Type] = false;

        Main.tileLighted[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
        AddMapEntry(new Color(200, 200, 200));

        Main.tileSolidTop[Type] = true;
        Main.tileSolid[Type] = true;
        Main.tileTable[Type] = true;
        TileID.Sets.Platforms[Type] = true;

        AdjTiles = new int[] { TileID.Platforms };

        TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;

        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleMultiplier = 27;
        TileObjectData.newTile.StyleWrapLimit = 27;

        TileObjectData.newTile.UsesCustomCanPlace = false;

        TileObjectData.addTile(Type);
    }

    public override void PostSetDefaults()
    {
        Main.tileNoSunLight[Type] = false;
    }
}