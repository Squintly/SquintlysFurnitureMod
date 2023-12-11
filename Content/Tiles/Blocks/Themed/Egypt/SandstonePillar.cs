using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks.Themed.Egypt;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks.Themed.Egypt;

public class SandstonePillar : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = false;
        Main.tileBrick[Type] = false;
        Main.tileNoAttach[Type] = false;
        Main.tileBlockLight[Type] = false;

        Main.tileMerge[ModContent.TileType<LotusBlock>()][ModContent.TileType<SandstonePillar>()] = true;
        Main.tileMerge[ModContent.TileType<SandstonePillar>()][ModContent.TileType<LotusBlock>()] = true;

        TileID.Sets.IsBeam[Type] = true;

        AddMapEntry(new Color(230, 215, 177));

        RegisterItemDrop(ModContent.ItemType<SandstonePillarItem>());
    }
}