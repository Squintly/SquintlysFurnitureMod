using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Surface.Lamps.Lamps_2.Items;

internal class Lamps_2_Items : ModItem
{
    public class Lamps_2_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Lamps_2_Items(0)); //CinderblockLamp
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
            return "CinderblockLamp";
        }

        throw new Exception("Invalid style");
    }

    public Lamps_2_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Lamps_2>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 1);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //CinderblockLamp
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 3)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}