using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Pianos.Pianos_1.Items;

internal class Pianos_1_Items : ModItem
{
    public class Pianos_1_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Pianos_1_Items(0)); //TatteredPiano
            mod.AddContent(new Pianos_1_Items(1)); //RepairedPiano
            mod.AddContent(new Pianos_1_Items(2)); //CinderblockPiano
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
            return "TatteredPiano";
        }
        if (style == 1)
        {
            return "RepairedPiano";
        }
        if (style == 2)
        {
            return "CinderblockPiano";
        }

        throw new Exception("Invalid style");
    }

    public Pianos_1_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Pianos_1>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 60);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //TatteredPiano
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 15)
            .AddIngredient(ItemID.Book)
            .AddIngredient(ItemID.Bone, 4)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 1) //RepairedPiano
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 7)
            .AddIngredient(ItemID.Book)
            .AddIngredient(ItemID.Bone, 2)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(0)).Type)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 2) //CinderblockPiano
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 15)
            .AddIngredient(ItemID.Book)
            .AddIngredient(ItemID.Bone, 4)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}