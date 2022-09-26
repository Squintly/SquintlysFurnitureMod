using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.WallItems;
using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.WallTiles;

public class FadedHieroWall : ModWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[base.Type] = true;
		base.ItemDrop = ModContent.ItemType<FadedHieroWallItem>();
		base.AddMapEntry(new Color(222, 184, 135));
	}
}
