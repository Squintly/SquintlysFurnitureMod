using SquintlysFurnitureMod.Content.Items.Decorations.Misc;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Misc;

public class DecorativeWebTile : ModTile
{
    public override void SetStaticDefaults()
    {
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileNoFail[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileBlendAll[Type] = true;

        TileID.Sets.BlockMergesWithMergeAllBlock[Type] = true;

        Main.tileLavaDeath[Type] = false;
        Main.tileWaterDeath[Type] = false;

        Main.tileNoSunLight[Type] = true;
        
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        HitSound = SoundID.Grass;

        RegisterItemDrop(ModContent.ItemType<DecorativeWebItem>());
    }
}