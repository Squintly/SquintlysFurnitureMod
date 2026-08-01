using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Furniture.Misc.Mirrors.Normal.Mirrors_1;
using SquintlysFurnitureMod.Content.Furniture.Misc.Mirrors.Normal.Mirrors_1.Items;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Items.S_1x1_B_Item
{
    internal class S_1x1_B_Items : ModItem
    {
        public class S_1x1_B_Items_Loader : ILoadable
        {
            public void Load(Mod mod)
            {
                for (int i = 0; i < 8; i++)
                {
                    mod.AddContent(new S_1x1_B_Items(i));
                }
            }

            public void Unload()
            {
            }
        }
        public enum s_1x1_B_Style
        {
            Dragonfruit = 0, //0
            Cherry = 1, //1
            PepperMill = 2, //2
            WateringCan = 3, //3
            Yeast = 4, //4
            Salt = 5, //5
            Sugar = 6, //6
            Flour = 7 //7
        }

        protected override bool CloneNewInstances => true;
        private readonly int placeStyle;

        public override string Name => GetInternalNameFromStyle(placeStyle);

        public static string GetInternalNameFromStyle(int style)
        {
            
            return Enum.GetName(typeof(s_1x1_B_Style), style);

            throw new Exception("Invalid style");
        }

        public S_1x1_B_Items(int placeStyle)
        {
            this.placeStyle = placeStyle;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B>(), placeStyle);

            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 2);
            Item.maxStack = Item.CommonMaxStack;
        }

        /*public override void AddRecipes()
        {
            if (placeStyle == 0) //ImperialMirror
            {
                CreateRecipe()
                .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 5)
                .AddIngredient(ItemID.Glass, 3)
                .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
                .AddTile(TileID.WorkBenches)
                .Register();
            }
            if (placeStyle == 1) //TatteredMirror
            {
                CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 5)
                .AddIngredient(ItemID.Glass, 3)
                .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
                .AddTile(TileID.WorkBenches)
                .AddCondition(Condition.InGraveyard)
                .Register();
            }
            if (placeStyle == 2) //RepairedMirror
            {
                CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddIngredient(ItemID.Glass, 1)
                .AddRecipeGroup("SquintlyFurnitureMod:SilverBar")
                .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(1)).Type)
                .AddTile(TileID.WorkBenches)
                .Register();
            }
            if (placeStyle == 3) //StoneBrickMirror
            {
                CreateRecipe()
                .AddIngredient(ItemID.GrayBrick, 5)
                .AddIngredient(ItemID.Glass, 3)
                .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
                .AddTile(ModContent.TileType<BrickOven>())
                .Register();
            }
            if (placeStyle == 4) //RedBrickMirror
            {
                CreateRecipe()
                .AddIngredient(ItemID.RedBrick, 5)
                .AddIngredient(ItemID.Glass, 3)
                .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
                .AddTile(ModContent.TileType<BrickOven>())
                .Register();
            }
            if (placeStyle == 5) //CinderblockMirror
            {
                CreateRecipe()
                .AddIngredient(ModContent.ItemType<CinderblockItem>(), 5)
                .AddIngredient(ItemID.Glass, 3)
                .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
                .AddTile(ModContent.TileType<BrickOven>())
                .Register();
            }
        }*/
    }
}
