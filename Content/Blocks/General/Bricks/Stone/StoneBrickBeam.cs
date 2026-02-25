using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Blocks.General.Bricks.Stone;

public class StoneBrickBeam : Unsolid
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(120, 120, 120));
    }
}

public class StoneBrickBeamItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<StoneBrickBeam>());

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