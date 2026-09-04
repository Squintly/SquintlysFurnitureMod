using SquintlysFurnitureMod.Content.Items.Materials;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.One;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Two
{
    internal class S_1x1_B_2_Items : ModItem
    {
        public class S_1x1_B_2_Items_Loader : ILoadable
        {
            public void Load(Mod mod)
            {
                for (int i = 0; i < 18; i++)
                {
                    mod.AddContent(new S_1x1_B_2_Items(i));
                }
            }

            public void Unload()
            {
            }
        }

        public enum S_1x1_B_2_Style
        {
            Avocado = 0,
            Pear = 1,
            Pomegranate = 2,
            SugarApple = 3,
            Strawberry = 4,
            Passionfruit = 5,
            Grapefruit = 6,
            Mango = 7,
            CheeseSlice = 8,
            Toothpaste = 9,
            SpringRabbitsPlush = 10,
            Scoops = 11,
            Starfruit = 12,
            Pepper = 13,
            WatermelonSmall = 14,
            PaintBrush = 15,
            PaintPalette = 16,
            SpoonJar = 17
        }

        protected override bool CloneNewInstances => true;
        private readonly int placeStyle;

        public override string Name => GetInternalNameFromStyle(placeStyle);

        public static string GetInternalNameFromStyle(int style)
        {
            return Enum.GetName(typeof(S_1x1_B_2_Style), style);

            throw new Exception("Invalid style");
        }

        public S_1x1_B_2_Items(int placeStyle)
        {
            this.placeStyle = placeStyle;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_2>(), placeStyle);

            Item.width = 32;
            Item.height = 32;

            Item.maxStack = Item.CommonMaxStack;

            if (placeStyle == 0 | placeStyle == 1 | placeStyle == 2 | placeStyle == 3 | placeStyle == 4 | placeStyle == 5 | placeStyle == 6 | placeStyle == 7 | //Avocado, Pear, Pomegranate, SugarApple, Strawberry, Passionfruit, Grapefruit, Mango
             placeStyle == 12 | placeStyle == 13) //Starfruit, Pepper
            {
                Item.value = Item.buyPrice(silver: 20);
            }
            if (placeStyle == 8) //Cheese Slice
            {
                Item.value = Item.buyPrice(silver: 5);
            }
            if (placeStyle == 9) //Toothpaste
            {
                Item.value = Item.buyPrice(silver: 2, copper: 70);
            }
            if (placeStyle == 10) //Rabbit plush
            {
                Item.value = Item.buyPrice(silver: 10);
            }
            if (placeStyle == 11) //Scoops
            {
                Item.value = Item.buyPrice(silver: 12);
            }
            if (placeStyle == 15) //Paint Brushes
            {
                Item.value = Item.buyPrice(silver: 2);
            }
            if (placeStyle == 16 | placeStyle == 17) //Paint Brushes, Spoon jar
            {
                Item.value = Item.buyPrice(copper: 5);
            }
        }

        public override void AddRecipes()
        {
            if (placeStyle == 0 | placeStyle == 1 | placeStyle == 2 | placeStyle == 3 | placeStyle == 4 |  //Avocado, Pear, Pomegranate, SugarApple, Strawberry,
            placeStyle == 5 | placeStyle == 6 | placeStyle == 7 | placeStyle == 12 | placeStyle == 13 | //Passionfruit, Grapefruit, Mango, Starfruit
            placeStyle == 14 )
            { 
                CreateRecipe()
                    .AddIngredient(ItemID.SilverCoin, 20)
                    .AddTile(ModContent.TileType<ShopFruit>())
                    .Register();

                CreateRecipe()
                    .AddRecipeGroup("SquintlyFurnitureMod:AllFruit")
                    .AddTile(ModContent.TileType<CuttingBoard>())
                    .Register();
            }
            if (placeStyle == 8) //Cheese
            {
                CreateRecipe()
                    .AddIngredient(ItemID.SilverCoin, 5)
                    .AddTile(ModContent.TileType<ShopGoods>())
                    .Register();

                CreateRecipe(4)
                    .AddIngredient(ItemID.MilkCarton)
                    .AddTile(ModContent.TileType<Fridges>())
                    .Register();

                CreateRecipe(4)
                    .AddIngredient(Mod.Find<ModItem>("CheeseWheel").Type) //Cheesewheels
                    .AddTile(ModContent.TileType<CuttingBoard>())
                    .Register();
            }
            if (placeStyle == 9) //Toothpase
            {
                CreateRecipe()
                    .AddIngredient(ItemID.SilverCoin, 20)
                    .AddTile(ModContent.TileType<ShopGoods>())
                    .Register();

                CreateRecipe()
                    .AddIngredient(ModContent.ItemType<Plastic>(), 2)
                    .AddIngredient(Mod.Find<ModItem>("Salt").Type)
                    .AddIngredient(ItemID.Shiverthorn)
                    .AddTile(ModContent.TileType<Mortar>())
                    .Register();
            }
            if (placeStyle == 10) //Rabbit Plush
            {
                CreateRecipe()
                    .AddIngredient(ItemID.Silk, 4)
                    .AddIngredient(ModContent.ItemType<ThreadItem>(), 4)
                    .AddTile(ModContent.TileType<SewingBox>())
                    .Register();
            }
            if (placeStyle == 11) //Scoops
            {
                CreateRecipe()
                    .AddRecipeGroup(RecipeGroupID.IronBar, 4)
                    .AddRecipeGroup(RecipeGroupID.Wood, 4)
                    .AddTile(ModContent.TileType<Worktable>())
                    .Register();
            }
            if (placeStyle == 15) //Paint Brushes
            {
                CreateRecipe()
                    .AddIngredient(ItemID.SilverCoin, 2)
                    .AddTile(ModContent.TileType<ShopPaint>())
                    .Register();

                CreateRecipe()
                    .AddIngredient(ItemID.Silk)
                    .AddRecipeGroup(RecipeGroupID.Wood)
                    .AddTile(ModContent.TileType<Worktable>())
                    .Register();
            }
            if (placeStyle == 16) //Paint Palette
            {
                CreateRecipe()
                    .AddIngredient(ItemID.CopperCoin, 5)
                    .AddTile(ModContent.TileType<ShopPaint>())
                    .Register();

                CreateRecipe()
                    .AddRecipeGroup("SquintlyFurnitureMod:Paint")
                    .AddRecipeGroup(RecipeGroupID.Wood)
                    .AddTile(ModContent.TileType<Worktable>())
                    .Register();
            }
            if (placeStyle == 16) //Spoon jar
            {
                CreateRecipe()
                    .AddIngredient(ItemID.CopperCoin, 5)
                    .AddTile(ModContent.TileType<ShopBread>())
                    .Register();

                CreateRecipe()
                    .AddRecipeGroup(RecipeGroupID.Wood)
                    .AddIngredient(ItemID.ClayBlock)
                    .AddTile(ModContent.TileType<Worktable>())
                    .Register();
            }
        }
    }
}