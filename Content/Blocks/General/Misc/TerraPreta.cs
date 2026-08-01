using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Blocks.General.Misc;

public class TerraPreta : SolidDirt
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(43, 16, 0));
    }
}

public class TerraPretaItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<TerraPreta>());

        Item.width = 32;
        Item.height = 32;
    }

    public override void AddRecipes()
    {
        CreateRecipe(8)
           .AddIngredient(ItemID.ClayBlock, 2)
           .AddIngredient(ItemID.DirtBlock, 2)
           .AddIngredient(ItemID.PoopBlock)
           .AddTile(TileID.HeavyWorkBench)
           .Register();
    }
}