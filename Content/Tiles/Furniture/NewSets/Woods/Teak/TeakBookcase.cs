using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Woods.Teak;
using Terraria;
using Terraria.Audio;
using Terraria.Enums;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Woods.Teak;

public class TeakBookcase : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        Main.tileLavaDeath[Type] = true;

        Main.tileLighted[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileSolidTop[Type] = true;
        Main.tileTable[Type] = true;
        AdjTiles = new int[] { TileID.Bookcases };
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
        TileObjectData.newTile.Height = 4;
        TileObjectData.newTile.CoordinateHeights = new int[4] { 16, 16, 16, 18 };

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Bookcase"));
    }
}