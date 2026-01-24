//using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
//using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
//using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
//using System;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.Lanterns.Lanterns_1.Items;
//    internal class Lanterns_1_Items : ModItem
//    {
//        public class Lanterns_1_ItemsLoader : ILoadable
//        {
//            public void Load(Mod mod)
//            {
//            mod.AddContent(new Lanterns_1_Items(0)); //ImperialLantern
//            mod.AddContent(new Lanterns_1_Items(1)); //TatteredLantern
//            mod.AddContent(new Lanterns_1_Items(2)); //RepairedLantern
//            mod.AddContent(new Lanterns_1_Items(3)); //StoneBrickLantern
//            mod.AddContent(new Lanterns_1_Items(4)); //RedBrickLantern
//            mod.AddContent(new Lanterns_1_Items(5)); //CinderBlockLantern
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
//                return "ImperialLantern";
//            }
//            if (style == 1)
//            {
//                return "TatteredLantern";
//            }
//            if (style == 2)
//            {
//                return "RepairedLantern";
//            }
//            if (style == 3)
//            {
//                return "StoneBrickLantern";
//            }
//            if (style == 4)
//            {
//                return "RedBrickLantern";
//            }
//            if (style == 5)
//            {
//                return "CinderBlockLantern";
//            }

//        throw new Exception("Invalid style");
//        }

//        public Lanterns_1_Items(int placeStyle)
//        {
//            this.placeStyle = placeStyle;
//        }

//        public override void SetDefaults()
//        {
//            Item.DefaultToPlaceableTile(ModContent.TileType<Lanterns_1>(), placeStyle);

//            Item.width = 32;
//            Item.height = 32;

//            Item.value = Item.buyPrice(copper: 30);
//            Item.maxStack = Item.CommonMaxStack;
//        }
//        public override void AddRecipes()
//        {
//            if (placeStyle == 0) //ImperialLantern
//            {
//                CreateRecipe()
//                .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 6)
//                .AddIngredient(ItemID.Torch)
//                .AddTile(TileID.WorkBenches)
//                .Register();
//            }
//            if (placeStyle == 1) //TatteredLantern
//            {
//                CreateRecipe()
//                .AddRecipeGroup(RecipeGroupID.Wood, 6)
//                .AddIngredient(ItemID.Torch)
//                .AddTile(TileID.WorkBenches)
//                .AddCondition(Condition.InGraveyard)
//                .Register();
//            }
//            if (placeStyle == 2) //RepairedLantern
//            {
//                CreateRecipe()
//                .AddRecipeGroup(RecipeGroupID.Wood, 3)
//                .AddIngredient(ItemID.Torch)
//                .AddIngredient(Mod, "TatteredLantern")
//                .AddTile(TileID.WorkBenches)
//                .Register();
//            }
//            if (placeStyle == 3) //StoneBrickLantern
//            {
//                CreateRecipe()
//                .AddIngredient(ItemID.GrayBrick, 6)
//                .AddIngredient(ItemID.Torch)
//                .AddTile(ModContent.TileType<BrickOven>())
//                .Register();
//            }
//            if (placeStyle == 4) //RedBrickLantern
//            {
//                CreateRecipe()
//                .AddIngredient(ItemID.RedBrick, 6)
//                .AddIngredient(ItemID.Torch)
//                .AddTile(ModContent.TileType<BrickOven>())
//                .Register();
//            }
//            if (placeStyle == 5) //CinderBlockLantern
//            {
//                CreateRecipe()
//                .AddIngredient(ModContent.ItemType<CinderblockItem>(), 6)
//                .AddIngredient(ItemID.Torch)
//                .AddTile(ModContent.TileType<BrickOven>())
//                .Register();
//            }
//        }
//    }