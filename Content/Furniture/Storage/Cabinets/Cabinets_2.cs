using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Furniture.Storage.Cabinets
{
    public class Cabinets_2 : ModTile
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
            TileObjectData.newTile.CoordinateHeights = new int[4] { 16, 16, 16, 18 };

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.RandomStyleRange = 2;

            TileObjectData.addTile(Type);
        }
    }
}

/*STYLES
0- Imperial
1- Tattered
2- Repaired
*/