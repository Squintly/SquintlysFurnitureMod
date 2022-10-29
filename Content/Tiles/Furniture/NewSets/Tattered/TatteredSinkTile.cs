using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered
{
	public class TatteredSinkTile : ModTile
	{
		public override void SetStaticDefaults() {
			TileID.Sets.CountsAsWaterSource[Type] = true;
			
			Main.tileSolid[Type] = false;
			Main.tileLavaDeath[Type] = false;
			Main.tileFrameImportant[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 18 };
			TileObjectData.addTile(Type);

			AddMapEntry(new Color(100, 100, 100));

			DustType = 84;
			AdjTiles = new int[] { Type };
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Furniture.NewSets.Tattered.TatteredSinkItem>());
		}
	}
}