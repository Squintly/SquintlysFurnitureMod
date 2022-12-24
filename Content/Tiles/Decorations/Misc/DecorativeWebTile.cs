using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Misc;

public class DecorativeWebTile : ModTile
{
	public override void SetStaticDefaults()
	{
		TileID.Sets.DisableSmartCursor[base.Type] = true;

        Main.tileNoFail[base.Type] = true;
        Main.tileNoAttach[base.Type] = true;

        //Main.tileBrick[base.Type] = true;
        //TileID.Sets.CanBeSloped[Type] = false;
        //Main.tileMergeDirt[base.Type] = true;
        //Main.tileBlendAll[base.Type] = false;
        //TileID.Sets.BlockMergesWithMergeAllBlock[Type] = false;
        //TileID.Sets.ChecksForMerge[Type] = false;
        //TileID.Sets.NotReallySolid[Type] = false;

        Main.tileLavaDeath[base.Type] = false;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        Main.tileWaterDeath[base.Type] = false;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

		Main.tileNoSunLight[base.Type] = true;

		TileObjectData.newTile.CopyFrom(TileObjectData.StyleSwitch);
		TileObjectData.newTile.Width = 1;
		TileObjectData.newTile.Height = 1;
		TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
		TileObjectData.newTile.CoordinatePadding = 2;

		TileObjectData.addTile(base.Type);

		base.AddMapEntry(new Color(189, 185, 179), base.CreateMapEntryName("Decorative Webs"));
		base.ItemDrop = ModContent.ItemType<DecorativeWebItem>();
		base.HitSound = SoundID.Grass;
	}
}
