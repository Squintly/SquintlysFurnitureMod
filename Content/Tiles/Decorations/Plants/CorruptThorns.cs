using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.Plants;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Plants;

public class CorruptThorns : ModTile
{
    public override void SetStaticDefaults()
    {
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileNoFail[Type] = true;
        Main.tileNoAttach[Type] = true;

        Main.tileNoSunLight[Type] = true;

        TileID.Sets.IsBeam[Type] = true;

        RegisterItemDrop(ModContent.ItemType<CorruptThornBasket>());
        HitSound = SoundID.Grass;

        AddMapEntry(new Color(153, 51, 153));
    }
}