using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Misc;

public class ObeliskTile : ModTile
{
	public override void SetStaticDefaults()
	{
        Main.tileFrameImportant[base.Type] = true;
        TileID.Sets.DisableSmartCursor[base.Type] = true;

        Main.tileLavaDeath[base.Type] = false;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        Main.tileNoAttach[base.Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
		TileObjectData.newTile.Height = 7;
		TileObjectData.newTile.Width = 2;
		TileObjectData.newTile.Origin = new Point16(1, 4);
		TileObjectData.newTile.CoordinateHeights = new int[7] { 16, 16, 16, 16, 16, 16, 18 };
		TileObjectData.newTile.DrawYOffset = 2;

		TileObjectData.addTile(base.Type);

        base.AddMapEntry(new Color(230, 215, 177), base.CreateMapEntryName("Obelisk"));
    }

	public override void KillMultiTile(int x, int y, int frameX, int frameY)
	{
		Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 32, 80, ModContent.ItemType<ObeliskItem>());
	}
}
