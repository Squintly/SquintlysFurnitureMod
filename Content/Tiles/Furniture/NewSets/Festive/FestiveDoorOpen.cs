using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Festive;
using SquintlysFurnitureMod.Content.Tiles.Abstracts;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Festive
{
    public class FestiveDoorOpen : DoorOpen_Tile
    {
        public override int ClosedDoorType => ModContent.TileType<FestiveDoorClosed>();
        public override int ItemDropType => ModContent.ItemType<FestiveDoorItem>();
    }
}