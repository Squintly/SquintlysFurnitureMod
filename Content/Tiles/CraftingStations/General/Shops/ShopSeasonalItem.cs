using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops
{
    public class ShopSeasonalItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 30);

            Item.DefaultToPlaceableTile(ModContent.TileType<ShopCrimbo>());
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddRecipeGroup(RecipeGroupID.Wood, 30)
                .AddRecipeGroup(RecipeGroupID.IronBar, 5)
                .AddTile(TileID.Sawmill)
                .Register();
        }
    }
}