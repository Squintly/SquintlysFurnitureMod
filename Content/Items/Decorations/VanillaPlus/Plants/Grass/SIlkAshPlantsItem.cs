using SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Plants.Grass;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Plants.Grass;

internal class SilkAshPlantsItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 26;

        Item.value = Item.buyPrice(silver: 5);

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<SilkAshPlants>();
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.AshGrassSeeds)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}