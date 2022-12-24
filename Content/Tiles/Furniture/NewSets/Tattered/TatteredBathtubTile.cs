using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered;

public class TatteredBathtubTile : ModTile
{
	public override void SetStaticDefaults() {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoAttach[Type] = true;
        Main.tileNoFail[base.Type] = false;

        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        
        TileID.Sets.DisableSmartCursor[Type] = true;

        AdjTiles = new int[] { TileID.Bathtubs };
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

        AddMapEntry(new Color(79, 71, 58), base.CreateMapEntryName("Tattered Bathtub"));

        TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.Height = 2;
		TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
		TileObjectData.addTile(Type);
    }

	public override void KillMultiTile(int x, int y, int frameX, int frameY) {
		Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, ModContent.ItemType<Items.Furniture.NewSets.Tattered.TatteredBathtubItem>());
	}
}
