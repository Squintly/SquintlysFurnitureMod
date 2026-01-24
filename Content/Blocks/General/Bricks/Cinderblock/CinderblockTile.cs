using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;

public class CinderblockTile : SolidLazureClear
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(140, 140, 140));
    }
}

public class CinderblockItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<CinderblockTile>());

        Item.width = 32;
        Item.height = 32;
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddIngredient(ItemID.ClayBlock, 2)
           .AddIngredient(ItemID.StoneBlock, 2)
           .AddTile(TileID.HeavyWorkBench)
           .Register();

        CreateRecipe(1)
          .AddRecipeGroup("SquintlyFurnitureMod:CinderblockWalls", 4)
          .AddTile(TileID.HeavyWorkBench)
          .Register();
    }
}