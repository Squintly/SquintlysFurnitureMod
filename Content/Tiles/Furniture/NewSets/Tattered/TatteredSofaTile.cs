using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Tattered;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered
{
    public class TatteredSofaTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[base.Type] = true;
            Main.tileLavaDeath[base.Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileID.Sets.DisableSmartCursor[base.Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
            TileObjectData.addTile(base.Type);
            base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            AdjTiles = new int[] { TileID.Chairs };
            ModTranslation name = base.CreateMapEntryName();
            name.SetDefault("Tattered Sofa");
            base.AddMapEntry(new Color(139, 0, 0), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, ModContent.ItemType<TatteredSofaItem>());
        }
    }
}
