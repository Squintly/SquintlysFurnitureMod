using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks;

public class SandstonePillar : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileSolid[base.Type] = false;
		Main.tileBrick[base.Type] = false;	
		Main.tileNoAttach[base.Type] = false;
		Main.tileBlockLight[base.Type] = false;

        Main.tileMerge[ModContent.TileType<LotusBlock>()][ModContent.TileType<SandstonePillar>()] = true;
        Main.tileMerge[ModContent.TileType<SandstonePillar>()][ModContent.TileType<LotusBlock>()] = true;

        base.AddMapEntry(new Color(230, 215, 177), base.CreateMapEntryName("Sandstone Pillar"));
		base.ItemDrop = ModContent.ItemType<SandstonePillarItem>();

		TileObjectData.newTile.CopyFrom(TileObjectData.StyleSwitch);
        TileObjectData.addTile(Type);
    }
}
