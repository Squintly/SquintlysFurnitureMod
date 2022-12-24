using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SquintlysFurnitureMod.Content.Items.Decorations.Hanging;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Hanging;

public class TinyHangingFishTile : ModTile
{
	public override void SetStaticDefaults()
	{
        Main.tileFrameImportant[base.Type] = true;
        TileID.Sets.DisableSmartCursor[base.Type] = true;

        Main.tileLavaDeath[base.Type] = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        Main.tileNoFail[base.Type] = true;
        TileID.Sets.FramesOnKillWall[base.Type] = false;
        Main.tileNoAttach[base.Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
		TileObjectData.newTile.Width = 1;
		TileObjectData.newTile.Height = 2;
		TileObjectData.newTile.Origin = new Point16(0, 0);
		TileObjectData.newTile.DrawXOffset = 2;
		TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };
		
		TileObjectData.addTile(base.Type);

        base.AddMapEntry(new Color(90, 110, 199), base.CreateMapEntryName("Tiny Hanging Fish"));
        base.HitSound = SoundID.NPCHit25;
        base.DustType = DustID.Water;
    }

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 24, ModContent.ItemType<Items.Decorations.Hanging.Fish.TinyHangingFish>());
	}
}
