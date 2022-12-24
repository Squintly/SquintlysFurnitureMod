using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks;
using Terraria;
using Terraria.ID;
using Terraria.ObjectData;

using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks;

public class LotusBlock : ModTile
{
	public override void SetStaticDefaults()
	{
        Main.tileSolid[base.Type] = false;
        Main.tileBrick[base.Type] = false;
        Main.tileNoAttach[base.Type] = false;
        Main.tileBlockLight[base.Type] = false;

        Main.tileMerge[ModContent.TileType<LotusBlock>()][ModContent.TileType<SandstonePillar>()] = true;
        Main.tileMerge[ModContent.TileType<SandstonePillar>()][ModContent.TileType<LotusBlock>()] = true;

        base.AddMapEntry(new Color(18, 135, 133), base.CreateMapEntryName("Lotus Block"));
        base.ItemDrop = ModContent.ItemType<LotusBlockItem>();

        TileObjectData.newTile.CopyFrom(TileObjectData.StyleSwitch);
        TileObjectData.addTile(Type);
    }
}

