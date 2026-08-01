using SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Items.S_1x1_B_Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            }

            public void Unload()
            {
            }
        }
        public enum s_1x1_B_2_Style
        {
            Avocado = 0,
            Pear = 1,
            Pomegranate = 2,
            SugarApple = 3,
            Strawberry = 4,
            PassionFruit = 5,
            GrapeFruit = 6,
            Mango = 7,
            CheeseSlice = 8,
            Toothpaste = 9,
            SpringRabbitsPlush = 10,
            Scoops = 11,
            Starfruit = 12,
            Pepper = 13,
            SmallWatermelon = 14
        }

        protected override bool CloneNewInstances => true;
        private readonly int placeStyle;

        public override string Name => GetInternalNameFromStyle(placeStyle);

        public static string GetInternalNameFromStyle(int style)
        {

            return Enum.GetName(typeof(s_1x1_B_2_Style), style);

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

            Item.value = Item.buyPrice(silver: 2);
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}
