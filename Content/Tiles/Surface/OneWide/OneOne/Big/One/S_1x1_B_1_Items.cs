using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.One
{
    internal class S_1x1_B_1_Items : ModItem
    {
        public class S_1x1_B_1_Items_Loader : ILoadable
        {
            public void Load(Mod mod)
            {
                for (int i = 0; i < 9; i++)
                {
                    mod.AddContent(new S_1x1_B_1_Items(i));
                }
            }

            public void Unload()
            {
            }
        }

        public enum S_1x1_B_1_Style
        {
            Dragonfruit = 0,
            Cherry = 1,
            PepperMill = 2,
            WateringCan = 3,
            Yeast = 4,
            Salt = 5,
            Sugar = 6,
            Flour = 7,
            TackleBox = 8
        }

        protected override bool CloneNewInstances => true;
        private readonly int placeStyle;

        public override string Name => GetInternalNameFromStyle(placeStyle);

        public static string GetInternalNameFromStyle(int style)
        {
            return Enum.GetName(typeof(S_1x1_B_1_Style), style);

            throw new Exception("Invalid style");
        }

        public S_1x1_B_1_Items(int placeStyle)
        {
            this.placeStyle = placeStyle;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_1>(), placeStyle);

            Item.width = 32;
            Item.height = 32;
            
            Item.maxStack = Item.CommonMaxStack;

            if (placeStyle == 0 | placeStyle == 1 | placeStyle == 2) //Dragonfruit, Cherry, Pepper Mill
            { 
                Item.value = Item.buyPrice(silver: 20);
            }
            if (placeStyle == 3 | placeStyle == 8) //Watering can, Tackle Box
            {
                Item.value = Item.buyPrice(silver: 15);
            }
            if (placeStyle == 4 | placeStyle == 5 | placeStyle == 6 | placeStyle == 7) //yeast, salt, sugar, flour
            {
                Item.value = Item.buyPrice(copper: 50);
            }
        }

        public override void AddRecipes()
        {   //Shops
            if (placeStyle == 0 | placeStyle == 1 | placeStyle == 2) //Dragonfruit, Chetty, Pepper Mill
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
            if (placeStyle == 2) //Pepper Mill
            {
                CreateRecipe()
                    .AddRecipeGroup(RecipeGroupID.Wood, 2)
                    .AddRecipeGroup("SquintlyFurnitureMod:Peppers")
                    .AddTile(ModContent.TileType<CuttingBoard>())
                    .Register();
            }
            if (placeStyle == 4 | placeStyle == 5 | placeStyle == 6 | placeStyle == 7) //Yeast, Salt, Sugar, Flour
            { 
                CreateRecipe()
                    .AddIngredient(ItemID.CopperCoin, 50)
                    .AddTile(ModContent.TileType<ShopGoods>())
                    .Register();
            }
            if (placeStyle == 3 | placeStyle == 8) //Watering Can, Tackle Box
            {
                CreateRecipe()
                    .AddRecipeGroup(RecipeGroupID.IronBar, 5)
                    .AddTile(ModContent.TileType<Smelter>())
                    .AddTile(TileID.Anvils)
                    .Register();
            }
            if (placeStyle == 3) //Watering Can
            { 
                CreateRecipe()
                    .AddIngredient(ItemID.SilverCoin, 15)
                    .AddTile(ModContent.TileType<ShopFlowers>())
                    .Register();
            }
            if (placeStyle == 8) //Tackle Box
            { 
                CreateRecipe()
                    .AddIngredient(ItemID.SilverCoin, 15)
                    .AddTile(ModContent.TileType<ShopFish>())
                    .Register();
            }
        }
    }
}