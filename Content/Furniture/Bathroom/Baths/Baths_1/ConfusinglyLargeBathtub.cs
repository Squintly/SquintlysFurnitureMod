using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Furniture.Bathroom.Baths.Baths_1
{
    public class ConfusinglyLargeBathtub : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            Main.tileLavaDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            AdjTiles = new int[] { TileID.Bathtubs };
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);

            TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);

            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 18 };
            TileObjectData.newTile.Origin = new Point16(0, 0);

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.addTile(Type);

            AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Bathtub"));
        }
    }
}