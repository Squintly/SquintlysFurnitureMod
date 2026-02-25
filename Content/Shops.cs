using SquintlysFurnitureMod.Content.Items.Blocks.Holiday.Spring;
using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Meats.Hanging;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content;

public class Shops : GlobalNPC
{
    public override void SetupTravelShop(int[] shop, ref int nextSlot)
    {
        shop[nextSlot] = ModContent.ItemType<HangingGameAnimals>();
        nextSlot++;

        shop[nextSlot] = ModContent.ItemType<HangingGoose>();
        nextSlot++;

        shop[nextSlot] = ModContent.ItemType<HangingMegaChicken>();
        nextSlot++;

        shop[nextSlot] = ModContent.ItemType<TeakWood>();
        nextSlot++;

        shop[nextSlot] = ModContent.ItemType<SpringyWood>();
        nextSlot++;
    }

    public override void ModifyShop(NPCShop shop)
    {
        if (shop.NpcType == NPCID.Merchant)
        {
            shop.Add<Egg>();
            shop.Add<Sugar>();
            shop.Add<Flour>();
            shop.Add<Yeast>();
            shop.Add<Salt>();
        }
    }
}