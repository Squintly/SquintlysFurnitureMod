using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using SquintlysFurnitureMod.Content.Abstracts.Walls;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Walls.General.Bricks.Stone;

public class StoneBrickPole : Fence
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(120, 120, 120));
    }
}

public class StoneBrickPoleItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<StoneBrickPole>());

        Item.width = 32;
        Item.height = 32;
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
           .AddIngredient(ItemID.GrayBrick)
           .AddTile(TileID.HeavyWorkBench)
           .Register();
    }
}