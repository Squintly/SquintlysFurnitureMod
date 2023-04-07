using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Festive;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Festive
{
	public class FestiveArmchair : ModTile
	{
		public const int NextStyleHeight = 40; 

		public override void SetStaticDefaults() {
			Main.tileFrameImportant[Type] = true;

            Main.tileNoFail[base.Type] = false;
            Main.tileNoAttach[base.Type] = true;

            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

            TileID.Sets.HasOutlines[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;

			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
			AdjTiles = new int[] { TileID.Chairs };

			AddMapEntry(new Color(12, 69, 6), base.CreateMapEntryName("Festive Armchair"));

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;

            TileObjectData.newTile.StyleWrapLimit = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
			TileObjectData.newTile.StyleHorizontal = true;

			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
			TileObjectData.addAlternate(1);

			TileObjectData.addTile(Type);
		}

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 24, ModContent.ItemType<FestiveArmchairItem>());
        }
    }
}
