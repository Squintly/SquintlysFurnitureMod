using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Walls;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Repaired.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Aesthetics.Repaired.Walls;

public class RepairedFence : FenceLargeLazure
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(58, 51, 36));
    }
}

internal class RepairedFenceItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<RepairedFence>());

        Item.width = 24;
        Item.height = 24;

        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddIngredient(ModContent.ItemType<RepairedWoodItem>())
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}