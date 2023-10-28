using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Festive;
using SquintlysFurnitureMod.Content.Tiles.Abstracts;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt
{
    public class HeartfeltDoorClosed : DoorClosed_Tile
    {
        public override int OpenDoorType => ModContent.TileType<HeartfeltDoorOpen>();
        public override int ItemDropType => ModContent.ItemType<FestiveDoorItem>();// has no item
    }
}