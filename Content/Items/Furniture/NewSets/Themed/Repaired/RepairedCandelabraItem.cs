using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Tattered;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Themed.Repaired;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Repaired;

internal class RepairedCandelabraItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 22;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 3);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<RepairedCandelabra>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(ModContent.ItemType<TatteredCandelabraItem>())
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}