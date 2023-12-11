using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Halloween.Decorations.Streamers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Halloween.Decorations.Streamers;

public class StreamerGhost : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = false;
        Main.tileBrick[Type] = false;
        Main.tileNoAttach[Type] = false;
        Main.tileBlockLight[Type] = false;

        TileID.Sets.IsBeam[Type] = true;

        RegisterItemDrop(ModContent.ItemType<StreamerGhostItem>());
    }
}