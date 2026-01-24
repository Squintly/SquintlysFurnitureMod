using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Aesthetics.Repaired;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Lights.Wall.Sconces.Items;

internal class Sconces_Items : ModItem
{
    public class Sconces_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Sconces_Items(0)); //ImperialSconceCandle
            mod.AddContent(new Sconces_Items(1)); //ImperialSconce
            mod.AddContent(new Sconces_Items(2)); //ImperialSconceGlass
            mod.AddContent(new Sconces_Items(3)); //TatteredSconceCandle
            mod.AddContent(new Sconces_Items(4)); //TatteredSconceGlass
            mod.AddContent(new Sconces_Items(5)); //TatteredSconceThick
            mod.AddContent(new Sconces_Items(6)); //TatteredSconceCandleSilver
            mod.AddContent(new Sconces_Items(7)); //TatteredSconceGlassSilver
            mod.AddContent(new Sconces_Items(8)); //TatteredSconceThickSilver
            mod.AddContent(new Sconces_Items(9)); //RepairedSconceCandle
            mod.AddContent(new Sconces_Items(10)); //RepairedSconceGlass
            mod.AddContent(new Sconces_Items(11)); //RepairedSconceThick
            mod.AddContent(new Sconces_Items(12)); //RepairedSconceCandleSilver
            mod.AddContent(new Sconces_Items(13)); //RepairedSconceGlassSilver
            mod.AddContent(new Sconces_Items(14)); //RepairedSconceThickSilver
            mod.AddContent(new Sconces_Items(15)); //StoneBrickSconce
            mod.AddContent(new Sconces_Items(16)); //StoneBrickSconceSmall
            mod.AddContent(new Sconces_Items(17)); //RedBrickSconce
            mod.AddContent(new Sconces_Items(18)); //RedBrickSconceSmall
            mod.AddContent(new Sconces_Items(19)); //CinderblockSconce
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
            return "ImperialSconceCandle";
        }
        if (style == 1)
        {
            return "ImperialSconce";
        }
        if (style == 2)
        {
            return "ImperialSconceGlass";
        }
        if (style == 3)
        {
            return "TatteredSconceCandle";
        }
        if (style == 4)
        {
            return "TatteredSconceGlass";
        }
        if (style == 5)
        {
            return "TatteredSconceThick";
        }
        if (style == 6)
        {
            return "TatteredSconceCandleSilver";
        }
        if (style == 7)
        {
            return "TatteredSconceGlassSilver";
        }
        if (style == 8)
        {
            return "TatteredSconceThickSilver";
        }
        if (style == 9)
        {
            return "RepairedSconceCandle";
        }
        if (style == 10)
        {
            return "RepairedSconceGlass";
        }
        if (style == 11)
        {
            return "RepairedSconceThick";
        }
        if (style == 12)
        {
            return "RepairedSconceCandleSilver";
        }
        if (style == 13)
        {
            return "RepairedSconceGlassSilver";
        }
        if (style == 14)
        {
            return "RepairedSconceThickSilver";
        }
        if (style == 15)
        {
            return "StoneBrickSconce";
        }
        if (style == 16)
        {
            return "StoneBrickSconceSmall";
        }
        if (style == 17)
        {
            return "RedBrickSconce";
        }
        if (style == 18)
        {
            return "RedBrickSconceSmall";
        }
        if (style == 19)
        {
            return "CinderblockSconce";
        }
        throw new Exception("Invalid style");
    }

    public Sconces_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Sconces>(), placeStyle);

        Item.width = 16;
        Item.height = 16;

        Item.value = Item.buyPrice(copper: 12);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialSconceCandle
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //ImperialSconce
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 2) //ImperialSconceGlass
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(ItemID.Glass)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 3) //TatteredSconceCandle
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 4) //TatteredSconceGlass
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 5) //TatteredSconceThick
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 6) //TatteredSconceCandleSilver
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 7) //TatteredSconceGlassSilver
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 8) //TatteredSconceThickSilver
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 9) //RepairedSconceCandle
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(ModContent.ItemType<RepairedWoodItem>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 10) //RepairedSconceGlass
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(ModContent.ItemType<RepairedWoodItem>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 11) //RepairedSconceThick
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(ModContent.ItemType<RepairedWoodItem>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 12) //RepairedSconceCandleSilver
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(ModContent.ItemType<RepairedWoodItem>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 13) //RepairedSconceGlassSilver
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(ModContent.ItemType<RepairedWoodItem>(), 4)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 14) //RepairedSconceThickSilver
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddIngredient(ModContent.ItemType<RepairedWoodItem>())
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 15) //StoneBrickSconce
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 16) //StoneBrickSconceSmall
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 17) //RedBrickSconce
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 18) //RedBrickSconceSmall
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 19) //CinderblockSconce
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 4)
            .AddIngredient(ItemID.Torch, 1)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}