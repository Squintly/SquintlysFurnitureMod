//using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
//using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
//using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
//using System;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.Spotlights.Spotlights_4.Items;
//    internal class Spotlights_1_Items : ModItem
//    {
//        public class Spotlights_1_ItemsLoader : ILoadable
//        {
//            public void Load(Mod mod)
//            {
//            mod.AddContent(new Spotlights_1_Items(0)); //ImperialSpotlight
//            mod.AddContent(new Spotlights_1_Items(1)); //TatteredSpotlight
//            mod.AddContent(new Spotlights_1_Items(2)); //RepairedSpotlight
//            mod.AddContent(new Spotlights_1_Items(3)); //StoneBrickSpotlight
//            mod.AddContent(new Spotlights_1_Items(4)); //RedBrickSpotlight
//            mod.AddContent(new Spotlights_1_Items(5)); //CinderBlockSpotlight
//            }
//            public void Unload()
//            {
//            }
//        }
//        protected override bool CloneNewInstances => true;
//        private readonly int placeStyle;

//        public override string Name => GetInternalNameFromStyle(placeStyle);

//        public static string GetInternalNameFromStyle(int style)
//        {
//            if (style == 0)
//            {
//                return "ImperialSpotlight";
//            }
//            if (style == 1)
//            {
//                return "TatteredSpotlight";
//            }
//            if (style == 2)
//            {
//                return "RepairedSpotlight";
//            }
//            if (style == 3)
//            {
//                return "StoneBrickSpotlight";
//            }
//            if (style == 4)
//            {
//                return "RedBrickSpotlight";
//            }
//            if (style == 5)
//            {
//                return "CinderBlockSpotlight";
//            }

//        throw new Exception("Invalid style");
//        }

//        public Spotlights_1_Items(int placeStyle)
//        {
//            this.placeStyle = placeStyle;
//        }

//        public override void SetDefaults()
//        {
//            Item.DefaultToPlaceableTile(ModContent.TileType<Spotlights_1>(), placeStyle);

//            Item.width = 32;
//            Item.height = 32;

//            Item.value = Item.buyPrice(copper: 60);
//            Item.maxStack = Item.CommonMaxStack;
//        }
//        public override void AddRecipes()
//        {
//            if (placeStyle == 0) //ImperialSpotlight
//            {
//                CreateRecipe()
//                .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 5)
//                .AddIngredient(ItemID.Torch, 3)
//                .AddTile(TileID.WorkBenches)
//                .Register();
//            }
//            if (placeStyle == 1) //TatteredSpotlight
//            {
//                CreateRecipe()
//                .AddRecipeGroup(RecipeGroupID.Wood, 5)
//                .AddIngredient(ItemID.Torch, 3)
//                .AddTile(TileID.WorkBenches)
//                .AddCondition(Condition.InGraveyard)
//                .Register();
//            }
//            if (placeStyle == 2) //RepairedSpotlight
//            {
//                CreateRecipe()
//                .AddRecipeGroup(RecipeGroupID.Wood, 3)
//                .AddIngredient(ItemID.Torch, 3)
//                .AddIngredient(Mod, "TatteredSpotlight")
//                .AddTile(TileID.WorkBenches)
//                .Register();
//            }
//            if (placeStyle == 3) //StoneBrickSpotlight
//            {
//                CreateRecipe()
//                .AddIngredient(ItemID.GrayBrick, 5)
//                .AddIngredient(ItemID.Torch, 3)
//                .AddTile(ModContent.TileType<BrickOven>())
//                .Register();
//            }
//            if (placeStyle == 4) //RedBrickSpotlight
//            {
//                CreateRecipe()
//                .AddIngredient(ItemID.RedBrick, 5)
//                .AddIngredient(ItemID.Torch, 3)
//                .AddTile(ModContent.TileType<BrickOven>())
//                .Register();
//            }
//            if (placeStyle == 5) //CinderBlockSpotlight
//            {
//                CreateRecipe()
//                .AddIngredient(ModContent.ItemType<CinderblockItem>(), 5)
//                .AddIngredient(ItemID.Torch, 3)
//                .AddTile(ModContent.TileType<BrickOven>())
//                .Register();
//            }
//        }
//    }