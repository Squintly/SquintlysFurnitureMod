using SquintlysFurnitureMod.Content.Blocks.Themed.Aesthetics.Repaired;
using SquintlysFurnitureMod.Content.Blocks.Themed.Aesthetics.Tattered;
using SquintlysFurnitureMod.Content.Furniture.Misc.Platforms.Items;
using SquintlysFurnitureMod.Content.Items.Blocks.Holiday.Spring;
using SquintlysFurnitureMod.Content.Items.Blocks.Themed.Egypt;
using SquintlysFurnitureMod.Content.Items.Blocks.VanillaPlus;
using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Fruit;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Future.Guns;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Historical.Axes;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Historical.GuanDaos;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Historical.Hammers;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Historical.Picks;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Historical.Poles;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Historical.Spears;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Historical.Swords;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Modern;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Military.Modern.Guns;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Woods.Teak;
using SquintlysFurnitureMod.Content.Items.WallItems.Themed.Egypt;
using SquintlysFurnitureMod.Content.Items.WallItems.VanillaPlus;
using SquintlysFurnitureMod.Content.Items.WallItems.Woods.Teak;
using SquintlysFurnitureMod.Content.Walls.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Walls.General.Bricks.Red;
using SquintlysFurnitureMod.Content.Walls.General.Bricks.Stone;
using SquintlysFurnitureMod.Content.Walls.Themed.Eras.Imperial;

