using SquintlysFurnitureMod.Content.Items.Blocks.Holiday;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Three
{
    internal class S_1x1_B_3_Items : ModItem
    {
        public S_1x1_B_3_Items(int placeStyle)
        {
            this.placeStyle = placeStyle;
        }

        public class S_1x1_B_3_Items_Loader : ILoadable
        {
            public void Load(Mod mod)
            {
                for (int i = 0; i < 11; i++)
                {
                    mod.AddContent(new S_1x1_B_3_Items(i));
                }
            }

            public void Unload()
            {
            }
        }

        public enum S_1x1_B_3_Style
        {
        Peach = 0,
        Apricot = 1,
        Butter = 2,
        Pineapple = 3,
        ChocolateEggs = 4,
        Eggs = 5,
        CarrotsBig = 6,
        Plum = 7,
        BloodOrange = 8,
        BreadPanSmall = 9,
        EggsBrown = 10
        }

        protected override bool CloneNewInstances => true;
        private readonly int placeStyle;

        public override string Name => GetInternalNameFromStyle(placeStyle);

        public static string GetInternalNameFromStyle(int style)
        {
            return Enum.GetName(typeof(S_1x1_B_3_Style), style);

            throw new Exception("Invalid style");
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_3>(), placeStyle);

            Item.width = 32;
            Item.height = 32;

            Item.maxStack = Item.CommonMaxStack;
            if (placeStyle == 0 | placeStyle == 1 | placeStyle == 3 | placeStyle == 7 | placeStyle == 8) //Peach, apricot, pineapple, plum, blood orange
            {
                Item.value = Item.buyPrice(silver: 20);
            }
            if (placeStyle == 4)
            {
                Item.value = Item.buyPrice(copper: 50);
            }
            if (placeStyle == 5 | placeStyle == 10)
            {
                Item.value = Item.buyPrice(silver: 5);
            }
            if (placeStyle == 9)
            {
                Item.value = Item.buyPrice(silver: 6);
            }
        }
        public override void AddRecipes()
        {
            if (placeStyle == 0 | placeStyle == 1 | placeStyle == 3 | placeStyle == 7 | placeStyle == 8) //Peach, apricot, pineapple, plum, blood orange
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
            if (placeStyle == 4) //Chocolate eggs
            {
                CreateRecipe()
                    .AddIngredient(ModContent.ItemType<ChocolateBlockItem>(), 1)
                    .AddTile(ModContent.TileType<CuttingBoard>())
                    .Register();
            }
            if (placeStyle == 5 | placeStyle == 10) //eggs, brown eggs
            {
                CreateRecipe()
                    .AddIngredient(ItemID.SilverCoin, 5)
                    .AddTile(ModContent.TileType<ShopGoods>())
                    .Register();
            }
            if (placeStyle == 9) //bread pan
            {
                CreateRecipe()
                    .AddRecipeGroup(RecipeGroupID.IronBar, 2)
                    .AddIngredient(Mod.Find<ModItem>("Flour").Type)
                    .AddTile(ModContent.TileType<Smelter>())
                    .Register();

                CreateRecipe()
                    .AddIngredient(ItemID.SilverCoin, 6)
                    .AddTile(ModContent.TileType<ShopBread>())
                    .Register();
            }
        }
    }
}