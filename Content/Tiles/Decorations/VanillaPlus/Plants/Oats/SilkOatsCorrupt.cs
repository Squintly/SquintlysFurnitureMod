using SquintlysFurnitureMod.Content.Items.Decorations.VanillaPlus.Plants.Oats;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.VanillaPlus.Plants.Oats;

public class SilkOatsCorrupt : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;
        Main.tileWaterDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.DrawXOffset = 0;
        TileObjectData.newTile.DrawYOffset = -14;
        TileObjectData.newTile.CoordinateHeights = new int[1] { 32 };
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;

        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table | AnchorType.PlanterBox | AnchorType.AlternateTile, TileObjectData.newTile.Width, 0);

        TileObjectData.newTile.AnchorAlternateTiles = new int[]
            {
                TileID.ClayPot,
            };

        TileObjectData.newTile.RandomStyleRange = 15;
        TileObjectData.newTile.StyleWrapLimit = 111;
        TileObjectData.newTile.StyleHorizontal = true;

        TileID.Sets.SwaysInWindBasic[Type] = true;

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        RegisterItemDrop(ModContent.ItemType<SilkOatsCorruptBouquet>());
        HitSound = SoundID.Grass;
    }

    public override bool RightClick(int i, int j)
    {
        SoundEngine.PlaySound(SoundID.Grass);
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
        int topY = j - tile.TileFrameY % 18 / 18;

        short frameAdjustment = (short)(tile.TileFrameX >= 252 ? -252 : 18); //change last two depending on size

        for (int x = topX; x < topX + 1; x++) // change depending on width
        {
            for (int y = topY; y < topY + 1; y++)
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
            NetMessage.SendTileSquare(-1, topX, topY, 1, 1); //width, height
        }
    }
}