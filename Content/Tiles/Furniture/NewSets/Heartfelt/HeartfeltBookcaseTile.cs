using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Heartfelt;

public class HeartfeltBookcaseTile : ModTile
{
    private Asset<Texture2D> flameTexture;

    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        Main.tileLavaDeath[Type] = true;

        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileSolidTop[Type] = true;
        Main.tileTable[Type] = true;
        AdjTiles = new int[] { TileID.Bookcases };
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

        Main.tileLighted[Type] = true;
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        if (!Main.dedServ)
        {
            flameTexture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Tiles/Furniture/NewSets/Heartfelt/HeartfeltBookcaseTile_Flame");
        }

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
        TileObjectData.newTile.Height = 4;
        TileObjectData.newTile.CoordinateHeights = new int[4] { 16, 16, 16, 18 };

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.addTile(Type);

        AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Bookcase"));
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        Tile tile = Main.tile[i, j];
        if (tile.TileFrameX == 0)
        {
            // We can support different light colors for different styles here: switch (tile.frameY / 54)
            r = 1f;
            g = 0.95f;
            b = 0.65f;
        }
    }

    public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
    {
        SpriteEffects effects = SpriteEffects.None;

        //if (i % 2 == 1) {
        //	effects = SpriteEffects.FlipHorizontally;
        //}

        Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

        if (Main.drawToScreen)
        {
            zero = Vector2.Zero;
        }

        Tile tile = Main.tile[i, j];
        int width = 34;
        int offsetY = 0;
        int height = 34;
        short frameX = tile.TileFrameX;
        short frameY = tile.TileFrameY;

        TileLoader.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref frameX, ref frameY);

        ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i); // Don't remove any casts.

        // We can support different flames for different styles here: int style = Main.tile[j, i].frameY / 54;
        for (int c = 0; c < 7; c++)
        {
            float shakeX = Utils.RandomInt(ref randSeed, -10, 11) * 0.05f;
            float shakeY = Utils.RandomInt(ref randSeed, -10, 1) * 0.05f;

            spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + shakeX, j * 16 - (int)Main.screenPosition.Y + offsetY + shakeY) + zero, new Rectangle(frameX, frameY, width, height), new Color(100, 100, 100, 0), 0f, default, 1f, effects, 0f);
        }
    }
}