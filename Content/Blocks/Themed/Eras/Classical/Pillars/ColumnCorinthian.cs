using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Classical.Pillars;

public class ColumnCorinthian : BigUnsolid
{
    public override void SafeSetStaticDefaults()
    {
        Main.tileMerge[Type][ModContent.TileType<ColumnDoric>()] = true;
        Main.tileMerge[Type][ModContent.TileType<ColumnIonic>()] = true;
        Main.tileMerge[ModContent.TileType<ColumnDoric>()][Type] = true;
        Main.tileMerge[ModContent.TileType<ColumnIonic>()][Type] = true;

        AddMapEntry(new Color(232, 236, 238));
    }
}
internal class ColumnCorinthianItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<ColumnCorinthian>());

        Item.width = 16;
        Item.height = 16;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
           .AddIngredient(ItemID.MarbleBlock)
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}