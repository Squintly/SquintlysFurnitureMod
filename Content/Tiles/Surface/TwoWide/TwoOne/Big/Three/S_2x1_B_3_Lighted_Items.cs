using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.TwoWide.TwoOne.Big.Three
{
    internal class S_2x1_B_3_Lighted_Items : ModItem
    {
        public class S_2x1_B_3_Lighted_Items_Loader : ILoadable
        {
            public void Load(Mod mod)
            {
                for (int i = 0; i < 1; i++)
                {
                    mod.AddContent(new S_2x1_B_3_Lighted_Items(i));
                }
            }

            public void Unload()
            {
            }
        }

        public enum S_2x1_B_3_Lighted_Style
        {
            BirthdayCake = 0
        }

        protected override bool CloneNewInstances => true;
        private readonly int placeStyle;

        public override string Name => GetInternalNameFromStyle(placeStyle);

        public static string GetInternalNameFromStyle(int style)
        {
            return Enum.GetName(typeof(S_2x1_B_3_Lighted_Style), style);

            throw new Exception("Invalid style");
        }

        public S_2x1_B_3_Lighted_Items(int placeStyle)
        {
            this.placeStyle = placeStyle;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<S_2x1_B_3_Lighted>(), placeStyle);

            Item.width = 32;
            Item.height = 32;

            Item.maxStack = Item.CommonMaxStack;
            if (placeStyle == 0) //Birthday cakes
            {
                Item.value = Item.buyPrice(silver: 3);
            }
        }

        public override void AddRecipes()
        {
            //Shops
            if (placeStyle == 0) //Birthday cakes
            {
                CreateRecipe()
                    .AddIngredient(ItemID.SilverCoin, 3)
                    .AddTile(ModContent.TileType<ShopBread>())
                    .Register();

                CreateRecipe()
                    .AddRecipeGroup("SquintlyFurnitureMod:Flours", 2)
                    .AddRecipeGroup("SquintlyFurnitureMod:Sugars", 2)
                    .AddRecipeGroup("SquintlyFurnitureMod:Eggs", 2)
                    .AddIngredient(ItemID.Torch)
                    .AddTile(TileID.CookingPots)
                    .Register();
            }
        }
    }
}