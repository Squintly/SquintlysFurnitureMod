using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Items.S_1x1_B_4_Item;
using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Items.S_1x1_B_Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Items.S_1x1_B_4_Item.S_1x1_B_4_Items;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Items.S_1x1_B_2_Item
{
    internal class S_1x1_B_2_Items : ModItem
    {
        public class S_1x1_B_2_Items_Loader : ILoadable
        {
            public void Load(Mod mod)
            {   
                for (int i = 0; i < 15; i++)
                {
                    mod.AddContent(new S_1x1_B_2_Items(i));
                }
                //mod.AddContent(new S_1x1_B_2_Items(0));
                //mod.AddContent(new S_1x1_B_2_Items(1));
                //mod.AddContent(new S_1x1_B_2_Items(2));
                //mod.AddContent(new S1x1_B_2_Items(3));
                //mod.AddContent(new S1x1_B_2_Items(4));
                //mod.AddContent(new S1x1_B_2_Items(5));
                //mod.AddContent(new S1x1_B_2_Items(6));
                //mod.AddContent(new S1x1_B_2_Items(7));
                //mod.AddContent(new S1x1_B_2_Items(8));
                //mod.AddContent(new S1x1_B_2_Items(9));
                //mod.AddContent(new S1x1_B_2_Items(10));
                //mod.AddContent(new S1x1_B_2_Items(11));
                //mod.AddContent(new S1x1_B_2_Items(12));
                //mod.AddContent(new S1x1_B_2_Items(13));
                //mod.AddContent(new S1x1_B_2_Items(14));
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
            WatermelonSmall = 14
        }

        protected override bool CloneNewInstances => true;
        private readonly int placeStyle;

        public override string Name => GetInternalNameFromStyle(placeStyle);

        public static string GetInternalNameFromStyle(int style)
        {
            return Enum.GetName(typeof(S_1x1_B_2_Style), style);

            throw new Exception("Invalid style");
            //if (style == 0)
            //{
            //    return "Avocado";
            //}
            //if (style == 1)
            //{
            //    return "Pear";
            //}
            //if (style == 2)
            //{
            //    return "Pomegranate";
            //}
            //if (style == 3)
            //{
            //    return "SugarApple";
            //}
            //if (style == 4)
            //{
            //    return "Strawberry";
            //}
            //if (style == 5)
            //{
            //    return "PassionFruit";
            //}
            //if (style == 6)
            //{
            //    return "GrapeFruit";
            //}
            //if (style == 7)
            //{
            //    return "Mango";
            //}
            //if (style == 8)
            //{
            //    return "CheeseSlice";
            //}
            //if (style == 9)
            //{
            //    return "Toothpaste";
            //}
            //if (style == 10)
            //{
            //    return "SpringRabbitsPlush";
            //}
            //if (style == 11)
            //{
            //    return "Scoops";
            //}
            //if (style == 12)
            //{
            //    return "Starfruit";
            //}
            //if (style == 13)
            //{
            //    return "Pepper";
            //}
            //if (style == 14)
            //{
            //    return "SmallWatermelon";
            //}

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

            if (placeStyle == 0) //Avocado
            {
            Item.value = Item.buyPrice(silver: 2);
            }
            
            else
            {
                Item.value = Item.buyPrice(silver: 2);
            }
        }
        public override void AddRecipes()
        {
            if (placeStyle == 0) //Avocado
            {
                CreateRecipe()
                    .AddRecipeGroup("SquintlyFurnitureMod:AllFruit")
                    .AddTile(TileID.WorkBenches)
                    .Register();
            }
        }
    }
}
