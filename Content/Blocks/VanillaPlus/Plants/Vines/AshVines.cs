using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Plants;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Blocks.VanillaPlus.Plants.Vines;

public class AshVines : VinesSilk
{
    public override void SafeSetStaticDefaults()
    {
        RegisterItemDrop(ModContent.ItemType<AshVinesBasket>());
        AddMapEntry(new Color(255, 153, 0));
    }
}

public  class AshVinesBasket : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<AshVines>());
        Item.value = Item.buyPrice(silver: 5);

        Item.width = 32;
        Item.height = 32;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.AshGrassSeeds)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
           .Register();
    }
}