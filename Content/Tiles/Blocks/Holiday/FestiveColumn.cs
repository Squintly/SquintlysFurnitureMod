using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks.Holiday;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks.Holiday;

public class FestiveColumn : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = false;
        Main.tileBrick[Type] = false;
        Main.tileNoAttach[Type] = false;
        Main.tileBlockLight[Type] = false;

        TileID.Sets.IsBeam[Type] = true;

        AddMapEntry(new Color(66, 38, 5));

        RegisterItemDrop(ModContent.ItemType<FestiveColumnItem>());
    }
}