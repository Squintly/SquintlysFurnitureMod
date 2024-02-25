using SquintlysFurnitureMod.Content.Items.Decorations.Misc.Household.Food.Meats.Hanging;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Misc.Household.Food.Meat.Hanging;

public class HangingMegaChickens : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.CoordinateWidth = 18;
        TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 16 };
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);

        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 111;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.RandomStyleRange = 3;

        TileObjectData.addTile(Type);
        RegisterItemDrop(ModContent.ItemType<HangingMegaChicken>());
    }

    public override bool RightClick(int i, int j)
    {
        SoundEngine.PlaySound(SoundID.NPCHit25);
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
        int topX = i - tile.TileFrameX % 20 / 20; //change first number depending on size
        int topY = j - tile.TileFrameY % 54 / 18;

        short frameAdjustment = (short)(tile.TileFrameX >= 40 ? -40 : 20); //change last two depending on size

        for (int x = topX; x < topX + 1; x++) // change depending on width
        {
            for (int y = topY; y < topY + 3; y++)
            {
                Main.tile[x, y].TileFrameX += frameAdjustment;

                if (Wiring.running)
                {
                    Wiring.SkipWire(x, y);
                }
            }
        }

        if (Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendTileSquare(-1, topX, topY, 1, 3); //width, height
        }
    }
}