using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Themed.Repaired;

public class RepairedBathtub : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoAttach[Type] = true;
        Main.tileNoFail[Type] = false;

        Main.tileLavaDeath[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        AdjTiles = new int[] { TileID.Bathtubs };
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);

        TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 2;
        TileObjectData.newTile.Height = 2;
        TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Bathtub"));
    }
}