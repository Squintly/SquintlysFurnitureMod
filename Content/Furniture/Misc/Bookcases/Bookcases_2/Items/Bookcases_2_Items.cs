using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Bookcases.Bookcases_2.Items;

internal class Bookcases_2_Items : ModItem
{
    public class Bookcases_2_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Bookcases_2_Items(0)); //ImperialBookcase
        }

        public void Unload()
        {
        }
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        if (style == 0)
        {
            return "ImperialBookcase";
        }

        throw new Exception("Invalid style");
    }

    public Bookcases_2_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Bookcases_2>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialBookcase
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 20)
            .AddIngredient(ItemID.Book, 10)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}