using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Plants.Reeds;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Plants.Reeds;

public class SilkMushroomReeds : ModTile
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

        RegisterItemDrop(ModContent.ItemType<MushroomReedBasket>());
        HitSound = SoundID.Grass;

        AddMapEntry(new Color(255, 153, 0));
    }
}