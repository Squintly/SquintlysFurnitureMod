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

namespace SquintlysFurnitureMod.Content.Furniture.Kitchen.Appliances.Dishwashers
{
    public class Dishwashers_Antique : Merge_Table_2x2_3
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Dishwasher"));
        }
    }
    public class Dishwasher_Antique_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 30);
            Item.maxStack = Item.CommonMaxStack;

            Item.DefaultToPlaceableTile(ModContent.TileType<Dishwashers_Antique>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 10)
            .AddIngredient(ItemID.StoneSlab, 5)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }

    public class Dishwashers_Modern : Merge_Table_2x2_3
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Dishwasher"));
        }
    }
    public class Dishwasher_Modern_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 30);
            Item.maxStack = Item.CommonMaxStack;

            Item.DefaultToPlaceableTile(ModContent.TileType<Dishwashers_Modern>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 10)
            .AddIngredient(ItemID.StoneSlab, 5)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }

    public class Dishwashers_Retro : Merge_Table_2x2_3
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Dishwasher"));
        }
    }
    public class Dishwasher_Retro_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 30);
            Item.maxStack = Item.CommonMaxStack;

            Item.DefaultToPlaceableTile(ModContent.TileType<Dishwashers_Retro>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 10)
            .AddIngredient(ItemID.StoneSlab, 5)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }

    public class Dishwashers_Vintage : Merge_Table_2x2_3
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Dishwasher"));
        }
    }
    public class Dishwasher_Vintage_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 30);
            Item.maxStack = Item.CommonMaxStack;

            Item.DefaultToPlaceableTile(ModContent.TileType<Dishwashers_Vintage>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 10)
            .AddIngredient(ItemID.StoneSlab, 5)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }
}
