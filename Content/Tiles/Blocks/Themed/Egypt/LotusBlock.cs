using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks.Themed.Egypt;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks.Themed.Egypt;

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