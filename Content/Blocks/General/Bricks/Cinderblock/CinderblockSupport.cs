using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;

public class CinderblockSupport : Unsolid
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(175, 175, 175));
    }
}

public class CinderblockSupportItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<CinderblockSupport>());

        Item.width = 32;
        Item.height = 32;
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
           .AddIngredient(ModContent.ItemType<CinderblockItem>())
           .AddTile(TileID.HeavyWorkBench)
           .Register();
    }
}