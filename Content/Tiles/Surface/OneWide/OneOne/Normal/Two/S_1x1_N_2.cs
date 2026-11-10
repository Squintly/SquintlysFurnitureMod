using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Normal.Two;

public class S_1x1_N_2 : ModTile
{
    public enum StyleIDs
    {
        Tops,
        Carrots,
        Mortars, //old
        ChampagneFlutes,
        BrightRose, //old
        DarkRose, //old
        RedChocolates, //old
        BlackChocolates, //old
        Persimmon,
        Guava,
        Buckets,
        CandyCanes

    }
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);

        TileObjectData.newTile.CoordinateHeights = new int[1] { 18 };

        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.newTile.StyleMultiplier = 2;
        TileObjectData.newTile.StyleWrapLimit = 2;
        TileObjectData.newTile.RandomStyleRange = 2;

        TileObjectData.addTile(Type);

        RegisterItemDrop(Mod.Find<ModItem>("MortarItem").Type, 2);
        RegisterItemDrop(Mod.Find<ModItem>("Rose").Type, 4);
        RegisterItemDrop(Mod.Find<ModItem>("Rose").Type, 5);
        RegisterItemDrop(Mod.Find<ModItem>("Chocolates").Type, 6);
        RegisterItemDrop(Mod.Find<ModItem>("Chocolates").Type, 7);
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
        int topX = i - tile.TileFrameX % 18 / 18; //change first number depending on size
        int topY = j - tile.TileFrameY % 18 / 18;

        bool shiftPressed = Main.keyState.PressingShift();
        if (!shiftPressed | shiftPressed)
        {
            short frameAdjustment = (short)(tile.TileFrameX >= 18 ? -18 : 18); //change first two by total size, last by style size

            for (int x = topX; x < topX + 1; x++) // change depending on width
            {
                for (int y = topY; y < topY + 1; y++) // change height
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
            NetMessage.SendTileSquare(-1, topX, topY, 1, 1); //change for width, height
        }
    }
}
