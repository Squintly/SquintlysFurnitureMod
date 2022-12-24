using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SquintlysFurnitureMod.Content.Items.Decorations.Misc;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Misc;

public class DecorativeRopeTile : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileFrameImportant[base.Type] = true;
        TileID.Sets.DisableSmartCursor[base.Type] = true;

        Main.tileNoFail[base.Type] = true;
		Main.tileNoAttach[base.Type] = true;

        Main.tileLavaDeath[base.Type] = false;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
		TileObjectData.newTile.Width = 2;
		TileObjectData.newTile.Height = 1;
		TileObjectData.newTile.CoordinateHeights = new int[1] { 18 };
		TileObjectData.newTile.CoordinatePadding = 2;

		TileObjectData.addTile(base.Type);

		base.AddMapEntry(new Color(74, 62, 44), base.CreateMapEntryName("Decorative Rope"));
		base.HitSound = SoundID.Grass;
	}

    public override void KillMultiTile(int x, int y, int frameX, int frameY)
    {
        int item = 0;
        switch (frameX / 36)
        {
            case 0:
                item = ModContent.ItemType<Items.Decorations.Misc.DecorativeRope>();
                break;
            case 1:
                item = ModContent.ItemType<Items.Decorations.Misc.DecorativeSilkRope>();
                break;
            case 2:
                item = ModContent.ItemType<Items.Decorations.Misc.DecorativeVineRope>();
                break;
            case 3:
                item = ModContent.ItemType<Items.Decorations.Misc.DecorativeWebRope>();
                break;
        }
        if (item > 0)
        {
            Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 16, 16, item);
        }
    }
}

