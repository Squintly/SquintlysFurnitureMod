using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Eras.Imperial.Blocks;

public class ImperialWoodFancy : Solid
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(92, 54, 38));
    }
}
internal class ImperialWoodFancyItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<ImperialWoodFancy>());

        Item.width = 28;
        Item.height = 22;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
           .AddIngredient(ModContent.TileType<ImperialWood>())
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}