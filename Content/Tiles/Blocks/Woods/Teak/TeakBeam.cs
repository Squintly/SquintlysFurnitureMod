using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks.Woods.Teak;

public class TeakBeam : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = false;
        Main.tileBrick[Type] = false;
        Main.tileNoAttach[Type] = false;
        Main.tileBlockLight[Type] = false;

        TileID.Sets.IsBeam[Type] = true;

        AddMapEntry(new Color(77, 51, 0));

        RegisterItemDrop(ModContent.ItemType<TeakBeamItem>());
    }
}