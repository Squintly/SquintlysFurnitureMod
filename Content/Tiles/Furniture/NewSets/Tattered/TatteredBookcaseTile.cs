using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered;

public class TatteredBookcaseTile : ModTile
{
	public override void SetStaticDefaults() {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoFail[base.Type] = false;
        Main.tileNoAttach[base.Type] = true;

        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileSolidTop[Type] = true;
        Main.tileTable[base.Type] = true;
        AdjTiles = new int[] { TileID.Bookcases };
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

        AddMapEntry(new Color(79, 71, 58), base.CreateMapEntryName("Tattered Bookcase"));

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.Height = 4;
		TileObjectData.newTile.CoordinateHeights = new int[4] { 16, 16, 16, 20 };
		TileObjectData.addTile(Type);
    }

	public override void KillMultiTile(int x, int y, int frameX, int frameY) {
		Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, ModContent.ItemType<Items.Furniture.NewSets.Tattered.TatteredBookcaseItem>());
	}
}
