using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Walls;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Walls;

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
        Item.createWall = ModContent.WallType<ImperialWallpaperFancy>();

        Item.width = 24;
        Item.height = 24;
    }
    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddIngredient(ModContent.TileType<ImperialWood>())
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}