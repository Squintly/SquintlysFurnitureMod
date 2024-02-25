using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Woods.Teak;

public class TeakBathtub : ModTile
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

        TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.StyleLineSkip = 2;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Bathtub"));
    }
}