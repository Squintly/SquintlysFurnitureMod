using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Big.Five;

internal class S_1x1_B_5_Items : ModItem
{
    public class S_1x1_B_5_Items_Loader : ILoadable
    {
        public void Load(Mod mod)
        {
            for (int i = 0; i < 1; i++)
            {
                mod.AddContent(new S_1x1_B_5_Items(i));
            }
        }

        public void Unload()
        {
        }
    }

    public enum S_1x1_B_5_Style
    {
        Pitcher = 0
    }

    protected override bool CloneNewInstances => true;
    private readonly int placeStyle;

    public override string Name => GetInternalNameFromStyle(placeStyle);

    public static string GetInternalNameFromStyle(int style)
    {
        return Enum.GetName(typeof(S_1x1_B_5_Style), style);

        throw new Exception("Invalid style");
    }

    public S_1x1_B_5_Items(int placeStyle)
    {
        this.placeStyle = placeStyle;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<S_1x1_B_5>(), placeStyle);

        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;
        if (placeStyle == 0) //Pitcher
        {
            Item.value = Item.buyPrice(copper: 5);
        }
    }

    public override void AddRecipes()
    {
        //Shops
        if (placeStyle == 0) //Pitcher
        {
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 2)
                .AddTile(TileID.Sinks)
                .Register();
        }
    }
}
