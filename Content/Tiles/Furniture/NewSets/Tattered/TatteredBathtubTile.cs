using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered;

public class TatteredBathtubTile : ModTile
{
	public override void SetStaticDefaults() {
		// Properties
		Main.tileNoAttach[Type] = true;
		Main.tileLavaDeath[Type] = true;
		Main.tileFrameImportant[Type] = true;
		TileID.Sets.DisableSmartCursor[Type] = true;

		// Placement
		TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.Height = 2;
		TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
		TileObjectData.addTile(Type);

        AdjTiles = new int[] { TileID.Bathtubs };
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

		// Etc
		ModTranslation name = CreateMapEntryName();
		name.SetDefault("Tattered Bathtub");
		AddMapEntry(new Color(200, 200, 200), name);
	}

	public override void NumDust(int x, int y, bool fail, ref int num) {
		num = fail ? 1 : 3;
	}

	public override void KillMultiTile(int x, int y, int frameX, int frameY) {
		Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, ModContent.ItemType<Items.Furniture.NewSets.Tattered.TatteredBathtubItem>());
	}
}
