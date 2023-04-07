using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks;

public class ChocolateBlock : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[base.Type] = true;
		Main.tileBrick[base.Type] = true;
		Main.tileNoAttach[base.Type] = false;
		Main.tileMergeDirt[base.Type] = false;
		Main.tileBlockLight[base.Type] = true;
		base.AddMapEntry(new Color(97, 50, 24), base.CreateMapEntryName("Chocolate Block"));
		base.ItemDrop = ModContent.ItemType<ChocolateBlockItem>();
	}
}
