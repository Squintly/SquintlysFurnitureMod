using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Tattered;
using SquintlysFurnitureMod.Content.Tiles.Abstracts;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered
{
    public class TatteredDoorClosed : DoorClosed_Tile
    {
        public override int ItemDropType => ModContent.ItemType<TatteredDoorItem>();
        public override int OpenDoorType => ModContent.TileType<TatteredDoorOpen>();
    }
}