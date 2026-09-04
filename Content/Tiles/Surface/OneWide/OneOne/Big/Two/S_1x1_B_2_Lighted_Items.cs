using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.BakedGoods;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Two
{
    internal class S_1x1_B_2_Lighted_Items : ModItem
    {
        public class S_1x1_B_2_Lighted_Items_Loader : ILoadable
        {
            public void Load(Mod mod)
            {
                for (int i = 0; i < 4; i++)
                {
                    mod.AddContent(new S_1x1_B_2_Lighted_Items(i));
                }
            }

            public void Unload()
            {
            }
        }

        public enum S_1x1_B_2_Lighted_Style
        {
            BirthdayCakeSliceBlue = 0,
            BirthdayCakeSlicePink = 1,
            BirthdayCakeSliceGreen = 2,
            CupcakeBirthday = 3
        }

        protected override bool CloneNewInstances => true;
        private readonly int placeStyle;

        public override string Name => GetInternalNameFromStyle(placeStyle);

        public static string GetInternalNameFromStyle(int style)
        {
            return Enum.GetName(typeof(S_1x1_B_2_Lighted_Style), style);

            throw new Exception("Invalid style");
        }

        public S_1x1_B_2_Lighted_Items(int placeStyle)
        {
            this.placeStyle = placeStyle;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_2_Lighted>(), placeStyle);

            Item.width = 32;
            Item.height = 32;

            Item.maxStack = Item.CommonMaxStack;
            if (placeStyle == 0 | placeStyle == 1 | placeStyle == 2 | placeStyle == 3) //Birthday cakes/cupcakes
            {
                Item.value = Item.buyPrice(silver: 1, copper: 60);
            }
        }

        public override void AddRecipes()
        {
            //Shops
            if (placeStyle == 0 | placeStyle == 1 | placeStyle == 2 | placeStyle == 3) //Birthday cakes/cupcakes
            {
                CreateRecipe()
                    .AddIngredient(ItemID.SilverCoin, 1)
                    .AddIngredient(ItemID.CopperCoin, 60)
                    .AddTile(ModContent.TileType<ShopBread>())
                    .Register();
            }

            //Manual
            if (placeStyle == 0 | placeStyle == 1 | placeStyle == 2 | placeStyle == 3) //Birthday cakes/cupcakes
            {
                CreateRecipe(4)
                    .AddRecipeGroup("SquintlyFurnitureMod:Flours")
                    .AddRecipeGroup("SquintlyFurnitureMod:Sugars")
                    .AddRecipeGroup("SquintlyFurnitureMod:Eggs")
                    .AddIngredient(ItemID.Torch)
                    .AddTile(TileID.CookingPots)
                    .Register();
            }
            if (placeStyle == 0) //Birthday cakes/cupcakes
            {
                CreateRecipe(4)
                    .AddIngredient(ModContent.ItemType<BirthdayCakeBlue>())
                    .AddIngredient(ItemID.Torch)
                    .AddTile(TileID.CookingPots)
                    .Register();
            }
            if (placeStyle == 1) //Birthday cakes/cupcakes
            {
                CreateRecipe(4)
                    .AddIngredient(ModContent.ItemType<BirthdayCakePink>())
                    .AddIngredient(ItemID.Torch)
                    .AddTile(TileID.CookingPots)
                    .Register();
            }
            if (placeStyle == 2) //Birthday cakes/cupcakes
            {
                CreateRecipe(4)
                    .AddIngredient(ModContent.ItemType<BirthdayCakeGreen>())
                    .AddIngredient(ItemID.Torch)
                    .AddTile(TileID.CookingPots)
                    .Register();
            }
        }
    }
}