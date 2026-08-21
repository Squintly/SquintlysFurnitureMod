//using Microsoft.Xna.Framework;
//using SquintlysFurnitureMod.Content.Abstracts.Blocks;
//using SquintlysFurnitureMod.Content.Blocks.General.Grass;
//using Terraria;
//using Terraria.GameContent.Creative;
//using Terraria.GameContent.Metadata;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace SquintlysFurnitureMod.Content.Blocks.General.Misc;

//public class TerraPreta : ModTile
//{
//    public override void SetStaticDefaults()
//    {
//        Main.tileSolid[Type] = true;
//        Main.tileBrick[Type] = true;
//        Main.tileMergeDirt[Type] = true;
//        Main.tileBlendAll[Type] = true;
//        Main.tileBlockLight[Type] = true;

//        TileID.Sets.ChecksForMerge[Type] = true;
//        TileID.Sets.CanBeDugByShovel[Type] = true;
//        TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
//        TileID.Sets.Conversion.Dirt[Type] = true;
//        TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Dirt"]);

//        AddMapEntry(new Color(43, 16, 0));
//    }
//    	public override void RandomUpdate(int i, int j)
//	{
//		Tile up = ((Tilemap)(Main.tile))[i, j - 1];
//		Tile down = ((Tilemap)(Main.tile))[i, j + 1];
//		Tile left = ((Tilemap)(Main.tile))[i - 1, j];
//		Tile right = ((Tilemap)(Main.tile))[i + 1, j];
//		if (Utils.NextBool(WorldGen.genRand, 3) && (((Tile)(up)).TileType == ModContent.TileType<TeakGrassBlock>() || ((Tile)(down)).TileType == ModContent.TileType<TeakGrassBlock>() || ((Tile)(left)).TileType == ModContent.TileType<TeakGrassBlock>() || ((Tile)(right)).TileType == ModContent.TileType<TeakGrassBlock>()))
//		{
//			WorldGen.SpreadGrass(i, j, (int)((ModBlockType)this).Type, ModContent.TileType<TeakGrassBlock>(), false, default(TileColorCache));
//		}
//	}
//}

//public class TerraPretaItem : ModItem
//{
//    public override void SetStaticDefaults()
//    {
//        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
//    }

//    public override void SetDefaults()
//    {
//        Item.DefaultToPlaceableTile(ModContent.TileType<TerraPreta>());

//        Item.width = 16;
//        Item.height = 16;
//    }

//    public override void AddRecipes()
//    {
//        CreateRecipe(8)
//           .AddIngredient(ItemID.ClayBlock, 2)
//           .AddIngredient(ItemID.DirtBlock, 2)
//           .AddIngredient(ItemID.PoopBlock)
//           .AddTile(TileID.HeavyWorkBench)
//           .Register();
//    }
//}