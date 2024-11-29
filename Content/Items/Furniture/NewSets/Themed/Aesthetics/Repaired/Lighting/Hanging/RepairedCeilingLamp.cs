using SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.CeilingLamps;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Tattered.Lighting.Hanging;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Repaired.Lighting.Hanging;

internal class RepairedCeilingLamp : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 22;

        Item.value = Item.buyPrice(copper: 20);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<CeilingLamps_4>());
        Item.placeStyle = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 2)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(ModContent.ItemType<TatteredCeilingLamp>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}