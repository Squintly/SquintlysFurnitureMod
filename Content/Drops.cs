using SquintlysFurnitureMod.Content.Furniture.Seating.Hard.Stools.Stools_2.Items;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Veggies;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Professions.Farming.Crops;
using SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.Armchairs;
using SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.CeilingLamps;
using SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.KingBeds;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content
{
    public class AnimalDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Bunny)
            {
                npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("Carrot").Type, 100));
                npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("BigCarrot").Type, 150));
                npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("Egg").Type, 100));
            }
            if (npc.type == NPCID.Bird || npc.type == NPCID.BirdBlue || npc.type == NPCID.BirdRed || npc.type == NPCID.BlueMacaw || npc.type == NPCID.Duck || npc.type == NPCID.Duck2 || npc.type == NPCID.DuckWhite || npc.type == NPCID.DuckWhite2 || npc.type == NPCID.Grebe || npc.type == NPCID.Grebe2 || npc.type == NPCID.Harpy || npc.type == NPCID.Owl || npc.type == NPCID.Parrot || npc.type == NPCID.PartyBunny || npc.type == NPCID.Penguin || npc.type == NPCID.PenguinBlack || npc.type == NPCID.ScarletMacaw || npc.type == NPCID.Seagull || npc.type == NPCID.Seagull2 || npc.type == NPCID.Toucan)
            {
                npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("Egg").Type, 80));
            }
        }
    }

    public class PirateDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.PirateCorsair || npc.type == NPCID.PirateCrossbower || npc.type == NPCID.PirateDeadeye || npc.type == NPCID.PirateDeckhand)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GoldenArmchair>(), 300));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GoldenCeilingLamp>(), 300));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<KingBedGold>(), 300));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GoldenStool>(), 300));
            }
        }
    }
}