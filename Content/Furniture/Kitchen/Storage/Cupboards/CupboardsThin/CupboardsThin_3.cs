using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Furniture.Counters;
using SquintlysFurnitureMod.Content.Abstracts.Furniture.Cupboards;
using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Misc;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Kitchen.Storage.Cupboards.CupboardsThin
{
    public class CupboardsThin_3_Antique : Merge_Cupboard_2x1_3
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Cupboard"));
        }
    }
    public class CupboardThin_3_Antique_Item : ModItem
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

            Item.DefaultToPlaceableTile(ModContent.TileType<CupboardsThin_3_Antique>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }

    public class CupboardsThin_3_Modern : Merge_Cupboard_2x1_3
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Cupboard"));
        }
    }
    public class CupboardThin_3_Modern_Item : ModItem
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

            Item.DefaultToPlaceableTile(ModContent.TileType<CupboardsThin_3_Modern>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }

    public class CupboardsThin_3_Retro : Merge_Cupboard_2x1_3
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Cupboard"));
        }
    }
    public class CupboardThin_3_Retro_Item : ModItem
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

            Item.DefaultToPlaceableTile(ModContent.TileType<CupboardsThin_3_Retro>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }

    public class CupboardsThin_3_Vintage : Merge_Cupboard_2x1_3
    {
        public override void SafeSetStaticDefaults()
        {
            AddMapEntry(new Color(200, 200, 200), Language.GetText("Cupboard"));
        }
    }
    public class CupboardThin_3_Vintage_Item : ModItem
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

            Item.DefaultToPlaceableTile(ModContent.TileType<CupboardsThin_3_Vintage>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.Wood, 10)
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddTile(ModContent.TileType<Worktable>())
            .Register();
        }
    }
}
