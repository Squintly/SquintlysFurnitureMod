using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Halloween.Other.BellJars;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Halloween.Decorations.BellJars;

public class BellsLarge : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
        TileObjectData.newTile.Height = 2;
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, 2);
        TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };

        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 111;
        TileObjectData.newTile.RandomStyleRange = 11;

        TileObjectData.addTile(Type);

        RegisterItemDrop(ModContent.ItemType<BellJarTall>());
    }
    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
    {
        return true;
    }

    public override bool RightClick(int i, int j)
    {
        SoundEngine.PlaySound(SoundID.Item106);
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
        int topX = i - tile.TileFrameX % 18 / 18; //change first number depending on size
        int topY = j - tile.TileFrameY % 36 / 18;

        short frameAdjustment = (short)(tile.TileFrameX >= 36 ? -36 : 18); //change depending on width

        for (int x = topX; x < topX + 1; x++) // change depending on width
        {
            for (int y = topY; y < topY + 2; y++) // change height
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
            NetMessage.SendTileSquare(-1, topX, topY, 1, 2); //change for width, height
        }
    }
}