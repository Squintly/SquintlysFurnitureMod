using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Tattered.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Repaired.Blocks;

public class RepairedBeam : Unsolid
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(104, 69, 63));
    }
}

internal class RepairedBeamItem : ModItem
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

        Item.DefaultToPlaceableTile(ModContent.TileType<RepairedBeam>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
            .AddIngredient(ItemID.Wood)
            .AddIngredient(ModContent.ItemType<TatteredBeamItem>())
            .AddTile(TileID.WorkBenches)
            .Register();

        CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<RepairedWoodItem>())
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}