using SquintlysFurnitureMod.Content.Furniture.Seating.Hard.Stools.Stools_2.Items;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Ingredients;
using SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.Armchairs;
using SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.CeilingLamps;
using SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.KingBeds;
using Terraria;
using Terraria.Enums;
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
                npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("Carrot").Type, 200));
                npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("CarrotsBig").Type, 250));
                npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("Eggs").Type, 200));
                npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("EggsBrown").Type, 200));
            }
            if (npc.type == NPCID.Bird || npc.type == NPCID.BirdBlue || npc.type == NPCID.BirdRed || npc.type == NPCID.BlueMacaw || npc.type == NPCID.Duck || npc.type == NPCID.Duck2 || npc.type == NPCID.DuckWhite || npc.type == NPCID.DuckWhite2 || npc.type == NPCID.Grebe || npc.type == NPCID.Grebe2 || npc.type == NPCID.Harpy || npc.type == NPCID.Owl || npc.type == NPCID.Parrot || npc.type == NPCID.PartyBunny || npc.type == NPCID.Penguin || npc.type == NPCID.PenguinBlack || npc.type == NPCID.ScarletMacaw || npc.type == NPCID.Seagull || npc.type == NPCID.Seagull2 || npc.type == NPCID.Toucan)
            {
                npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("Eggs").Type, 200));
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

    public class TreeShake : GlobalTile
    {
        public override void PreShakeTree(int x, int y, TreeTypes treeType)
        {
            if (treeType == TreeTypes.Forest && WorldGen.genRand.NextBool(150))
            {
                Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), x * 16, y * 16, 16, 16, Mod.Find<ModItem>("Eggw").Type);
                Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), x * 16, y * 16, 16, 16, Mod.Find<ModItem>("EggsBrown").Type);
            }
        }
    }
}