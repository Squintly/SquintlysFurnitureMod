using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks;

public class SandstoneBrickPlatform : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileLighted[base.Type] = true;
		Main.tileFrameImportant[base.Type] = true;
		Main.tileSolidTop[base.Type] = true;
		Main.tileSolid[base.Type] = true;
		Main.tileNoAttach[base.Type] = true;
		Main.tileTable[base.Type] = true;
		Main.tileLavaDeath[base.Type] = true;
		TileID.Sets.Platforms[base.Type] = true;
		TileID.Sets.DisableSmartCursor[base.Type] = true;
		base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
		base.AddMapEntry(new Color(200, 200, 200));
		base.ItemDrop = ModContent.ItemType<SandstoneBrickPlatformItem>();
		base.AdjTiles = new int[1] { 19 };
		TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.CoordinatePadding = 2;
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.StyleMultiplier = 27;
		TileObjectData.newTile.StyleWrapLimit = 27;
		TileObjectData.newTile.UsesCustomCanPlace = false;
		TileObjectData.newTile.LavaDeath = true;
		TileObjectData.addTile(base.Type);
	}

	public override void PostSetDefaults()
	{
		Main.tileNoSunLight[base.Type] = false;
	}
}
