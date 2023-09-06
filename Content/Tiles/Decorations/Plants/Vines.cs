using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Decorations.Plants;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Plants;

public class Vines : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileNoFail[Type] = true;
        Main.tileNoAttach[Type] = true;

        Main.tileLavaDeath[Type] = false;
        Main.tileWaterDeath[Type] = false;

        Main.tileNoSunLight[Type] = true;
        Main.tileSolid[Type] = false;
        Main.tileCut[Type] = true;
        Main.tileMergeDirt[Type] = false;

        RegisterItemDrop(ModContent.ItemType<VineBasket>());
        HitSound = SoundID.Grass;

        AddMapEntry(new Color(0, 153, 0));
    }
    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (Main.tile[i, j + 1].TileType == Type)
            WorldGen.KillTile(i, j + 1, false, false, true);
    }
    public override void NearbyEffects(int i, int j, bool closer)
    {
        if (!Main.tile[i, j - 1].HasTile)
            WorldGen.KillTile(i, j);
    }
    public override bool CanPlace(int i, int j) => Main.tile[i,j - 1].HasTile;
}