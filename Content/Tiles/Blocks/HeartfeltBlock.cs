using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks;

public class HeartfeltBlock : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[base.Type] = true;
		Main.tileBrick[base.Type] = true;
		Main.tileNoAttach[base.Type] = false;
		Main.tileMergeDirt[base.Type] = false;
		Main.tileBlockLight[base.Type] = true;
		base.AddMapEntry(new Color(219, 0, 44), base.CreateMapEntryName("Heartfelt Block"));
		base.ItemDrop = ModContent.ItemType<HeartfeltBlockItem>();
	}
}
