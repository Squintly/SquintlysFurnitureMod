using SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Uninteractables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Uninteractables;

public class DecorativeWebDarkTile : ModTile
{
    public override void SetStaticDefaults()
    {
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileSolid[Type] = false;
        Main.tileNoFail[Type] = true;
        Main.tileNoAttach[Type] = true;

        Main.tileBlockLight[Type] = false;

        TileID.Sets.IsBeam[Type] = true;
        HitSound = SoundID.Grass;

        RegisterItemDrop(ModContent.ItemType<DecorativeWebDarkItem>());
    }
}