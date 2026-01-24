using SquintlysFurnitureMod.Content.Tiles.CraftingStations.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Furniture.Seating.Hard.Stools.Stools_2.Items;

internal class Stools_2_Items : ModItem
{
    public class Stools_2_ItemsLoader : ILoadable
    {
        public void Load(Mod mod)
        {
            mod.AddContent(new Stools_2_Items(0)); //WoodenStool
            mod.AddContent(new Stools_2_Items(1)); //EbonwoodStool
            mod.AddContent(new Stools_2_Items(2)); //ShadewoodStool
            mod.AddContent(new Stools_2_Items(3)); //MahoganyStool
            mod.AddContent(new Stools_2_Items(4)); //PearlwoodStool
            mod.AddContent(new Stools_2_Items(5)); //LivingwoodStool
            mod.AddContent(new Stools_2_Items(6)); //CactusStool
            mod.AddContent(new Stools_2_Items(7)); //BlueDungeonStool
            mod.AddContent(new Stools_2_Items(8)); //GreenDungeonStool
            mod.AddContent(new Stools_2_Items(9)); //PinkDungeonStool
            mod.AddContent(new Stools_2_Items(10)); //SkywareStool
            mod.AddContent(new Stools_2_Items(11)); //LihzahrdStool
            mod.AddContent(new Stools_2_Items(12)); //SpookyStool
            mod.AddContent(new Stools_2_Items(13)); //GlassStool
            mod.AddContent(new Stools_2_Items(14)); //HoneyStool
            mod.AddContent(new Stools_2_Items(15)); //FleshStool
                                                    //mod.AddContent(new Stools_2_Items(16)); //GoldenStool
            mod.AddContent(new Stools_2_Items(17)); //ObsidianStool
            mod.AddContent(new Stools_2_Items(18)); //MushroomStool
            mod.AddContent(new Stools_2_Items(19)); //BoneStool
            mod.AddContent(new Stools_2_Items(20)); //SteampunkStool
            mod.AddContent(new Stools_2_Items(21)); //PumpkinStool
            mod.AddContent(new Stools_2_Items(22)); //PalmwoodStool
            mod.AddContent(new Stools_2_Items(23)); //BorealStool
            mod.AddContent(new Stools_2_Items(24)); //SlimeStool
            mod.AddContent(new Stools_2_Items(25)); //FrozenStool
            mod.AddContent(new Stools_2_Items(26)); //DynastyStool
            mod.AddContent(new Stools_2_Items(27)); //MartianStool
            mod.AddContent(new Stools_2_Items(28)); //MeteoriteStool
            mod.AddContent(new Stools_2_Items(29)); //GraniteStool
            mod.AddContent(new Stools_2_Items(30)); //MarbleStool
            mod.AddContent(new Stools_2_Items(31)); //CrystalStool
            mod.AddContent(new Stools_2_Items(32)); //SpiderStool
            mod.AddContent(new Stools_2_Items(33)); //LesionStool
            mod.AddContent(new Stools_2_Items(34)); //SandstoneStool
            mod.AddContent(new Stools_2_Items(35)); //BambooStool
            mod.AddContent(new Stools_2_Items(36)); //ReefStool
            mod.AddContent(new Stools_2_Items(37)); //BalloonStool
            mod.AddContent(new Stools_2_Items(38)); //AshwoodStool
            mod.AddContent(new Stools_2_Items(39)); //NebulaStool
            mod.AddContent(new Stools_2_Items(40)); //StardustStool
            mod.AddContent(new Stools_2_Items(41)); //VortexStool
            mod.AddContent(new Stools_2_Items(42)); //SolarStool
            mod.AddContent(new Stools_2_Items(43)); //StoneBrickStool
            mod.AddContent(new Stools_2_Items(44)); //RedBrickStool
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
            return "WoodenStool";
        }
        if (style == 1)
        {
            return "EbonwoodStool";
        }
        if (style == 2)
        {
            return "ShadewoodStool";
        }
        if (style == 3)
        {
            return "MahoganyStool";
        }
        if (style == 4)
        {
            return "PearlwoodStool";
        }
        if (style == 5)
        {
            return "LivingwoodStool";
        }
        if (style == 6)
        {
            return "CactusStool";
        }
        if (style == 7)
        {
            return "BlueDungeonStool";
        }
        if (style == 8)
        {
            return "GreenDungeonStool";
        }
        if (style == 9)
        {
            return "PinkDungeonStool";
        }
        if (style == 10)
        {
            return "SkywareStool";
        }
        if (style == 11)
        {
            return "LihzahrdStool";
        }
        if (style == 12)
        {
            return "SpookyStool";
        }
        if (style == 13)
        {
            return "GlassStool";
        }
        if (style == 14)
        {
            return "HoneyStool";
        }
        if (style == 15)
        {
            return "FleshStool";
        }
        //if (style == 16)
        //{
        //    return "GoldenStool";
        //}
        if (style == 17)
        {
            return "ObsidianStool";
        }
        if (style == 18)
        {
            return "MushroomStool";
        }
        if (style == 19)
        {
            return "BoneStool";
        }
        if (style == 20)
        {
            return "SteampunkStool";
        }
        if (style == 21)
        {
            return "PumpkinStool";
        }
        if (style == 22)
        {
            return "PalmwoodStool";
        }
        if (style == 23)
        {
            return "BorealStool";
        }
        if (style == 24)
        {
            return "SlimeStool";
        }
        if (style == 25)
        {
            return "FrozenStool";
        }
        if (style == 26)
        {
            return "DynastyStool";
        }
        if (style == 27)
        {
            return "MartianStool";
        }
        if (style == 28)
        {
            return "MeteorStool";
        }
        if (style == 29)
        {
            return "GraniteStool";
        }
        if (style == 30)
        {
            return "MarbleStool";
        }
        if (style == 31)
        {
            return "CrystalStool";
        }
        if (style == 32)
        {
            return "SpiderStool";
        }
        if (style == 33)
        {
            return "LesionStool";
        }
        if (style == 34)
        {
            return "SandstoneStool";
        }
        if (style == 35)
        {
            return "BambooStool";
        }
        if (style == 36)
        {
            return "ReefStool";
        }
        if (style == 37)
        {
            return "BalloonStool";
        }
        if (style == 38)
        {
            return "AshWoodStool";
        }
        if (style == 39)
        {
            return "VortexStool";
        }
        if (style == 40)
        {
            return "StardustStool";
        }
        if (style == 41)
        {
            return "NebulaStool";
        }
        if (style == 42)
        {
            return "SolarStool";
        }
        if (style == 43)
        {
            return "StoneBrickStool";
        }
        if (style == 44)
        {
            return "RedBrickStool";
        }

