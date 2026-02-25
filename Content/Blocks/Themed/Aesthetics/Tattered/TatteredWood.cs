using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using SquintlysFurnitureMod.Content.Walls.Themed.Aesthetics.Tattered;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Blocks.Themed.Aesthetics.Tattered;

public class TatteredWood : Solid
{
    public override void SafeSetStaticDefaults()
    {
        AddMapEntry(new Color(104, 69, 63));
    }
}

internal class TatteredWoodItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
    }

    public override void SetDefaults()
    {
        Item.width = 16;
        Item.height = 16;

        Item.value = Item.buyPrice(0);
        Item.maxStack = Item.CommonMaxStack;

        Item.DefaultToPlaceableTile(ModContent.TileType<TatteredWood>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.Wood)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();

        CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:TatteredPlatforms", 2)
            .Register();

        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<TatteredFenceItem>(), 4)
            .Register();

        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<TatteredWoodWallItem>(), 4)
            .Register();
    }
}