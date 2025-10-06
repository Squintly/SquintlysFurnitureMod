using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Walls;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Walls;

public class ImperialWallpaper : Wall
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(159, 23, 52));
    }
}

internal class ImperialWallpaperItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<ImperialWallpaper>());

        Item.width = 24;
        Item.height = 24;

        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddIngredient(ModContent.ItemType<ImperialWoodFancyItem>())
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}