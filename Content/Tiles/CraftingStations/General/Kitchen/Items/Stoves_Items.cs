using SquintlysFurnitureMod.Content.Blocks.General.Bricks.Cinderblock;
using SquintlysFurnitureMod.Content.Blocks.Themed.Eras.Imperial;
using SquintlysFurnitureMod.Content.Furniture.Misc.Mirrors.Normal.Mirrors_1;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen.Items;

internal class Stoves_Items : ModItem
{
    public class Stoves_ItemsLoader : ILoadable //Make sure this matches the class name +Loader at the end! I generally automatically find/replace the whole string of Mirrors_1_Items (or whatever) to make sure nothing gets skipped or partially replaced. (I have made this mistake so, so many times)
    {
        public void Load(Mod mod) //This tells the game how many new items to make, and what style on the tile those items place. 0 here places the first (0th) style on the Mirrors_1 tile, while 1 places the 2nd, etc. Fun fact: you can skip numbers in order to have an item generated the normal way without making a duplicate. I've done that mostly for items from furniture sets I intend to replace, and for the Golden Stool, because I couldn't figure out how to make it drop from pirates properly.
        {
            for (int i = 0; i < 4; i++)
                {
                    mod.AddContent(new Stoves_Items(i));
                }
        }

        public void Unload()
        {
        }
    }
    public enum Stoves_Items_Style
    {
        StoveModern = 0,
        StoveRetro = 1,
        StoveAntique = 2,
        StoveVintage = 3
    }

    protected override bool CloneNewInstances => true; //This makes the game make a new item for each thing
    private readonly int placeStyle; 

    public override string Name => GetInternalNameFromStyle(placeStyle); //This connects the style (which is determined on the tile, not the item) with the internal name of the tile. This is NOT the item's actual name, but rather what you'd use as a class name for an individual item done the standard way, and they must all be unique. I try to have these match the style names I've given in the tile itself, as these are stored as strings rather than class names, meaning I can search for one thing and get results for both the tile and the item that places it.

    public static string GetInternalNameFromStyle(int style) //This is a list of internal names. There MUST be an internal name for every style listed in the Load, or it'll kick up errors.
    {
        return Enum.GetName(typeof(Stoves_Items_Style), style);

        throw new Exception("Invalid style");
    }

    public Stoves_Items(int placeStyle) // I honestly am not entirely sure what exactly this does, except maybe to connect the placeStyle here to the placeStyle used by the tile itself. Either way, it doesn't change, except forthe method name--Make sure that matches the class! Your program might flag this as a problem, it isn't. Just a weird Terraria thing.
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults() //This is more or less what you'd find in a normal item. I'm trying to standardize every item sprite to 32x32 but haven't done all of them yet. If an item sprite isn't 32x32 either just give it empty space, or if it's too large let me know and I'll make a smaller one.
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Stoves>(), placeStyle); //This is what tells the code what tile the items generated in this class places. Make sure this 

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(silver: 2);
        Item.maxStack = Item.CommonMaxStack; //Hey, you know that idea you had about replacing the numbers? Turns out TML actually already did that! I forgot about that, lol 
    }

    public override void AddRecipes() //This is entirely normal recipe code, for the most part.
    {
        CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.IronBar, 10)
            .AddIngredient(ItemID.Glass, 5)
            .AddIngredient(ItemID.HellstoneBar, 5)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }
}