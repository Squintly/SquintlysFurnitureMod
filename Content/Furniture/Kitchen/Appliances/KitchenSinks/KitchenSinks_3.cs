using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Furniture.Counters;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Kitchen.Appliances.KitchenSinks
{
    public class KitchenSinks_Antique : Merge_Table_2x2_3_Ext
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Kitchen Sink"));
        }
    }
    public class KitchenSink_Antique_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 21);
            Item.maxStack = Item.CommonMaxStack;

            Item.DefaultToPlaceableTile(ModContent.TileType<KitchenSinks_Antique>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 5)
            .AddIngredient(ItemID.WaterBucket)
            .AddIngredient(ItemID.StoneSlab, 5)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }

    public class KitchenSinks_Modern : Merge_Table_2x2_3_Ext
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Kitchen Sink"));
        }
    }
    public class KitchenSink_Modern_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 21);
            Item.maxStack = Item.CommonMaxStack;

            Item.DefaultToPlaceableTile(ModContent.TileType<KitchenSinks_Modern>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 5)
            .AddIngredient(ItemID.WaterBucket)
            .AddIngredient(ItemID.StoneSlab, 5)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }

    public class KitchenSinks_Retro : Merge_Table_2x2_3_Ext
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Kitchen Sink"));
        }
    }
    public class KitchenSink_Retro_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 21);
            Item.maxStack = Item.CommonMaxStack;

            Item.DefaultToPlaceableTile(ModContent.TileType<KitchenSinks_Retro>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 5)
            .AddIngredient(ItemID.WaterBucket)
            .AddIngredient(ItemID.StoneSlab, 5)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }

    public class KitchenSinks_Vintage : Merge_Table_2x2_3_Ext
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Kitchen Sink"));
        }
    }
    public class KitchenSink_Vintage_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 21);
            Item.maxStack = Item.CommonMaxStack;

            Item.DefaultToPlaceableTile(ModContent.TileType<KitchenSinks_Vintage>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 5)
            .AddIngredient(ItemID.WaterBucket)
            .AddIngredient(ItemID.StoneSlab, 5)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }
}
