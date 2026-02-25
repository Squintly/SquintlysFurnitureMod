using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Walls;
using SquintlysFurnitureMod.Content.Blocks.Themed.Aesthetics.Repaired;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Walls.Themed.Aesthetics.Repaired;

public class RepairedWoodWall : Wall
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(85, 58, 48));
    }
}

internal class RepairedWoodWallItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<RepairedWoodWall>());

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