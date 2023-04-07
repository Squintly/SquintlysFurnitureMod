using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines;

public class RedRibbonTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[base.Type] = false;
		Main.tileBrick[base.Type] = false;	
		Main.tileNoAttach[base.Type] = false;
		Main.tileBlockLight[base.Type] = false;

        base.AddMapEntry(new Color(219, 0, 44), base.CreateMapEntryName("Heartfelt Ribbon"));
		base.ItemDrop = ModContent.ItemType<RedRibbon>();

		TileObjectData.newTile.CopyFrom(TileObjectData.StyleSwitch);
        TileObjectData.addTile(Type);
    }
}
