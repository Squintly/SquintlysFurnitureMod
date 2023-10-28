using SquintlysFurnitureMod.Content.Items.Decorations.Misc;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Misc;

public class DecorativeWebDarkTile : ModTile
{
    public override void SetStaticDefaults()
    {
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileSolid[Type]= false;
        Main.tileNoFail[Type] = true;
        Main.tileNoAttach[Type] = true;

        Main.tileBlockLight[Type] = false;

       TileID.Sets.IsBeam[Type] = true;
        HitSound = SoundID.Grass;

        RegisterItemDrop(ModContent.ItemType<DecorativeWebDarkItem>());
    }
}