using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SquintlysFurnitureMod.Content.Blocks.General.Grass;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Plants.Trees.Teak
{
    public class TeakSapling : ModTile
    {
        public override void SetStaticDefaults() 
        {
			Main.tileFrameImportant[Type] = true;

			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
            
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);

			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = [16, 18];
			
            TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.RandomStyleRange = 3;
			TileObjectData.newTile.StyleMultiplier = 3;
			TileObjectData.newTile.DrawFlipHorizontal = true;

			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<TeakGrass>()];

			TileObjectData.addTile(Type);

			AddMapEntry(new Color(103, 153, 58), Language.GetText("MapObject.Sapling"));
            
			TileID.Sets.TreeSapling[Type] = true;
			TileID.Sets.CommonSapling[Type] = true;
			TileID.Sets.SwaysInWindBasic[Type] = true;
			TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Plant"]); // Make this tile interact with golf balls in the same way other plants do

			AdjTiles = [TileID.Saplings];
		}
		public override void RandomUpdate(int i, int j)
	    {
		    if (Utils.NextBool(WorldGen.genRand, 20))
		    {
			    bool isPlayerNear = WorldGen.PlayerLOS(i, j);
			    if (WorldGen.GrowTree(i, j) && isPlayerNear)
			    {
				    WorldGen.TreeGrowFXCheck(i, j);
			    }
		    }
	    }
		public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects) {
			if (i % 2 == 0) {
				effects = SpriteEffects.FlipHorizontally;
			}
		}
    }
}
