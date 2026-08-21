using Microsoft.VisualBasic;
using Terraria;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Abstracts.Blocks;

public abstract class SolidDirt : ModTile
{   // merges with dirt: REMEMBER TO HAVE PROPER SPRITE SHEET
    public override sealed void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlendAll[Type] = true;
        Main.tileBlockLight[Type] = true;

        TileID.Sets.ChecksForMerge[Type] = true;
        TileID.Sets.CanBeDugByShovel[Type] = true;
        TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
        TileID.Sets.Conversion.Dirt[Type] = true;
        TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Dirt"]);

        SafeSetStaticDefaults();
    }

    public virtual void SafeSetStaticDefaults()
    {
    }
}