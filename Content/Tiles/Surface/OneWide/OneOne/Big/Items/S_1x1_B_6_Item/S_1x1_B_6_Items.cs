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
    internal class S_1x1_B_6_Items : ModItem
    {
        public class S_1x1_B_6_Items_Loader : ILoadable
        {
            public void Load(Mod mod)
            {
                for (int i = 0; i < 4; i++)
                {
                    mod.AddContent(new S_1x1_B_6_Items(i));
                }
            }

            public void Unload()
            {
            }
        }
        public enum s_1x1_B_6_Style
        {
            Milk = 0,
            Grapes = 1,
            SpringChick = 2,
            BellPepper = 3,
        }

        protected override bool CloneNewInstances => true;
        private readonly int placeStyle;

        public override string Name => GetInternalNameFromStyle(placeStyle);

        public static string GetInternalNameFromStyle(int style)
        {

            return Enum.GetName(typeof(s_1x1_B_6_Style), style);

            throw new Exception("Invalid style");
        }

        public S_1x1_B_6_Items(int placeStyle)
        {
            this.placeStyle = placeStyle;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_6>(), placeStyle);

            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 2);
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}
