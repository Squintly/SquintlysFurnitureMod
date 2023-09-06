using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Tattered;
using SquintlysFurnitureMod.Content.Tiles.Abstracts;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered
{
    public class TatteredDoorClosed : DoorClosed_Tile
    {
        public override int ItemDropType => ModContent.ItemType<TatteredDoorItem>();
        public override int OpenDoorType => ModContent.TileType<TatteredDoorOpen>();
    }
}