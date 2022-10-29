using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered;

public class TatteredBookcaseTile : ModTile
{
	public override void SetStaticDefaults() {
		// Properties
		Main.tileNoAttach[Type] = true;
		Main.tileLavaDeath[Type] = true;
		Main.tileFrameImportant[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileTable[base.Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

		// Placement
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.Height = 4;
		TileObjectData.newTile.CoordinateHeights = new int[4] { 16, 16, 16, 20 };
		TileObjectData.addTile(Type);

        AdjTiles = new int[] { TileID.Bookcases };
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

		// Etc
		ModTranslation name = CreateMapEntryName();
		name.SetDefault("Tattered Bookcase");
		AddMapEntry(new Color(200, 200, 200), name);
	}

	public override void NumDust(int x, int y, bool fail, ref int num) {
		num = fail ? 1 : 3;
	}

	public override void KillMultiTile(int x, int y, int frameX, int frameY) {
		Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, ModContent.ItemType<Items.Furniture.NewSets.Tattered.TatteredBookcaseItem>());
	}
}
