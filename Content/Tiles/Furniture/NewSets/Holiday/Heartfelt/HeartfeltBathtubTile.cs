using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Holiday.Heartfelt;
using Terraria;
using Terraria.Audio;
using Terraria.Enums;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Heartfelt;

public class HeartfeltBathtubTile : ModTile
{
    private Asset<Texture2D> flameTexture;

    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoAttach[Type] = true;
        Main.tileNoFail[Type] = false;

        Main.tileLavaDeath[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLighted[Type] = true;
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        if (!Main.dedServ)
        {
            flameTexture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Tiles/Furniture/NewSets/Holiday/Heartfelt/HeartfeltBathtubTile_Flame");
        }

        AdjTiles = new int[] { TileID.Bathtubs };
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);

        TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.StyleLineSkip = 2;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Bathtub"));
        RegisterItemDrop(ModContent.ItemType<HeartfeltBathtub>());
    }

    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
    {
        return true;
    }

    public override bool RightClick(int i, int j)
    {
        SoundEngine.PlaySound(SoundID.Mech, new Vector2(i * 16, j * 16));
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
        int topX = i - tile.TileFrameX % 72 / 18;
        int topY = j - tile.TileFrameY % 36 / 18;

        short frameAdjustment = (short)(tile.TileFrameY >= 36 ? -36 : 36);

        for (int x = topX; x < topX + 4; x++)
        {
            for (int y = topY; y < topY + 2; y++)
            {
                Main.tile[x, y].TileFrameY += frameAdjustment;

                if (Wiring.running)
                {
                    Wiring.SkipWire(x, y);
                }
            }
        }

        if (Main.netMode != NetmodeID.SinglePlayer)
        {
            NetMessage.SendTileSquare(-1, topX, topY, 4, 2);
        }
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        Tile tile = Main.tile[i, j];
        if (tile.TileFrameY == 0)
        {
            // We can support different light colors for different styles here: switch (tile.frameY / 54)
            r = 1f;
            g = 0.95f;
            b = 0.65f;
        }
    }

    public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
    {
        var tile = Main.tile[i, j];

        if (!TileDrawing.IsVisible(tile))
        {
            return;
        }

        SpriteEffects effects = SpriteEffects.None;

        Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

        if (Main.drawToScreen)
        {
            zero = Vector2.Zero;
        }

        int width = 34;
        int offsetY = 0;
        int height = 34;
        short frameX = tile.TileFrameX;
        short frameY = tile.TileFrameY;

        TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref frameX, ref frameY);

        ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (uint)i); // Don't remove any casts.

        // We can support different flames for different styles here: int style = Main.tile[j, i].frameY / 54;
        for (int c = 0; c < 7; c++)
        {
            float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.05f;
            float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.05f;

            spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
        }
    }
}