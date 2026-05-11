using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Aesthetics.Repaired;
using SquintlysFurnitureMod.Content.Blocks.Themed.Aesthetics.Tattered;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Platforms.Items;

internal class Platforms_Items : ModItem
{
    public class Platforms_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Platforms_Items(0)); //ImperialPlatform
            mod.AddContent(new Platforms_Items(1)); //ImperialCarpet
            mod.AddContent(new Platforms_Items(2)); //ImperialShelf
            mod.AddContent(new Platforms_Items(3)); //TatteredPlatform
            mod.AddContent(new Platforms_Items(4)); //TatteredCarpet
            mod.AddContent(new Platforms_Items(5)); //TatteredShelf
            mod.AddContent(new Platforms_Items(6)); //RepairedPlatform
            mod.AddContent(new Platforms_Items(7)); //RepairedCarpet
            mod.AddContent(new Platforms_Items(8)); //RepairedShelf
            mod.AddContent(new Platforms_Items(9)); //RedBrickPlatform
            mod.AddContent(new Platforms_Items(10)); //CinderblockPlatform
            mod.AddContent(new Platforms_Items(11)); //StoneBrickCarpet
            mod.AddContent(new Platforms_Items(12)); //RedBrickCarpet
            mod.AddContent(new Platforms_Items(13)); //CinderblockCarpet
            mod.AddContent(new Platforms_Items(14)); //StoneBrickShelf
            mod.AddContent(new Platforms_Items(15)); //RedBrickShelf
            mod.AddContent(new Platforms_Items(16)); //CinderblockShelf
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
            return "ImperialPlatform";
        }
        if (style == 1)
        {
            return "ImperialCarpet";
        }
        if (style == 2)
        {
            return "ImperialShelf";
        }
        if (style == 3)
        {
            return "TatteredPlatform";
        }
        if (style == 4)
        {
            return "TatteredCarpet";
        }
        if (style == 5)
        {
            return "TatteredShelf";
        }
        if (style == 6)
        {
            return "RepairedPlatform";
        }
        if (style == 7)
        {
            return "RepairedCarpet";
        }
        if (style == 8)
        {
            return "RepairedShelf";
        }
        if (style == 9)
        {
            return "RedBrickPlatform";
        }
        if (style == 10)
        {
            return "CinderblockPlatform";
        }
        if (style == 11)
        {
            return "StoneBrickCarpet";
        }
        if (style == 12)
        {
            return "RedBrickCarpet";
        }
        if (style == 13)
        {
            return "CinderblockCarpet";
        }
        if (style == 14)
        {
            return "StoneBrickShelf";
        }
        if (style == 15)
        {
            return "RedBrickShelf";
        }
        if (style == 16)
        {
            return "CinderblockShelf";
        }

        throw new Exception("Invalid style");
    }

    public Platforms_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Platforms>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(0);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //ImperialPlatform
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 1)
            .Register();
        }
        if (placeStyle == 1) //ImperialCarpet
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 1)
            .AddIngredient(ItemID.Silk)
            .Register();
        }
        if (placeStyle == 2) //ImperialShelf
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 1)
            .Register();
        }
        if (placeStyle == 3) //TatteredPlatform
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<TatteredWoodItem>())
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 4) //TatteredCarpet
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<TatteredWoodItem>())
            .AddIngredient(ItemID.Silk)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 5) //TatteredShelf
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<TatteredWoodItem>())
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 6) //RepairedPlatform
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<RepairedWoodItem>())
            .Register();

            CreateRecipe(2)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(3)).Type)
            .Register();
        }
        if (placeStyle == 7) //RepairedCarpet
        {
            CreateRecipe(2)
            .AddIngredient(ItemID.Silk)
            .AddIngredient(ModContent.ItemType<RepairedWoodItem>())
            .Register();

            CreateRecipe(2)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(3)).Type)
            .Register();
        }
        if (placeStyle == 8) //RepairedShelf
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<RepairedWoodItem>())
            .Register();

            CreateRecipe(2)
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(3)).Type)
            .Register();
        }
        if (placeStyle == 9) //RedBrickPlatform
        {
            CreateRecipe(2)
            .AddIngredient(ItemID.RedBrick)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 10) //CinderblockPlatform
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<CinderblockItem>())
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 11) //StoneBrickCarpet
        {
            CreateRecipe(2)
            .AddIngredient(ItemID.GrayBrick)
            .AddIngredient(ItemID.Silk)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 12) //RedBrickCarpet
        {
            CreateRecipe(2)
            .AddIngredient(ItemID.RedBrick)
            .AddIngredient(ItemID.Silk)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 13) //CinderblockCarpet
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<CinderblockItem>())
            .AddIngredient(ItemID.Silk)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 14) //StoneBrickShelf
        {
            CreateRecipe(2)
            .AddIngredient(ItemID.GrayBrick)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 15) //RedBrickShelf
        {
            CreateRecipe(2)
            .AddIngredient(ItemID.RedBrick)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 16) //CinderblockShelf
        {
            CreateRecipe(2)
            .AddIngredient(ModContent.ItemType<CinderblockItem>())
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}