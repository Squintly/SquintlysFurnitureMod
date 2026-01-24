using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Walls;
using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Walls.General.Bricks.Cinderblock;

public class CinderblockWall : WallLargeLazure
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(90, 90, 90));
    }
}

public class CinderblockWallItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<CinderblockWall>());

        Item.width = 32;
        Item.height = 32;
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddIngredient(ModContent.ItemType<CinderblockItem>())
           .AddTile(TileID.HeavyWorkBench)
           .Register();
    }
}