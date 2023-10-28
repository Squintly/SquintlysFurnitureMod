using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Festive;
using SquintlysFurnitureMod.Content.Tiles.Abstracts;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Festive
{
    public class FestiveDoorClosed : DoorClosed_Tile
    {
        public override int OpenDoorType => ModContent.TileType<FestiveDoorOpen>();
        public override int ItemDropType => ModContent.ItemType<FestiveDoorItem>();
    }
}