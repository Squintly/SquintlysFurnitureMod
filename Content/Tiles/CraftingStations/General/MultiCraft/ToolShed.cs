using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen.Items;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Shops;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.Holiday;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.MultiCraft;

public class ToolShed : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        AdjTiles = new int[] { TileID.Tables };
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

        Main.tileSolidTop[Type] = true;
        Main.tileTable[Type] = true;
        TileID.Sets.IgnoredByNpcStepUp[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.Height = 4;
        TileObjectData.newTile.Width = 4;
        TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 18 };

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(89, 51, 28), Language.GetText("ToolShed"));
        AdjTiles = new int[]
        {
            ModContent.TileType<BrickOven>(), ModContent.TileType<Smelter>(), ModContent.TileType<Stoves>(), ModContent.TileType<Fridges>(), ModContent.TileType<FestiveWorktable>(), ModContent.TileType<HeartfeltCraftingTableTile>() 
        };
    }
}

public class ToolShedItem : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(gold: 6, silver: 80);

        Item.DefaultToPlaceableTile(ModContent.TileType<ToolShed>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 50)
            .AddRecipeGroup(RecipeGroupID.IronBar, 10)
            .AddIngredient(ModContent.ItemType<ToolChestWideItem>())
            .AddIngredient(ModContent.ItemType<BrickOvenItem>())
            .AddIngredient(ModContent.ItemType<SmelterItem>())
            .AddIngredient(ModContent.ItemType<FestiveWorktableItem>())
            .AddIngredient(ModContent.ItemType<HeartfeltCraftingTable>())
            .AddRecipeGroup("SquintlyFurnitureMod:Stoves")
            .AddRecipeGroup("SquintlyFurnitureMod:Fridges")
            .AddTile(TileID.Sawmill)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.SilverCoin, 80)
            .AddIngredient(ItemID.GoldCoin, 6)
            .AddTile(ModContent.TileType<ShopMisc>())
            .Register();
    }
}