using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace SquintlysFurnitureMod.Content.Furniture.Misc.Clocks
{
    public class Clocks_2_Animated : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            Main.tileLavaDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            TileID.Sets.Clock[Type] = true;
            AdjTiles = new int[] { TileID.GrandfatherClocks };

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16, 18 };
            TileObjectData.newTile.Origin = new Point16(0, 0);

            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.RandomStyleRange = 2;

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.addTile(Type);

            AnimationFrameHeight = 92;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            // Spend 9 ticks on each of 6 frames, looping
            frameCounter++;
            if (frameCounter >= 20)
            {
                frameCounter = 0;
                frame = ++frame % 8;
            }
        }
        public void ToggleTile(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int topX = i - tile.TileFrameX % 36 / 18;
            int topY = j - tile.TileFrameY % 92 / 18;

            short frameAdjustment = (short)(tile.TileFrameY >= 92 ? -92 : 92);

            for (int x = topX; x < topX + 2; x++)
            {
                for (int y = topY; y < topY + 5; y++)
                {
                    Main.tile[x, y].TileFrameY += frameAdjustment;

                    if (Wiring.running)
                    {
                        Wiring.SkipWire(x, y);
                    }
                }
            }
        }
        public override void HitWire(int i, int j)
        {
            ToggleTile(i, j);
        }
        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
        {
            var tile = Main.tile[i, j];

            if (tile.TileFrameY < 90)
            {
                frameYOffset = Main.tileFrame[type] * 92;
            }

            else
            {
                frameYOffset = 644;
            }
        }
        public override bool RightClick(int x, int y)
        {
            string text = "AM";
            double time = Main.time;
            if (!Main.dayTime)
            {
                time += 54000.0;
            }

            time = time / 86400.0 * 24.0;
            time = time - 7.5 - 12.0;
            if (time < 0.0)
            {
                time += 24.0;
            }

            if (time >= 12.0)
            {
                text = "PM";
            }

            int intTime = (int)time;
            double deltaTime = time - intTime;
            deltaTime = (int)(deltaTime * 60.0);
            string text2 = string.Concat(deltaTime);
            if (deltaTime < 10.0)
            {
                text2 = "0" + text2;
            }

            if (intTime > 12)
            {
                intTime -= 12;
            }

            if (intTime == 0)
            {
                intTime = 12;
            }

            Main.NewText($"Time: {intTime}:{text2} {text}", 255, 240, 20);

            SoundEngine.PlaySound(SoundID.Mech, new Vector2(x * 16, y * 16));
            ToggleTile(x, y);

            return true;
        }
    }
}
/*STYLES
0- Tattered
1- Repaired
*/