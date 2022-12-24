using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks;
using SquintlysFurnitureMod.Content.Items.WallItems;
using Terraria;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.WallTiles;

public class FadedHieroWallSmall : ModWall
{
	public override void SetStaticDefaults()
	{
		Main.wallHouse[base.Type] = true;
		base.ItemDrop = ModContent.ItemType<FadedHieroWallSmallItem>();
		base.AddMapEntry(new Color(230, 215, 177));
	}
}
