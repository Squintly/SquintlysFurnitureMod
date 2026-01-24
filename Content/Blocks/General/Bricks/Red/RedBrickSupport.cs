using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Blocks.General.Bricks.Red;

public class RedBrickSupport : UnsolidLazure
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(181, 62, 59));
    }
}

public class RedBrickSupportItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<RedBrickSupport>());

        Item.width = 32;
        Item.height = 32;
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
           .AddIngredient(ItemID.RedBrick)
           .AddTile(TileID.HeavyWorkBench)
           .Register();
    }
}