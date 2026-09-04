//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System.Collections.Generic;
//using SquintlysFurnitureMod.Content.Blocks.General.Grass;
//using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
//using Terraria;
//using Terraria.DataStructures;
//using Terraria.Enums;
//using Terraria.GameContent.Creative;
//using Terraria.GameContent.Metadata;
//using Terraria.Localization;
//using Terraria.ID;
//using Terraria.ModLoader;
//using Terraria.ObjectData;

//namespace SquintlysFurnitureMod.Content.Tiles.Plants.Grass.Natural;

//public class TeakFlowers : ModTile
//{
//    public override void SetStaticDefaults()
//    {
//        Main.tileFrameImportant[Type] = true;
//        TileID.Sets.DisableSmartCursor[Type] = true;

//        Main.tileLavaDeath[Type] = false;
//        Main.tileWaterDeath[Type] = false;

//        Main.tileNoFail[Type] = false;
//        Main.tileNoAttach[Type] = true;

//        Main.tileNoAttach[Type] = true;
//        Main.tileCut[Type] = true;
//		Main.tileObsidianKill[Type] = true;

//		TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Plant"]);
//		TileID.Sets.ReplaceTileBreakUp[Type] = true;
//		TileID.Sets.IgnoredInHouseScore[Type] = true;
//		TileID.Sets.IgnoredByGrowingSaplings[Type] = true;

//        HitSound = SoundID.Grass;

//        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
//        TileObjectData.newTile.Origin = new Point16(0, 0);
//        TileObjectData.newTile.DrawXOffset = 0;
//        TileObjectData.newTile.DrawYOffset = -14;
//        TileObjectData.newTile.CoordinateHeights = new int[1] { 32 };
//        TileObjectData.newTile.CoordinateWidth = 32;
//        TileObjectData.newTile.CoordinatePadding = 2;

//        TileObjectData.newTile.StyleHorizontal = true;
//        TileObjectData.newTile.RandomStyleRange = 14;

//        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.PlanterBox | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);
//        TileObjectData.newTile.AnchorAlternateTiles =
//            [
//                TileID.Grass,
//                TileID.AshGrass,
//                TileID.CorruptGrass,
//                TileID.CrimsonGrass,
//                TileID.HallowedGrass,
//                TileID.CrimsonJungleGrass,
//                TileID.CorruptJungleGrass,
//                TileID.JungleGrass,
//                TileID.MushroomGrass,
//                TileID.Mud,
//                TileID.Dirt,
//                TileID.ClayPot,
//                ModContent.TileType<TeakGrassBlock>()
//            ];

//        TileID.Sets.SwaysInWindBasic[Type] = true;

//        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
//        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
//        TileObjectData.addTile(Type);
//    }

//    public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
//    {
//        if (i % 2 == 0)
//        {
//            spriteEffects = SpriteEffects.FlipHorizontally;
//        }
//    }
//    public override bool CanDrop(int i, int j)
//    {
//	return true;
//	}
//    public override IEnumerable<Item> GetItemDrops(int i, int j)
//    {
//		Vector2 worldPosition = new Vector2(i, j).ToWorldCoordinates();
//		Player nearestPlayer = Main.player[Player.FindClosest(worldPosition, 16, 16)];

//		int seedItemType = ModContent.ItemType<TeakGrassSeeds>();
//		int seedItemStack = 1;

//		if (nearestPlayer.active && (nearestPlayer.HeldItem.type == ItemID.StaffofRegrowth || nearestPlayer.HeldItem.type == ItemID.AcornAxe))
//        {
//			seedItemStack = Main.rand.Next(1, 6);
//		}
//		else
//        {
//			seedItemStack = Main.rand.Next(1, 4);
//		}
//		if (seedItemType > 0 && seedItemStack > 0) {
//			yield return new Item(seedItemType, seedItemStack);
//		}
//	}

//}
//public class TeakFlowersPacket : ModItem
//{
//    public override void SetStaticDefaults()
//    {
//        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
//    }

//    public override void SetDefaults()
//    {
//        Item.width = 32;
//        Item.height = 32;
//        Item.value = Item.buyPrice(silver: 1);

//        Item.DefaultToPlaceableTile(ModContent.TileType<TeakFlowers>());

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
//public class TeakGrassPacket : ModItem
//{
//    public override void SetStaticDefaults()
//    {
//        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
//    }

//    public override void SetDefaults()
//    {
//        Item.DefaultToPlaceableTile(ModContent.TileType<TeakGrass>());

//        Item.width = 32;
//        Item.height = 32;
//        Item.value = Item.buyPrice(silver: 1);

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