using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.GameContent.ItemDropRules;
using SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.Armchairs;
using SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.CeilingLamps;

namespace SquintlysFurnitureMod.Content.Drops
{
    public class PirateDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.PirateCorsair || npc.type == NPCID.PirateCrossbower || npc.type == NPCID.PirateDeadeye || npc.type == NPCID.PirateDeckhand)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GoldenArmchair>(), 300));
            }
            if (npc.type == NPCID.PirateCorsair || npc.type == NPCID.PirateCrossbower || npc.type == NPCID.PirateDeadeye || npc.type == NPCID.PirateDeckhand)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GoldenCeilingLamp>(), 300));
            }
        }
    }
}
