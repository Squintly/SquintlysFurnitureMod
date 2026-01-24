using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Walls;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Walls.General.Bricks.Red;

public class RedBrickFence : FenceLargeLazure
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(181, 62, 59));
    }
}

public class RedBrickFenceItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<RedBrickFence>());

        Item.width = 32;
        Item.height = 32;
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddIngredient(ItemID.RedBrick)
           .AddTile(TileID.HeavyWorkBench)
           .Register();
    }
}