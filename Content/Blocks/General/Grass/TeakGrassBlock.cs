//using Microsoft.Xna.Framework;
//using SquintlysFurnitureMod.Content.Abstracts.Blocks;
//using SquintlysFurnitureMod.Content.Blocks.General.Misc;
//using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
//using SquintlysFurnitureMod.Content.Tiles.Plants.Grass.Natural;
//using System;
//using Terraria;
//using Terraria.Audio;
//using Terraria.DataStructures;
//using Terraria.GameContent.Creative;
//using Terraria.GameContent.Metadata;
//using Terraria.ID;
//using Terraria.Localization;
//using Terraria.ModLoader;

//namespace SquintlysFurnitureMod.Content.Blocks.General.Grass;

//public class TeakGrassBlock : ModTile
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

//        TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Grass"]);
//        TileID.Sets.Conversion.Grass[Type] = true;
//        TileID.Sets.Grass[Type] = true;
//        TileID.Sets.NeedsGrassFraming[Type] = true;
//        TileID.Sets.NeedsGrassFramingDirt[Type] = ModContent.TileType<TerraPreta>();

//        RegisterItemDrop(ModContent.ItemType<TerraPretaItem>(), Array.Empty<int>());
//        AddMapEntry(new Color(69, 104, 38));
//    }

//    public override void RandomUpdate(int i, int j)
//    {
//        Tile tile = ((Tilemap)(Main.tile))[i, j];
//        Tile up = ((Tilemap)(Main.tile))[i, j - 1];
//        Tile up2 = ((Tilemap)(Main.tile))[i, j - 2];
//        if (Utils.NextBool(WorldGen.genRand, 10) && !((Tile)(up)).HasTile && !((Tile)(up2)).HasTile && (((Tile)(up)).LiquidAmount <= 0 || ((Tile)(up2)).LiquidAmount <= 0) && !((Tile)(tile)).LeftSlope && !((Tile)(tile)).RightSlope && !((Tile)(tile)).IsHalfBlock)
//        {
//            ((Tile)(up)).TileType = (ushort)ModContent.TileType<TeakGrass>();
//            ((Tile)(up)).HasTile = true;
//            ((Tile)(up)).TileFrameY = 0;
//            ((Tile)(up)).TileFrameX = (short)(WorldGen.genRand.Next(20) * 18);
//            WorldGen.SquareTileFrame(i, j - 1, true);
//            if (Main.dedServ)
//            {
//                NetMessage.SendTileSquare(-1, i, j - 1, 3, (TileChangeType)0);
//            }
//        }
//        if (Utils.NextBool(WorldGen.genRand, 10) && !((Tile)(up)).HasTile && !((Tile)(up2)).HasTile && (((Tile)(up)).LiquidAmount <= 0 || ((Tile)(up2)).LiquidAmount <= 0) && !((Tile)(tile)).LeftSlope && !((Tile)(tile)).RightSlope && !((Tile)(tile)).IsHalfBlock)
//        {
//            ((Tile)(up)).TileType = (ushort)ModContent.TileType<TeakFlowers>();
//            ((Tile)(up)).HasTile = true;
//            ((Tile)(up)).TileFrameY = 0;
//            ((Tile)(up)).TileFrameX = (short)(WorldGen.genRand.Next(23) * 18);
//            WorldGen.SquareTileFrame(i, j - 1, true);
//            if (Main.dedServ)
//            {
//                NetMessage.SendTileSquare(-1, i, j - 1, 3, (TileChangeType)0);
//            }
//        }
//    }
//    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
//    {
//        if (fail && !effectOnly)
//        {
//            Tile val = ((Tilemap)(Main.tile))[i, j];
//            ((Tile)(val)).TileType = (ushort)ModContent.TileType<TerraPreta>();
//        }
//    }
//}

//public class TeakGrassSeeds : ModItem
//{
//    public override void SetStaticDefaults()
//    {
//        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
//        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
//    }

//    public override void SetDefaults()
//    {
//        Item.DefaultToPlaceableTile(ModContent.TileType<TeakGrassBlock>());
//        Item.width = 32;
//        Item.height = 32;

//    }
//    public override bool? UseItem(Player player)
//    {
//        return true;
//    }

//    public override bool ConsumeItem(Player player)
//    {
//        int tileX = Player.tileTargetX;
//        int tileY = Player.tileTargetY;
//        Tile tile = Framing.GetTileSafely(tileX, tileY);
//        if (((Tile)(tile)).HasTile && ((Tile)(tile)).TileType == ModContent.TileType<TerraPreta>() && player.IsInTileInteractionRange(tileX, tileY, TileReachCheckSettings.Simple))
//        {
//            ((Tile)(tile)).TileType = (ushort)ModContent.TileType<TeakGrassBlock>();
//            if (Main.netMode == 1)
//            {
//                NetMessage.SendTileSquare(((Entity)player).whoAmI, tileX, tileY, (TileChangeType)0);
//            }
//            SoundEngine.PlaySound(SoundID.Dig, (Vector2?)((Entity)player).Center, (SoundUpdateCallback)null);
//            return true;
//        }
//        return false;
//    }
//    public override void AddRecipes()
//    {
//        CreateRecipe(4)
//           .AddIngredient(ItemID.GrassSeeds, 2)
//           .AddIngredient(ModContent.ItemType<TeakWood>(), 2)
//           .AddTile(TileID.HeavyWorkBench)
//           .Register();
//    }
//}