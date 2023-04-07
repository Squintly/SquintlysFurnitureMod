using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks;
using SquintlysFurnitureMod.Content.Items.WallItems;
using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.WallTiles;

public class ChocolateWall : ModWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[base.Type] = true;
		base.ItemDrop = ModContent.ItemType<ChocolateWallItem>();
		base.AddMapEntry(new Color(97, 50, 24));
	}
}
