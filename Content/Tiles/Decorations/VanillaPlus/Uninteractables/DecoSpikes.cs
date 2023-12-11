using SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Uninteractables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Uninteractables;

public class DecoSpikes : ModTile
{
    public override void SetStaticDefaults()
    {
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileNoFail[Type] = true;
        Main.tileNoAttach[Type] = true;

        Main.tileLavaDeath[Type] = false;
        Main.tileWaterDeath[Type] = false;

        Main.tileNoSunLight[Type] = true;

        TileID.Sets.IsBeam[Type] = true;

        RegisterItemDrop(ModContent.ItemType<DecoSpikeItem>());
    }
}