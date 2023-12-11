using SquintlysFurnitureMod.Content.Items.Blocks.VanillaPlus;
using SquintlysFurnitureMod.Content.WallTiles.Other;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.WallItems.Other;

internal class FrostedGlassItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 0);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createWall = ModContent.WallType<FrostedGlass>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddIngredient(ItemID.Glass)
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}