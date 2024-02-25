using SquintlysFurnitureMod.Content.Tiles.Decorations.Misc.Household.Food.Meat.Hanging;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Meats.Hanging;

internal class HangingMeat : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<HangingMeats>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup("SquintlysFurnitureMod:Meat", 2)
            .AddTile(TileID.CookingPots)
            .Register();
        
    }


}