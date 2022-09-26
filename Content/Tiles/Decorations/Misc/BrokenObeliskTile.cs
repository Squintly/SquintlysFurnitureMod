using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Misc;

public class BrokenObeliskTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[base.Type] = true;
		Main.tileLavaDeath[base.Type] = false;
		Main.tileNoAttach[base.Type] = true;
		Main.tileLighted[base.Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
		TileObjectData.newTile.Height = 5;
		TileObjectData.newTile.Width = 3;
		TileObjectData.newTile.Origin = new Point16(1, 4);
		TileObjectData.newTile.CoordinateHeights = new int[5] { 16, 16, 16, 16, 16 };
		TileObjectData.newTile.DrawYOffset = 2;
		TileObjectData.addTile(base.Type);
		base.AddMapEntry(new Color(127, 127, 127));
	}

	public override void KillMultiTile(int x, int y, int frameX, int frameY)
	{
		Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 32, 80, ModContent.ItemType<BrokenObeliskItem>());
	}

	public override bool CreateDust(int i, int j, ref int type)
	{
		return false;
	}
}
