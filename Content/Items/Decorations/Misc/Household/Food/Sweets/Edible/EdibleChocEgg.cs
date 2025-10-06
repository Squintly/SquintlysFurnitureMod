using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks.Holiday;
using SquintlysFurnitureMod.Content.Tiles.Decorations.Crafting.Holiday;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Sweets.Edible;

internal class EdibleChocEgg : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;

        Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));

        ItemID.Sets.FoodParticleColors[Item.type] = new Color[3]
            {
                new Color(65, 28, 14),
                new Color(116, 69, 49),
                new Color(151, 107, 90)
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
        player.AddBuff(BuffID.SugarRush, 3600);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ChocolateBlockItem>(), 1)
            .AddTile(ModContent.TileType<FloralWorktable>())
            .Register();

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ChocolateSpringEgg>(), 1)
            .Register();
    }
}