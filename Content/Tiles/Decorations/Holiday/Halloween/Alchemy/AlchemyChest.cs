using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Halloween.Alchemy.Other;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Halloween.Alchemy
{
    public class AlchemyChest : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            Main.tileLavaDeath[Type] = true;
            Main.tileWaterDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };

            TileObjectData.newTile.StyleHorizontal = false;
            TileObjectData.newTile.StyleWrapLimit = 111;

            TileObjectData.addTile(Type);
            RegisterItemDrop(ModContent.ItemType<AlchemyChestItem>());
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
            int topX = i - tile.TileFrameX % 36 / 18; //change first number depending on size
            int topY = j - tile.TileFrameY % 54 / 18;

            short frameAdjustment = (short)(tile.TileFrameX >= 72 ? -72 : 36); //change last two depending on size

            for (int x = topX; x < topX + 2; x++) // change depending on width
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
                NetMessage.SendTileSquare(-1, topX, topY, 2, 3); //width, height
            }
        }
    }
}