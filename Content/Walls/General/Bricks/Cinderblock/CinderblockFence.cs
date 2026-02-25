using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Walls;
using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Walls.General.Bricks.Cinderblock;

public class CinderblockFence : FenceLargeLazure
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(105, 105, 105));
    }
}

public class CinderblockFenceItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<CinderblockFence>());

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