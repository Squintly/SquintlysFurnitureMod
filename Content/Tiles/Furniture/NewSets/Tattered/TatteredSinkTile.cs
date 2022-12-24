using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered
{
	public class TatteredSinkTile : ModTile
	{
		public override void SetStaticDefaults() {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[base.Type] = false;

            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            Main.tileWaterDeath[Type] = true;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileID.Sets.DisableSmartCursor[Type] = true;
            
			TileID.Sets.CountsAsWaterSource[Type] = true;
			
			Main.tileSolid[Type] = false;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 18 };
			TileObjectData.addTile(Type);

            AddMapEntry(new Color(79, 71, 58), base.CreateMapEntryName("Tattered Sink"));

            DustType = 84;
			AdjTiles = new int[] { Type };
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Furniture.NewSets.Tattered.TatteredSinkItem>());
		}
	}
}