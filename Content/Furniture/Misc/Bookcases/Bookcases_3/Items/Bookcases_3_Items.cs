using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Bookcases.Bookcases_3.Items;

internal class Bookcases_3_Items : ModItem
{
    public class Bookcases_3_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Bookcases_3_Items(0)); //StoneBrickBookcase
            mod.AddContent(new Bookcases_3_Items(1)); //RedBrickBookcase
            mod.AddContent(new Bookcases_3_Items(2)); //CinderblockBookcase
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
            return "StoneBrickBookcase";
        }
        if (style == 1)
        {
            return "RedBrickBookcase";
        }
        if (style == 2)
        {
            return "CinderblockBookcase";
        }

        throw new Exception("Invalid style");
    }

    public Bookcases_3_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Bookcases_3>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0)
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 20)
            .AddIngredient(ItemID.Book, 10)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 1) //RedBrickBookcase
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 20)
            .AddIngredient(ItemID.Book, 10)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 2) //CinderblockBookcase
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 20)
            .AddIngredient(ItemID.Book, 10)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}