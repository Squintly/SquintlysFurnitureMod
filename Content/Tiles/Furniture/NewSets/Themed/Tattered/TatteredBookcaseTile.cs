using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Themed.Tattered;

public class TatteredBookcaseTile : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        Main.tileLavaDeath[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileSolidTop[Type] = true;
        Main.tileTable[Type] = true;
        AdjTiles = new int[] { TileID.Bookcases };
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
        TileObjectData.newTile.Height = 4;
        TileObjectData.newTile.CoordinateHeights = new int[4] { 16, 16, 16, 20 };

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Bookcase"));
    }
}