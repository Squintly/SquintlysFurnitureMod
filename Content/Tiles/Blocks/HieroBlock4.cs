using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks;

public class HieroBlock4 : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[base.Type] = true;
		Main.tileBrick[base.Type] = true;	
		Main.tileNoAttach[base.Type] = false;
		Main.tileMergeDirt[base.Type] = true;
		Main.tileBlockLight[base.Type] = true;
		base.AddMapEntry(new Color(222, 184, 135), base.CreateMapEntryName());
		base.ItemDrop = ModContent.ItemType<Content.Items.Blocks.HieroBlock1>();
		base.HitSound = SoundID.Dig;
		base.MineResist = 1f;
	}
}
