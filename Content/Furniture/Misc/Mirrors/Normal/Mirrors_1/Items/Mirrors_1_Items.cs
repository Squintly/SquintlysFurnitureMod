using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Mirrors.Normal.Mirrors_1.Items;

internal class Mirrors_1_Items : ModItem
{
    public class Mirrors_1_ItemsLoader : ILoadable //Make sure this matches the class name +Loader at the end! I generally automatically find/replace the whole string of Mirrors_1_Items (or whatever) to make sure nothing gets skipped or partially replaced. (I have made this mistake so, so many times)
    {
        public void Load(Mod mod) //This tells the game how many new items to make, and what style on the tile those items place. 0 here places the first (0th) style on the Mirrors_1 tile, while 1 places the 2nd, etc. Fun fact: you can skip numbers in order to have an item generated the normal way without making a duplicate. I've done that mostly for items from furniture sets I intend to replace, and for the Golden Stool, because I couldn't figure out how to make it drop from pirates properly.
        {
            for (int i = 0; i < 6; i++)
                {
                    mod.AddContent(new Mirrors_1_Items(i));
                }
        }

        public void Unload()
        {
        }
    }
    public enum Mirrors_1_Items_Style
    {
        ImperialMirror = 0,
        TatteredMirror = 1,
        RepairedMirror = 2,
        StoneBrickMirror = 3,
        RedBrickMirror = 4,
        CinderblockMirror = 5
    }

    protected override bool CloneNewInstances => true; //This makes the game make a new item for each thing
    private readonly int placeStyle; 

    public override string Name => GetInternalNameFromStyle(placeStyle); //This connects the style (which is determined on the tile, not the item) with the internal name of the tile. This is NOT the item's actual name, but rather what you'd use as a class name for an individual item done the standard way, and they must all be unique. I try to have these match the style names I've given in the tile itself, as these are stored as strings rather than class names, meaning I can search for one thing and get results for both the tile and the item that places it.

    public static string GetInternalNameFromStyle(int style) //This is a list of internal names. There MUST be an internal name for every style listed in the Load, or it'll kick up errors.
    {
        return Enum.GetName(typeof(Mirrors_1_Items_Style), style);

        throw new Exception("Invalid style");
    }

    public Mirrors_1_Items(int placeStyle) // I honestly am not entirely sure what exactly this does, except maybe to connect the placeStyle here to the placeStyle used by the tile itself. Either way, it doesn't change, except forthe method name--Make sure that matches the class! Your program might flag this as a problem, it isn't. Just a weird Terraria thing.
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults() //This is more or less what you'd find in a normal item. I'm trying to standardize every item sprite to 32x32 but haven't done all of them yet. If an item sprite isn't 32x32 either just give it empty space, or if it's too large let me know and I'll make a smaller one.
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Mirrors_1>(), placeStyle); //This is what tells the code what tile the items generated in this class places. Make sure this 

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 2);
        Item.maxStack = Item.CommonMaxStack; //Hey, you know that idea you had about replacing the numbers? Turns out TML actually already did that! I forgot about that, lol 
    }

    public override void AddRecipes() //This is entirely normal recipe code, for the most part.
    {
        if (placeStyle == 0) //ImperialMirror
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImperialWoodItem>(), 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //TatteredMirror
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .Register();
        }
        if (placeStyle == 2) //RepairedMirror
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddIngredient(ItemID.Glass, 1)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar")
            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(1)).Type) // <--- This is not normal recipe code, but is how to reference an item made by this process, since the item doesn't technically "exist" until the game creates it. If you're trying to use an item which is generated by a different file, put the class name before this. (example: Dressers_Animated_1_Items.GetInternalNameFromStyle(0) allowed me to use the tattered dresser (which is generated by the animated dressers class,) to be used as an ingredient for the repaired dresser (which is non-animated and thus generated by a different class.)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 3) //StoneBrickMirror
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 4) //RedBrickMirror
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 5) //CinderblockMirror
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CinderblockItem>(), 5)
            .AddIngredient(ItemID.Glass, 3)
            .AddRecipeGroup("SquintlyFurnitureMod:SilverBar", 2)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}