using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.WallItems;
using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.WallTiles;

public class FrostedGlass : ModWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[base.Type] = true;
		base.ItemDrop = ModContent.ItemType<FrostedGlassItem>();
		base.AddMapEntry(new Color(187, 248, 252));
	}
}
