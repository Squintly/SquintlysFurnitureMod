using SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Fish;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Fish;

internal class SmallHangingFish : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 14;
        Item.height = 16;

        Item.value = Item.buyPrice(silver: 5);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<SmallHangingFishTile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Bass)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.AtlanticCod)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.Flounder).
            Register();

        CreateRecipe()
            .AddIngredient(ItemID.Salmon)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.RedSnapper)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.Trout)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.Tuna)
            .Register();
    }
}