using SquintlysFurnitureMod.Content.Items.Blocks.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Heartfelt;

internal class HeartfeltDoor : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 14;
        Item.height = 24;

        Item.value = Item.buyPrice(silver: 1);

        Item.useStyle = (ItemUseStyleID.Swing);
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<HeartfeltDoorClosed>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<HeartfeltBlockItem>(), 6)
            //.AddIngredient(ItemID.Glass, 6)
            //.AddRecipeGroup(RecipeGroupID.IronBar, 3)
            .AddTile(ModContent.TileType<HeartfeltCraftingTableTile>())
            .Register();
    }
}