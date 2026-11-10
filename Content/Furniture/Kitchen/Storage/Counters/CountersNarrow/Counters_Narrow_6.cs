using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Furniture.Counters;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Counters.CountersNarrow
{
    public class CountersNarrow_6_Antique : Merge_Table_1x2_6
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Counter"));
        }
    }
    public class CounterNarrow_6_Antique_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 6);
            Item.maxStack = Item.CommonMaxStack;

            Item.DefaultToPlaceableTile(ModContent.TileType<CountersNarrow_6_Antique>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddIngredient(ItemID.StoneSlab, 2)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }

    public class CountersNarrow_6_Modern : Merge_Table_1x2_6
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Counter"));
        }
    }
    public class CounterNarrow_6_Modern_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 6);
            Item.maxStack = Item.CommonMaxStack;

            Item.DefaultToPlaceableTile(ModContent.TileType<CountersNarrow_6_Modern>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddIngredient(ItemID.StoneSlab, 2)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }

    public class CountersNarrow_6_Retro : Merge_Table_1x2_6
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Counter"));
        }
    }
    public class CounterNarrow_6_Retro_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 6);
            Item.maxStack = Item.CommonMaxStack;

            Item.DefaultToPlaceableTile(ModContent.TileType<CountersNarrow_6_Retro>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddIngredient(ItemID.StoneSlab, 2)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }

    public class CountersNarrow_6_Vintage : Merge_Table_1x2_6
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Counter"));
        }
    }
    public class CounterNarrow_6_Vintage_Item : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.value = Item.buyPrice(silver: 6);
            Item.maxStack = Item.CommonMaxStack;

            Item.DefaultToPlaceableTile(ModContent.TileType<CountersNarrow_6_Vintage>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddIngredient(ItemID.StoneSlab, 2)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }
}
