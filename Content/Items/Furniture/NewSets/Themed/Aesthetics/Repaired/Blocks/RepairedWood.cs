using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Tattered.Blocks;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Repaired.Blocks;

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
    }
}