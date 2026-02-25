using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Walls;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Walls.Themed.Eras.Imperial;

public class ImperialWallpaperFancy : Wall
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(159, 23, 52));
    }
}

internal class ImperialWallpaperFancyItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<ImperialWallpaperFancy>());

        Item.width = 24;
        Item.height = 24;

        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddIngredient(ModContent.ItemType<ImperialWoodInlayItem>())
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}