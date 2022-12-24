using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks;

public class FestiveColumn : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[base.Type] = false;
		Main.tileBrick[base.Type] = false;	
		Main.tileNoAttach[base.Type] = false;
		Main.tileBlockLight[base.Type] = false;

        base.AddMapEntry(new Color(66, 38, 5), base.CreateMapEntryName("Festive Column"));
		base.ItemDrop = ModContent.ItemType<FestiveColumnItem>();

		TileObjectData.newTile.CopyFrom(TileObjectData.StyleSwitch);
        TileObjectData.addTile(Type);
    }
}
