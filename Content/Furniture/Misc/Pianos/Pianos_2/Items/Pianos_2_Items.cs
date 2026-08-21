using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Pianos.Pianos_2.Items;

internal class Pianos_2_Items : ModItem
{
    public class Pianos_2_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Pianos_2_Items(0)); //StoneBrickPiano
            mod.AddContent(new Pianos_2_Items(1)); //RedBrickPiano
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
            return "StoneBrickPiano";
        }
        if (style == 1)
        {
            return "RedBrickPiano";
        }

        throw new Exception("Invalid style");
    }

    public Pianos_2_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Pianos_2>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //StoneBrickPiano
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 15)
            .AddIngredient(ItemID.Book)
            .AddIngredient(ItemID.Bone, 4)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 1) //RedBrickPiano
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 15)
            .AddIngredient(ItemID.Book)
            .AddIngredient(ItemID.Bone, 4)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}