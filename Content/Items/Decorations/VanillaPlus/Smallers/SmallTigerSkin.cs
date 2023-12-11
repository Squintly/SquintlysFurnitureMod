using SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Smallers;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Smallers;

internal class SmallTigerSkin : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 17;
        Item.height = 15;

        Item.value = Item.buyPrice(gold: 1);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<SmallAnimalSkinsTile>();
        Item.placeStyle = 0;
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
            .AddIngredient(ItemID.TigerSkin)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}