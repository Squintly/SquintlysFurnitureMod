using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks;

public class LotusBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = false;
        Main.tileBrick[Type] = false;
        Main.tileNoAttach[Type] = false;
        Main.tileBlockLight[Type] = false;

        Main.tileMerge[ModContent.TileType<LotusBlock>()][ModContent.TileType<SandstonePillar>()] = true;
        Main.tileMerge[ModContent.TileType<SandstonePillar>()][ModContent.TileType<LotusBlock>()] = true;

        AddMapEntry(new Color(18, 135, 133));

        TileID.Sets.IsBeam[Type] = true;

        RegisterItemDrop(ModContent.ItemType<LotusBlockItem>());
    }
}