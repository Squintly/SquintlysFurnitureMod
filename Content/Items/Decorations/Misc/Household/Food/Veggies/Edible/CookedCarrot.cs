using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Veggies.Edible;

internal class CookedCarrot : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;

        Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));

        ItemID.Sets.FoodParticleColors[Item.type] = new Color[3]
            {
                new Color(159, 65, 0),
                new Color(204, 99, 27),
                new Color(237, 140, 73)
             };

        ItemID.Sets.IsFood[Type] = true;
    }

    public override void SetDefaults()
    {
        Item.DefaultToFood(22, 22, BuffID.WellFed3, 57600); // 57600 is 16 minutes: 16 * 60 * 60
        Item.value = Item.buyPrice(0, 3);
        Item.rare = ItemRarityID.Blue;
    }

    public override void OnConsumeItem(Player player)
    {
        player.AddBuff(BuffID.WellFed, 3600);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<Carrot>(), 1)
            .AddTile(TileID.CookingPots)
            .Register();
    }
}