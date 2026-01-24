using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Walls;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Walls.General.Bricks.Stone;

public class StoneBrickFence : FenceLargeLazure
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(120, 120, 120));
    }
}

public class StoneBrickFenceItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<StoneBrickFence>());

        Item.width = 32;
        Item.height = 32;
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddIngredient(ItemID.GrayBrick)
           .AddTile(TileID.HeavyWorkBench)
           .Register();
    }
}