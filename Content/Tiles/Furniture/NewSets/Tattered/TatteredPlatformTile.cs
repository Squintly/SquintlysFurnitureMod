using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Tattered;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Tattered;
public class TatteredPlatformTile : ModTile
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
		
		Main.tileSolidTop[base.Type] = true;
		Main.tileSolid[base.Type] = true;
		Main.tileTable[base.Type] = true;
		TileID.Sets.Platforms[base.Type] = true;

        AddMapEntry(new Color(79, 71, 58), base.CreateMapEntryName("Tattered Platform"));

        base.AdjTiles = new int[1] { 19 };
		
		TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
		TileObjectData.newTile.CoordinateWidth = 16;
		TileObjectData.newTile.CoordinatePadding = 2;

		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.StyleMultiplier = 27;
		TileObjectData.newTile.StyleWrapLimit = 27;

		TileObjectData.newTile.UsesCustomCanPlace = false;
		TileObjectData.addTile(base.Type);

        base.ItemDrop = ModContent.ItemType<TatteredPlatformItem>();
    }

	public override void PostSetDefaults()
	{
		Main.tileNoSunLight[base.Type] = false;
	}
}
