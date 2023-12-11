using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Plants.Thorns;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Plants.Thorns;

public class JungleThorns : ModTile
{
    public override void SetStaticDefaults()
    {
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileNoFail[Type] = true;
        Main.tileNoAttach[Type] = true;

        Main.tileNoSunLight[Type] = true;

        TileID.Sets.IsBeam[Type] = true;

        RegisterItemDrop(ModContent.ItemType<JungleThornBasket>());
        HitSound = SoundID.Grass;

        AddMapEntry(new Color(102, 153, 0));
    }
}