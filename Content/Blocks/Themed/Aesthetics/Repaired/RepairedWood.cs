using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using SquintlysFurnitureMod.Content.Blocks.Themed.Aesthetics.Tattered;
using SquintlysFurnitureMod.Content.Walls.Themed.Aesthetics.Repaired;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Blocks.Themed.Aesthetics.Repaired;

public class RepairedWood : Solid
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(104, 69, 63));
    }
}

internal class RepairedWoodItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;

        Item.value = Item.buyPrice(0);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<RepairedWood>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.Wood)
            .AddIngredient(ModContent.ItemType<TatteredWoodItem>())
            .AddTile(TileID.WorkBenches)
            .Register();

        CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:RepairedPlatforms", 2)
            .Register();

        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<RepairedFenceItem>(), 4)
            .Register();

        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<RepairedWoodWallItem>(), 4)
            .Register();
    }
}