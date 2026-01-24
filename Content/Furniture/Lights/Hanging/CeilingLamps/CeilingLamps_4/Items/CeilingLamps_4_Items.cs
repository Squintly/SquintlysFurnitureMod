//using System;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace SquintlysFurnitureMod.Content.Furniture.Lights.Hanging.CeilingLamps.CeilingLamps_4.Items;

//internal class CeilingLamps_4_Items : ModItem
//{
//    public class CeilingLamps_4_ItemsLoader : ILoadable
//    {
//        public void Load(Mod mod)
//        {
//            mod.AddContent(new CeilingLamps_4_Items(0)); //TatteredCeilingLamp
//            mod.AddContent(new CeilingLamps_4_Items(1)); //RepairedCeilingLamp
//        }

//        public void Unload()
//        {
//        }
//    }

//    protected override bool CloneNewInstances => true;
//    private readonly int placeStyle;

//    public override string Name => GetInternalNameFromStyle(placeStyle);

//    public static string GetInternalNameFromStyle(int style)
//    {
//        if (style == 0)
//        {
//            return "TatteredCeilingLamp";
//        }
//        if (style == 1)
//        {
//            return "RepairedCeilingLamp";
//        }

//        throw new Exception("Invalid style");
//    }

//    public CeilingLamps_4_Items(int placeStyle)
//    {
//        this.placeStyle = placeStyle;
//    }

//    public override void SetDefaults()
//    {
//        Item.DefaultToPlaceableTile(ModContent.TileType<CeilingLamps_4>(), placeStyle);

//        Item.width = 32;
//        Item.height = 32;

//        Item.value = Item.buyPrice(copper: 30);
//        Item.maxStack = Item.CommonMaxStack;
//    }

//    public override void AddRecipes()
//    {
//        if (placeStyle == 1) //TatteredCeilingLamp
//        {
//            CreateRecipe()
//            .AddRecipeGroup(RecipeGroupID.Wood, 4)
//            .AddIngredient(ItemID.Torch)
//            .AddTile(TileID.WorkBenches)
//            .AddCondition(Condition.InGraveyard)
//            .Register();
//        }
//        if (placeStyle == 2) //RepairedCeilingLamp
//        {
//            CreateRecipe()
//            .AddRecipeGroup(RecipeGroupID.Wood, 2)
//            .AddIngredient(ItemID.Torch)
//            .AddIngredient(Mod.Find<ModItem>(GetInternalNameFromStyle(0)).Type)
//            .AddTile(TileID.WorkBenches)
//            .Register();
//        }
//    }
//}