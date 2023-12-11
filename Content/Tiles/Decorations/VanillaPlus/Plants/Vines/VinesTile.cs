using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Plants.Vines;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Plants.Vines;

public class VinesTile : ModTile
{
    public override void SetStaticDefaults()
    {
        TileID.Sets.DisableSmartCursor[Type] = true;
        Main.tileNoFail[Type] = true;
        Main.tileNoAttach[Type] = true;

        Main.tileNoSunLight[Type] = true;

        TileID.Sets.IsBeam[Type] = true;

        RegisterItemDrop(ModContent.ItemType<VineBasket>());
        HitSound = SoundID.Grass;

        AddMapEntry(new Color(0, 153, 0));
    }
}