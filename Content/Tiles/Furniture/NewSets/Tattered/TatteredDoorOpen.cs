using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Tattered;
using SquintlysFurnitureMod.Content.Tiles.Abstracts;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered
{
    public class TatteredDoorOpen : DoorOpen_Tile
    {
        public override int ClosedDoorType => ModContent.TileType<TatteredDoorClosed>();
        public override int ItemDropType => ModContent.ItemType<TatteredDoorItem>();
    }
}