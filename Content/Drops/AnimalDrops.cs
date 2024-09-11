using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Veggies;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Farming.Crops;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Drops
{
    public class AnimalDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Bunny)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Carrot>(), 5));
            }
            if (npc.type == NPCID.Bunny)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BigCarrot>(), 10));
            }
            if (npc.type == NPCID.Bunny || npc.type == NPCID.Bird || npc.type == NPCID.BirdBlue || npc.type == NPCID.BirdRed || npc.type == NPCID.BlueMacaw || npc.type == NPCID.Duck || npc.type == NPCID.Duck2 || npc.type == NPCID.DuckWhite || npc.type == NPCID.DuckWhite2 || npc.type == NPCID.Grebe || npc.type == NPCID.Grebe2 || npc.type == NPCID.Harpy || npc.type == NPCID.Owl || npc.type == NPCID.Parrot || npc.type == NPCID.PartyBunny || npc.type == NPCID.Penguin || npc.type == NPCID.PenguinBlack || npc.type == NPCID.ScarletMacaw || npc.type == NPCID.Seagull || npc.type == NPCID.Seagull2 || npc.type == NPCID.Toucan)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Egg>(), 5));
            }
        }
    }
}