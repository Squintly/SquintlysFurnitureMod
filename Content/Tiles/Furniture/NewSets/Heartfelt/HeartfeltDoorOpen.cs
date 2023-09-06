using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Heartfelt;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Festive;
using SquintlysFurnitureMod.Content.Tiles.Abstracts;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt
{
    public class HeartfeltDoorOpen : DoorOpen_Tile
    {
        public override int ClosedDoorType => ModContent.TileType<HeartfeltDoorClosed>();

        public override int ItemDropType => ModContent.ItemType<FestiveDoorItem>(); // has no item currently
    }
}