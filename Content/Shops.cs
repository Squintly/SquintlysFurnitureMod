using SquintlysFurnitureMod.Content.Items;
using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Meats.Hanging;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content;

public class Shops : GlobalNPC
{
    public override void SetupTravelShop(int[] shop, ref int nextSlot)
    {
        shop[nextSlot] = ModContent.ItemType<HangingPheasant>();
        nextSlot++;

        shop[nextSlot] = ModContent.ItemType<HangingGoose>();
        nextSlot++;

        shop[nextSlot] = ModContent.ItemType<HangingMegaChicken>();
        nextSlot++;

        shop[nextSlot] = ModContent.ItemType<TeakWood>();
        nextSlot++;
    }

    //public override void ModifyShop (NPCShop shop)
    //{ 
    //if (shop.NpcType == NPCID.Merchant)
    //    {
    //        shop.Add(new Item(ItemID.Silk)
    //        {
    //            shopCustomPrice = Item.buyPrice(0, 0, 12, 10)
    //        });
    //    }    
    //}
}