        throw new Exception("Invalid style");
    }

    public Stools_2_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Stools_2>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(copper: 30);
        Item.maxStack = Item.CommonMaxStack;
    }

    public override void AddRecipes()
    {
        if (placeStyle == 0) //WoodenStool
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 1) //EbonwoodStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Ebonwood, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 2) //ShadewoodStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Shadewood, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 3) //MahoganyStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.RichMahogany, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 4) //PearlwoodStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Pearlwood, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 5) //LivingwoodStool
        {
            CreateRecipe(1)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.LivingLoom)
            .Register();
        }
        if (placeStyle == 6) //CactusStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Cactus, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 7) //BlueDungeonStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.BlueBrick, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.BoneWelder)
            .Register();
        }
        if (placeStyle == 8) //GreenDungeonStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.GreenBrick, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.BoneWelder)
            .Register();
        }
        if (placeStyle == 9) //PinkDungeonStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.PinkBrick, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.BoneWelder)
            .Register();
        }
        if (placeStyle == 10) //SkywareStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.SunplateBlock, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.SkyMill)
            .Register();
        }
        if (placeStyle == 11) //LihzahrdStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.LihzahrdBrick, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.LihzahrdFurnace)
            .Register();
        }
        if (placeStyle == 12) //SpookyStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.SpookyWood, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 13) //GlassStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Glass, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.GlassKiln)
            .Register();
        }
        if (placeStyle == 14) //HoneyStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.HoneyBlock, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.HoneyDispenser)
            .Register();
        }
        if (placeStyle == 15) //FleshStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.FleshBlock, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.FleshCloningVat)
            .Register();
        }
        //if (placeStyle == 16) //GoldenStool
        //{
        //    return "";
        //}
        if (placeStyle == 17) //ObsidianStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Obsidian, 2)
            .AddIngredient(ItemID.Hellstone, 2)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.Hellforge)
            .Register();
        }
        if (placeStyle == 18) //MushroomStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.GlowingMushroom, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 19) //BoneStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Bone, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.BoneWelder)
            .Register();
        }
        if (placeStyle == 20) //SteampunkStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Cog, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.SteampunkBoiler)
            .Register();
        }
        if (placeStyle == 21) //PumpkinStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.Pumpkin, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 22) //PalmStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.PalmWood, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 23) //BorealStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.BorealWood, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 24) //SlimeStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.SlimeBlock, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.Solidifier)
            .Register();
        }
        if (placeStyle == 25) //FrozenStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.IceBlock, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.IceMachine)
            .Register();
        }
        if (placeStyle == 26) //DynastyStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.DynastyWood, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 27) //MartianStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.MartianConduitPlating, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 28) //MeteoriteStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.MeteoriteBrick, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 29) //GraniteStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.GraniteBlock, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 30) //MarbleStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.MarbleBlock, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 31) //CrystalStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.CrystalBlock, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 32) //SpiderStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.SpiderBlock, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 33) //LesionStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.LesionBlock, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.LesionStation)
            .Register();
        }
        if (placeStyle == 34) //SandstoneStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.SmoothSandstone, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 35) //BambooStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.BambooBlock, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 36) //ReefStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.ReefBlock, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 37) //BalloonStool
        {
            CreateRecipe(1)
            .AddRecipeGroup("SquintlyFurnitureMod:Balloons", 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 38) //AshwoodStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.AshWood, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
        if (placeStyle == 39) //NebulaStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.NebulaBrick, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
        if (placeStyle == 40) //StardustStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.StardustBrick, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
        if (placeStyle == 41) //VortexStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.VortexBrick, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
        if (placeStyle == 42) //SolarStool
        {
            CreateRecipe(1)
            .AddIngredient(ItemID.SolarBrick, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
        if (placeStyle == 43) //StoneBrickStool
        {
            CreateRecipe()
            .AddIngredient(ItemID.GrayBrick, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
        if (placeStyle == 44) //RedBrickStool
        {
            CreateRecipe()
            .AddIngredient(ItemID.RedBrick, 4)
            .AddIngredient(ItemID.Silk)
            .AddTile(ModContent.TileType<BrickOven>())
            .Register();
        }
    }
}