using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content
{
    public class VanillaRecipeGroups : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup Meat = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Meat", ItemID.Steak, ItemID.Bacon, ItemID.BBQRibs, ItemID.ChickenNugget, ItemID.HamBat);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Meat", Meat);

            RecipeGroup Paint = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Paint", ItemID.WhitePaint, ItemID.GrayPaint, ItemID.BlackPaint, ItemID.BrownPaint,
                ItemID.RedPaint, ItemID.OrangePaint, ItemID.YellowPaint, ItemID.LimePaint, ItemID.GreenPaint, ItemID.TealPaint, ItemID.SkyBluePaint, ItemID.BluePaint, ItemID.PurplePaint, ItemID.PinkPaint, ItemID.VioletPaint,
                ItemID.DeepRedPaint, ItemID.DeepOrangePaint, ItemID.DeepYellowPaint, ItemID.DeepLimePaint, ItemID.DeepGreenPaint, ItemID.DeepTealPaint, ItemID.DeepSkyBluePaint, ItemID.DeepBluePaint, ItemID.DeepPurplePaint, ItemID.DeepPinkPaint, ItemID.DeepVioletPaint);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Paint", Paint);

            RecipeGroup FlowerSeeds = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Flower Seeds", ItemID.FlowerPacketRed, ItemID.FlowerPacketYellow, ItemID.FlowerPacketBlue, ItemID.FlowerPacketViolet, ItemID.FlowerPacketMagenta, ItemID.FlowerPacketWhite, ItemID.FlowerPacketPink, ItemID.FlowerPacketWild);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:FlowerSeeds", FlowerSeeds);

            RecipeGroup GoldBar = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBar)}", ItemID.GoldBar, ItemID.PlatinumBar);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:GoldBar", GoldBar);

            RecipeGroup SilverBar = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverBar)}", ItemID.SilverBar, ItemID.TungstenBar);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:SilverBar", SilverBar);

            RecipeGroup CopperBar = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperBar)}", ItemID.CopperBar, ItemID.TinBar);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:CopperBar", CopperBar);

            RecipeGroup Streamers = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Streamers", ItemID.SillyStreamerGreen, ItemID.SillyStreamerPink, ItemID.SillyStreamerBlue);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Streamers", Streamers);

            RecipeGroup Berries = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Berry", ItemID.Elderberry, ItemID.BlackCurrant);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Berries", Berries);

            RecipeGroup Balloons = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Balloons", ItemID.SillyBalloonGreen, ItemID.SillyBalloonPink, ItemID.SillyBalloonPurple);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Balloons", Balloons);

            RecipeGroup Explosives = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Explosives", ItemID.Bomb, ItemID.StickyBomb, ItemID.BouncyBomb, ItemID.DirtBomb, ItemID.DirtStickyBomb,
                    ItemID.DryBomb, ItemID.WetBomb, ItemID.HoneyBomb, ItemID.LavaBomb, ItemID.ScarabBomb, ItemID.BombFish, ItemID.SmokeBomb, ItemID.Grenade, ItemID.BouncyGrenade, ItemID.StickyGrenade, ItemID.PartyGirlGrenade,
                    ItemID.Dynamite, ItemID.BouncyDynamite, ItemID.StickyDynamite, ItemID.DynamiteFish);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Explosives", Explosives);
        }
    }

    public class ModRecipeGroups : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup Festive = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Festive Block", ItemID.CandyCaneBlock, ItemID.GreenCandyCaneBlock, ItemID.PineTreeBlock);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Festive", Festive);

            //Platforms

            RecipeGroup ImperialPlatforms = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Imperial Platforms", Mod.Find<ModItem>(Platforms_Items.GetInternalNameFromStyle(0)).Type, Mod.Find<ModItem>(Platforms_Items.GetInternalNameFromStyle(1)).Type, Mod.Find<ModItem>(Platforms_Items.GetInternalNameFromStyle(2)).Type);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:ImperialPlatforms", ImperialPlatforms);

            RecipeGroup TatteredPlatforms = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Tattered Platforms", Mod.Find<ModItem>(Platforms_Items.GetInternalNameFromStyle(3)).Type, Mod.Find<ModItem>(Platforms_Items.GetInternalNameFromStyle(4)).Type, Mod.Find<ModItem>(Platforms_Items.GetInternalNameFromStyle(5)).Type);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:TatteredPlatforms", TatteredPlatforms);

            RecipeGroup RepairedPlatforms = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Repaired Platforms", Mod.Find<ModItem>(Platforms_Items.GetInternalNameFromStyle(6)).Type, Mod.Find<ModItem>(Platforms_Items.GetInternalNameFromStyle(7)).Type, Mod.Find<ModItem>(Platforms_Items.GetInternalNameFromStyle(8)).Type);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:RepairedPlatforms", RepairedPlatforms);

            RecipeGroup TeakPlatforms = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Teak Platforms", ModContent.ItemType<TeakPlatformItem>(), ModContent.ItemType<TeakShelfItem>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:TeakPlatforms", TeakPlatforms);

            //Blocks

            RecipeGroup HieroBlocks = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Sandstone Block/Wall",
                ModContent.ItemType<HieroBlock1Item>(), ModContent.ItemType<HieroBlock2Item>(), ModContent.ItemType<HieroBlock3Item>(), ModContent.ItemType<HieroBlock4Item>(),
                ModContent.ItemType<FadedHieroBlock1Item>(), ModContent.ItemType<FadedHieroBlock2Item>(), ModContent.ItemType<FadedHieroBlock3Item>(), ModContent.ItemType<FadedHieroBlock4Item>(),
                ModContent.ItemType<HieroWall1Item>(), ModContent.ItemType<HieroWall2Item>(), ModContent.ItemType<HieroWall3Item>(), ModContent.ItemType<HieroWall4Item>(), ModContent.ItemType<HieroWallSmallItem>(),
                ModContent.ItemType<FadedHieroWall1Item>(), ModContent.ItemType<FadedHieroWall2Item>(), ModContent.ItemType<FadedHieroWall3Item>(), ModContent.ItemType<FadedHieroWall4Item>(), ModContent.ItemType<FadedHieroWallSmallItem>(),
                ModContent.ItemType<PolishedSandstoneBrickItem>(), ModContent.ItemType<PolishedSandstoneBrickWallItem>(), ItemID.Sandstone, ItemID.SandstoneBrick, ItemID.SandstoneBrickWall, ItemID.SandstoneSlab);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:HieroBlocks", HieroBlocks);
            
            //Walls

            RecipeGroup TeakWalls = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Teak Wall", ModContent.ItemType<TeakWallItem>(), ModContent.ItemType<TeakFenceItem>(),
                ModContent.ItemType<TeakFenceSlatItem>(), ModContent.ItemType<TeakFenceSolidItem>(), ModContent.ItemType<TeakFenceLatticeItem>(), ModContent.ItemType<TeakPoleItem>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:TeakWalls", TeakWalls);

            RecipeGroup ImperialWalls = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Imperial Wall", ModContent.ItemType<ImperialWallpaperFancyItem>(), ModContent.ItemType<ImperialWallpaperItem>(),
                ModContent.ItemType<ImperialPanellingItem>(), ModContent.ItemType<ImperialFenceItem>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:ImperialWalls", ImperialWalls);
            
            RecipeGroup CinderblockWalls = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Cinderblock Walls", ModContent.ItemType<CinderblockWallItem>(), ModContent.ItemType<CinderblockFenceItem>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:CinderblockWalls", CinderblockWalls);

            RecipeGroup RedBrickWalls = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Red Brick Walls", ItemID.RedBrickWall, ModContent.ItemType<RedBrickFenceItem>(), ModContent.ItemType<RedBrickFenceFancyItem>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:RedBrickWalls", RedBrickWalls);

            RecipeGroup StoneBrickWalls = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Stone Brick Walls", ItemID.GrayBrickWall, ModContent.ItemType<StoneBrickFenceItem>(), ModContent.ItemType<StoneBrickFenceFancyItem>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:StoneBrickWalls", StoneBrickWalls);
        }
    }

    public class FoodRecipeGroups : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup Milks = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Milk", ItemID.MilkCarton, Mod.Find<ModItem>("Milk").Type);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Milks", Milks);

            RecipeGroup AllFruit = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Fruit", ItemID.Apple, ItemID.Apricot, ItemID.Grapefruit, ItemID.Lemon, ItemID.Peach, ItemID.Cherry, ItemID.Plum, ItemID.BlackCurrant,
                ItemID.Elderberry, ItemID.BloodOrange, ItemID.Rambutan, ItemID.Mango, ItemID.Pineapple, ItemID.Banana, ItemID.Coconut, ItemID.Dragonfruit, ItemID.Starfruit, ItemID.Pomegranate, Mod.Find<ModItem>("Cherry").Type, Mod.Find<ModItem>("Dragonfruit").Type, Mod.Find<ModItem>("AppleGreen").Type,
                Mod.Find<ModItem>("AppleRed").Type, Mod.Find<ModItem>("Apricot").Type, Mod.Find<ModItem>("Avocado").Type, Mod.Find<ModItem>("Banana").Type, Mod.Find<ModItem>("Berries").Type, Mod.Find<ModItem>("Breadfruit").Type, Mod.Find<ModItem>("Coconut").Type,
                Mod.Find<ModItem>("Grapefruit").Type, Mod.Find<ModItem>("Grapes").Type, Mod.Find<ModItem>("Guava").Type, Mod.Find<ModItem>("Kiwi").Type, Mod.Find<ModItem>("Lemon").Type, Mod.Find<ModItem>("Lime").Type,
                Mod.Find<ModItem>("Mango").Type, Mod.Find<ModItem>("Orange").Type, Mod.Find<ModItem>("Papaya").Type, Mod.Find<ModItem>("Passionfruit").Type, Mod.Find<ModItem>("Peach").Type, Mod.Find<ModItem>("Pear").Type, Mod.Find<ModItem>("Persimmon").Type,
                Mod.Find<ModItem>("Pineapple").Type, Mod.Find<ModItem>("Pomegranate").Type, Mod.Find<ModItem>("Strawberry").Type, Mod.Find<ModItem>("Watermelon").Type, Mod.Find<ModItem>("WatermelonSmall").Type);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:AllFruit", AllFruit);

            RecipeGroup Apples = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Apple", ItemID.Apple, Mod.Find<ModItem>("AppleRed").Type, Mod.Find<ModItem>("AppleGreen").Type);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Apples", Apples);

            RecipeGroup Peppers = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Pepper", ItemID.SpicyPepper, Mod.Find<ModItem>("Pepper").Type, Mod.Find<ModItem>("BellPepper").Type);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Peppers", Peppers);

            RecipeGroup Flours = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Flour", Mod.Find<ModItem>("Flour").Type, Mod.Find<ModItem>("FlourBig").Type, Mod.Find<ModItem>("FlourSmall").Type);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Flours", Flours);

            RecipeGroup Sugars = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Sugar", Mod.Find<ModItem>("Sugar").Type, Mod.Find<ModItem>("SugarBig").Type, Mod.Find<ModItem>("SugarSmall").Type);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Sugars", Sugars);
        }
    }
   public class WeaponsRecipeGroups : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup Weapons = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Decorative Weapon", ModContent.ItemType<Axe>(), ModContent.ItemType<AxeLong>(), ModContent.ItemType<MountedAxe>(), ModContent.ItemType<MountedAxeLong>(), ModContent.ItemType<WallAxe>(),
                ModContent.ItemType<GuanDao>(), ModContent.ItemType<GuanDaoLong>(),  ModContent.ItemType<MountedGuanDao>(), ModContent.ItemType<MountedGuanDaoLong>(),
                ModContent.ItemType<Hammer>(), ModContent.ItemType<HammerLong>(), ModContent.ItemType<MountedHammer>(), ModContent.ItemType<MountedHammerLong>(), 
                ModContent.ItemType<Pickaxe>(), ModContent.ItemType<PickaxeLong>(), ModContent.ItemType<MountedPick>(), ModContent.ItemType<MountedPickLong>(), 
                ModContent.ItemType<Pole>(), ModContent.ItemType<PoleLong>(), ModContent.ItemType<MountedPole>(), ModContent.ItemType<MountedPoleLong>(), 
                ModContent.ItemType<Spear>(), ModContent.ItemType<SpearLong>(), ModContent.ItemType<MountedSpear>(), ModContent.ItemType<MountedSpearLong>(),
                ModContent.ItemType<Sword>(), ModContent.ItemType<SwordScabbard>(), ModContent.ItemType<SwordStanding>(), ModContent.ItemType<SwordMounted>(), ModContent.ItemType<SwordMountedThin>(), ModContent.ItemType<SwordMountedScabbard>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Weapons", Weapons);

            RecipeGroup Axes = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Decorative Axe", ModContent.ItemType<Axe>(), ModContent.ItemType<AxeLong>(), ModContent.ItemType<MountedAxe>(), ModContent.ItemType<MountedAxeLong>(), ModContent.ItemType<WallAxe>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Axes", Axes);

            RecipeGroup GuanDaos = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Decorative GuanDao", ModContent.ItemType<GuanDao>(), ModContent.ItemType<GuanDaoLong>(),  ModContent.ItemType<MountedGuanDao>(), ModContent.ItemType<MountedGuanDaoLong>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:GuanDaos", GuanDaos);

            RecipeGroup Hammers = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Decorative Hammer", ModContent.ItemType<Hammer>(), ModContent.ItemType<HammerLong>(), ModContent.ItemType<MountedHammer>(), ModContent.ItemType<MountedHammerLong>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Hammers", Hammers);

            RecipeGroup Picks = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Decorative Pickaxe", ModContent.ItemType<Pickaxe>(), ModContent.ItemType<PickaxeLong>(), ModContent.ItemType<MountedPick>(), ModContent.ItemType<MountedPickLong>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Picks", Picks);

            RecipeGroup Polearms = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Decorative Polearm", ModContent.ItemType<Pole>(), ModContent.ItemType<PoleLong>(), ModContent.ItemType<MountedPole>(), ModContent.ItemType<MountedPoleLong>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Polearms", Polearms);
            
            RecipeGroup Spears = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Decorative Spear", ModContent.ItemType<Spear>(), ModContent.ItemType<SpearLong>(), ModContent.ItemType<MountedSpear>(), ModContent.ItemType<MountedSpearLong>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Spears", Spears);
            
            RecipeGroup Swords = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Decorative Sword", ModContent.ItemType<Sword>(), ModContent.ItemType<SwordScabbard>(), ModContent.ItemType<SwordStanding>(), ModContent.ItemType<SwordMounted>(), ModContent.ItemType<SwordMountedThin>(), ModContent.ItemType<SwordMountedScabbard>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Swords", Swords);

            RecipeGroup Guns = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Decorative Gun", ModContent.ItemType<GunStanding>(), ModContent.ItemType<FutureGun>(), ModContent.ItemType<FutureGunStanding>(), ModContent.ItemType<GunMounted>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Guns", Guns);
        }
    }

    public class RecipeGroupAdditions : ModSystem
    {
        public override void AddRecipeGroups()
        {
            base.AddRecipeGroups();
            {
                if (RecipeGroup.recipeGroups.TryGetValue(RecipeGroupID.Wood, out var woodGroup))
                {
                    woodGroup.ValidItems.Add(ModContent.ItemType<TeakWood>());

                    woodGroup.ValidItems.Add(ModContent.ItemType<SpringyWood>());
                    woodGroup.ValidItems.Add(ModContent.ItemType<SpringyWoodBlueItem>());
                    woodGroup.ValidItems.Add(ModContent.ItemType<SpringyWoodGreenItem>());

                    woodGroup.ValidItems.Add(ModContent.ItemType<TatteredWoodItem>());
                    woodGroup.ValidItems.Add(ModContent.ItemType<RepairedWoodItem>());
                }

                if (RecipeGroup.recipeGroups.TryGetValue(RecipeGroupID.Fruit, out var fruitGroup))
                {
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("AppleGreen").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("AppleRed").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Apricot").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Avocado").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Banana").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("BellPepper").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Berries").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("BloodOrange").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Cherry").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Dragonfruit").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Grapefruit").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Grapes").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Guava").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Kiwi").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Lemon").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Lime").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Mango").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Orange").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Papaya").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Passionfruit").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Peach").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Pear").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Pepper").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Persimmon").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Pineapple").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Plum").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Pomegranate").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Starfruit").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Strawberry").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("SugarApple").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("Watermelon").Type);
                    fruitGroup.ValidItems.Add(Mod.Find<ModItem>("WatermelonSmall").Type);
                }
            }
        }
    }
}