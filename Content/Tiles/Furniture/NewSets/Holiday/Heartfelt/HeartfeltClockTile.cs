using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Holiday.Heartfelt
{
    public class HeartfeltClockTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;

            Main.tileNoAttach[Type] = true;
            Main.tileNoFail[Type] = false;

            Main.tileLavaDeath[Type] = true;
            Main.tileWaterDeath[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;

            TileID.Sets.Clock[Type] = true;

            AdjTiles = new int[] { TileID.GrandfatherClocks };

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16, 18 };

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
            TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;

            TileObjectData.addTile(Type);
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
            return true;
        }
    }
}