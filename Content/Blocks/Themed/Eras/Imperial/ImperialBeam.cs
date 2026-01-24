using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;

public class ImperialBeam : Unsolid
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(92, 54, 38));
    }
}

internal class ImperialBeamItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<ImperialBeam>());

        Item.width = 16;
        Item.height = 16;

        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        CreateRecipe(2)
           .AddIngredient(ModContent.ItemType<ImperialWoodItem>())
           .AddTile(TileID.WorkBenches)
           .Register();
    }
}