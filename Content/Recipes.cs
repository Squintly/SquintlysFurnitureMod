using SquintlysFurnitureMod.Content.Items.Blocks.Themed.Egypt;
using SquintlysFurnitureMod.Content.Items.Blocks.VanillaPlus;
using SquintlysFurnitureMod.Content.Items.WallItems.Other;
using SquintlysFurnitureMod.Content.Items.WallItems.Themed.Egypt;
using SquintlysFurnitureMod.Content.Items.WallItems.VanillaPlus;
using SquintlysFurnitureMod.Content.Items.WallItems.Woods.Teak;
using SquintlysFurnitureMod.Content.WallTiles.Themed.Egypt;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content
{
    public class Recipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.Glass);
            recipe.AddIngredient(ModContent.ItemType<FrostedGlassItem>(), 4);
            recipe.Register();
        }

        public override void AddRecipeGroups()
        {
            RecipeGroup Meat = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Meat", ItemID.Steak, ItemID.Bacon, ItemID.BBQRibs, ItemID.ChickenNugget, ItemID.HamBat);
            RecipeGroup.RegisterGroup("SquintlysFurnitureMod:Meat", Meat);

            RecipeGroup GoldBar = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBar)}", ItemID.GoldBar, ItemID.PlatinumBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.GoldBar), GoldBar);

            RecipeGroup CopperBar = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperBar)}", ItemID.CopperBar, ItemID.TinBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperBar), CopperBar);

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



        //public static RecipeGroup Meat;
        //public static RecipeGroup GoldBar;

        //public override void Unload()
        //{
        //    Meat = null;
        //    GoldBar = null;
        //}
        //public override void AddRecipeGroups()
        //{
        //    Meat = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Steak)}", ItemID.Steak, ItemID.Bacon, ItemID.BBQRibs, ItemID.ChickenNugget);
        //    RecipeGroup.RegisterGroup(nameof(ItemID.Steak), Meat);

        //    GoldBar = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBar)}", ItemID.GoldBar, ItemID.PlatinumBar);
        //    RecipeGroup.RegisterGroup(nameof(ItemID.GoldBar), GoldBar);
        //}
    }
}