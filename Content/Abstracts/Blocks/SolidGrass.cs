//using System;
//using Microsoft.Xna.Framework;
//using Terraria;
//using Terraria.ID;
//using Terraria.GameContent.Metadata;
//using Terraria.Localization;
//using Terraria.ModLoader;

//namespace SquintlysFurnitureMod.Content.Abstracts.Blocks;

//public abstract class SolidGrass : ModTile
//{   // merges with dirt: REMEMBER TO HAVE PROPER SPRITE SHEET
//    public override sealed void SetStaticDefaults()
//    {
//        Main.tileSolid[Type] = true;
//        Main.tileBrick[Type] = true;
//        Main.tileMergeDirt[Type] = true;
//        Main.tileBlendAll[Type] = true;
//        Main.tileBlockLight[Type] = true;

//        TileID.Sets.ChecksForMerge[Type] = true;
//        TileID.Sets.CanBeDugByShovel[Type] = true;
//        TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;

//        TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Grass"]);
//        TileID.Sets.Conversion.Grass[Type] = true;
//        TileID.Sets.Grass[Type] = true;
//        TileID.Sets.NeedsGrassFraming[Type] = true;
//        TileID.Sets.NeedsGrassFramingDirt[Type] = ModContent.TileType<TerraPreta>();

//        SafeSetStaticDefaults();
//    }

//    public virtual void SafeSetStaticDefaults()
//    {
//    }
//}