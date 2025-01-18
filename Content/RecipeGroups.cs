using SquintlysFurnitureMod.Content.Items.Blocks.Holiday.Spring;
using SquintlysFurnitureMod.Content.Items.Blocks.Themed.Egypt;
using SquintlysFurnitureMod.Content.Items.Blocks.VanillaPlus;
using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Fruit;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;
using SquintlysFurnitureMod.Content.Items.WallItems.Themed.Egypt;
using SquintlysFurnitureMod.Content.Items.WallItems.VanillaPlus;
using SquintlysFurnitureMod.Content.Items.WallItems.Woods.Teak;
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

        }
    }
    public class ModRecipeGroups : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup Festive = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Festive Block", ItemID.CandyCaneBlock, ItemID.GreenCandyCaneBlock, ItemID.PineTreeBlock);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Festive", Festive);

            RecipeGroup TeakWalls = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Teak Wall", ModContent.ItemType<TeakWallItem>(), ModContent.ItemType<TeakFenceItem>(),
                ModContent.ItemType<TeakFenceSlatItem>(), ModContent.ItemType<TeakFenceSolidItem>(), ModContent.ItemType<TeakFenceLatticeItem>(), ModContent.ItemType<TeakPoleItem>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:TeakWalls", TeakWalls);

            RecipeGroup HieroBlocks = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Sandstone Block/Wall",
                ModContent.ItemType<HieroBlock1Item>(), ModContent.ItemType<HieroBlock2Item>(), ModContent.ItemType<HieroBlock3Item>(), ModContent.ItemType<HieroBlock4Item>(),
                ModContent.ItemType<FadedHieroBlock1Item>(), ModContent.ItemType<FadedHieroBlock2Item>(), ModContent.ItemType<FadedHieroBlock3Item>(), ModContent.ItemType<FadedHieroBlock4Item>(),
                ModContent.ItemType<HieroWall1Item>(), ModContent.ItemType<HieroWall2Item>(), ModContent.ItemType<HieroWall3Item>(), ModContent.ItemType<HieroWall4Item>(), ModContent.ItemType<HieroWallSmallItem>(),
                ModContent.ItemType<FadedHieroWall1Item>(), ModContent.ItemType<FadedHieroWall2Item>(), ModContent.ItemType<FadedHieroWall3Item>(), ModContent.ItemType<FadedHieroWall4Item>(), ModContent.ItemType<FadedHieroWallSmallItem>(),
                ModContent.ItemType<PolishedSandstoneBrickItem>(), ModContent.ItemType<PolishedSandstoneBrickWallItem>(), ItemID.Sandstone, ItemID.SandstoneBrick, ItemID.SandstoneBrickWall, ItemID.SandstoneSlab);
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:HieroBlocks", HieroBlocks);
        }
    }
    public class FoodRecipeGroups : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup Milks = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Milk", ItemID.MilkCarton, ModContent.ItemType<Milk>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Milks", Milks);

            RecipeGroup AllFruit = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Fruit", ItemID.Apple, ItemID.Apricot, ItemID.Grapefruit, ItemID.Lemon, ItemID.Peach, ItemID.Cherry, ItemID.Plum, ItemID.BlackCurrant,
                ItemID.Elderberry, ItemID.BloodOrange, ItemID.Rambutan, ItemID.Mango, ItemID.Pineapple, ItemID.Banana, ItemID.Coconut, ItemID.Dragonfruit, ItemID.Starfruit, ItemID.Pomegranate, ModContent.ItemType<Cherry>(), ModContent.ItemType<Dragonfruit>(), ModContent.ItemType<AppleGreen>(),
                ModContent.ItemType<AppleRed>(), ModContent.ItemType<Apricot>(), ModContent.ItemType<Avocado>(), ModContent.ItemType<Banana>(), ModContent.ItemType<Berries>(), ModContent.ItemType<Breadfruit>(), ModContent.ItemType<Coconut>(),
                ModContent.ItemType<Grapefruit>(), ModContent.ItemType<Grapes>(), ModContent.ItemType<Guava>(), ModContent.ItemType<Kiwi>(), ModContent.ItemType<Lemon>(), ModContent.ItemType<Lime>(),
                ModContent.ItemType<Mango>(), ModContent.ItemType<Orange>(), ModContent.ItemType<Papaya>(), ModContent.ItemType<Passionfruit>(), ModContent.ItemType<Peach>(), ModContent.ItemType<Pear>(), ModContent.ItemType<Persimmon>(),
                ModContent.ItemType<Pineapple>(), ModContent.ItemType<Pomegranate>(), ModContent.ItemType<Strawberry>(), ModContent.ItemType<Watermelon>(), ModContent.ItemType<WatermelonSmall>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:AllFruit", AllFruit);

            RecipeGroup Apples = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Apple", ItemID.Apple, ModContent.ItemType<AppleRed>(), ModContent.ItemType<AppleGreen>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Apples", Apples);

            RecipeGroup Peppers = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Pepper", ItemID.SpicyPepper, ModContent.ItemType<Pepper>(), ModContent.ItemType<BellPepper>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Peppers", Peppers);

            RecipeGroup Flours = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Flour", ModContent.ItemType<Flour>(), ModContent.ItemType<FlourBig>(), ModContent.ItemType<FlourSmall>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Flours", Flours);

            RecipeGroup Sugars = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Sugar", ModContent.ItemType<Sugar>(), ModContent.ItemType<SugarBig>(), ModContent.ItemType<SugarSmall>());
            RecipeGroup.RegisterGroup("SquintlyFurnitureMod:Sugars", Sugars);
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
                }

                if (RecipeGroup.recipeGroups.TryGetValue(RecipeGroupID.Fruit, out var fruitGroup))
                {
                    fruitGroup.ValidItems.Add(ModContent.ItemType<AppleGreen>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<AppleRed>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Apricot>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Avocado>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Banana>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<BellPepper>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Berries>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<BloodOrange>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Cherry>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Dragonfruit>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Grapefruit>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Grapes>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Guava>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Kiwi>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Lemon>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Lime>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Mango>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Orange>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Papaya>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Passionfruit>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Peach>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Pear>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Pepper>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Persimmon>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Pineapple>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Plum>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Pomegranate>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Starfruit>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Strawberry>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<SugarApple>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<Watermelon>());
                    fruitGroup.ValidItems.Add(ModContent.ItemType<WatermelonSmall>());
                }
            }
        }
    }
}