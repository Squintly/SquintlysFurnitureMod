using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Festive;
using SquintlysFurnitureMod.Content.Tiles.Abstracts;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt
{
    public class HeartfeltDoorOpen : DoorOpen_Tile
    {
        public override int ClosedDoorType => ModContent.TileType<HeartfeltDoorClosed>();

        public override int ItemDropType => ModContent.ItemType<FestiveDoorItem>(); // has no item currently
    }
}