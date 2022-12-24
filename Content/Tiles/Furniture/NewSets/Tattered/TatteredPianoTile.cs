using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered
{
    public class TatteredPianoTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[base.Type] = false;

            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            Main.tileWaterDeath[Type] = true;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileID.Sets.DisableSmartCursor[Type] = true;

            Main.tileSolidTop[Type] = true;
            Main.tileTable[base.Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
            TileObjectData.addTile(Type);

            AdjTiles = new int[] { TileID.Pianos };
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            // Etc
            AddMapEntry(new Color(79, 71, 58), base.CreateMapEntryName("Tattered Piano"));
        }

        public override void KillMultiTile(int x, int y, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, ModContent.ItemType<Items.Furniture.NewSets.Tattered.TatteredPianoItem>());
        }
    }
}

