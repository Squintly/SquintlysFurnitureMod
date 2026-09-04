using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.CraftingStations.General.Kitchen;

public class Fridges : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        Main.tileSolidTop[Type] = true;
        Main.tileTable[Type] = true;
        TileID.Sets.IgnoredByNpcStepUp[Type] = true;

        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.Height = 4;
        TileObjectData.newTile.CoordinateHeights = new int[4] { 16, 16, 16, 18 };
        TileObjectData.newTile.Width = 2;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleMultiplier = 3;
        TileObjectData.newTile.StyleWrapLimit = 3;
        TileObjectData.newTile.RandomStyleRange = 3;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(200, 200, 200), Language.GetText("Fridge"));
    }

    public override bool RightClick(int i, int j)
    {
        SoundEngine.PlaySound(SoundID.Mech);
        ToggleTile(i, j);
        return true;
    }

    public override void HitWire(int i, int j)
    {
        ToggleTile(i, j);
    }

    public void ToggleTile(int i, int j)
    {
        Tile tile = Main.tile[i, j];
        int topX = i - tile.TileFrameX % 32 / 16; //change first number depending on size
        int topY = j - tile.TileFrameY % 72 / 16;

        bool shiftPressed = Main.keyState.PressingShift();
        if (!shiftPressed)
        {
            short frameAdjustment = (short)(tile.TileFrameX >= 72 ? -72 : 36); //change first two by total size, last by style size

            for (int x = topX; x < topX + 2; x++) // change depending on width
            {
                for (int y = topY; y < topY + 4; y++) // change height
                {
                    Main.tile[x, y].TileFrameX += frameAdjustment;

                    if (Wiring.running)
                    {
                        Wiring.SkipWire(x, y);
                    }
                }
            }
        }
        if (shiftPressed)
        {
            short frameAdjustment = (short)(tile.TileFrameX < 36 ? 72 : -36); //change first two by total size, last by style size

            for (int x = topX; x < topX + 2; x++) // change depending on width
            {
                for (int y = topY; y < topY + 4; y++) // change height
                {
                    Main.tile[x, y].TileFrameX += frameAdjustment;

                    if (Wiring.running)
                    {
                        Wiring.SkipWire(x, y);
                    }
                }
            }
        }
        if (Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendTileSquare(-1, topX, topY, 2, 4); //change for width, height
        }
    }
}