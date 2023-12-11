using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks.VanillaPlus;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks.VanillaPlus;

public class PaleSandstoneColumn : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = false;
        Main.tileBrick[Type] = false;
        Main.tileNoAttach[Type] = false;
        Main.tileBlockLight[Type] = false;

        TileID.Sets.IsBeam[Type] = true;

        AddMapEntry(new Color(230, 215, 177));

        RegisterItemDrop(ModContent.ItemType<PaleSandstoneColumnItem>());
    }
}